using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.IO.CompressionTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
[AzurePipelines(
    AzurePipelinesImage.WindowsLatest,
    InvokedTargets = new[] { nameof(Test) })]
[GitHubActions(
    "dotnet-core",
    GitHubActionsImage.WindowsLatest,
    OnPushBranches = new[] { MainBranch, DevelopBranch, ReleaseBranchPrefix + "/*", VersionBranchPrefix + "*" },
    InvokedTargets = new[] { nameof(Publish) },
    ImportGitHubTokenAs = nameof(GitHubToken),
    ImportSecrets =
        new[]
        {
            nameof(NuGetApiKey)
        })]
partial class Build : NukeBuild
{
    /// <summary>
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    /// </summary>
    public static int Main() => Execute<Build>(x => x.Compile);

    [CI] private readonly TeamCity TeamCity;
    [CI] private readonly AzurePipelines AzurePipelines;
    [CI] private readonly GitHubActions GitHubActions;

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    private readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] private readonly Solution Solution;
    [GitRepository] private readonly GitRepository GitRepository;
    [GitVersion(Framework = "netcoreapp3.1")] private readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath OutputDirectory => RootDirectory / "output";

    private const string MainBranch = "main";
    private const string DevelopBranch = "develop";
    private const string ReleaseBranchPrefix = "release";
    private const string VersionBranchPrefix = "v";

    private bool IsOriginalRepository => GitRepository != null && GitRepository.Identifier == "MarkZither/KimaiDotNet";

    private string NuGetPackageSource => "https://api.nuget.org/v3/index.json";
    private string GitHubPackageSource => $"https://nuget.pkg.github.com/{GitHubActions.GitHubRepositoryOwner}/index.json";
    string Source => IsOriginalRepository ? NuGetPackageSource : GitHubPackageSource;

    [Parameter] private readonly string NuGetApiKey;

    private Target Clean => _ => _
         .Before(Restore)
         .Executes(() =>
         {
             SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
             TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
             EnsureCleanDirectory(OutputDirectory);
         });

    private Target Restore => _ => _
         .Executes(() =>
         {
             DotNetRestore(s => s
                 .SetProjectFile(Solution));
         });

    private Target Compile => _ => _
         .DependsOn(Restore)
         .Executes(() =>
         {
             DotNetBuild(s => s
                 //.SetProjectFile(Solution)
                 .SetProjectFile(SourceDirectory / "KimaiDotNet.Core")
                 .SetConfiguration(Configuration)
                 .SetAssemblyVersion(GitVersion.AssemblySemVer)
                 .SetFileVersion(GitVersion.AssemblySemFileVer)
                 .SetInformationalVersion(GitVersion.InformationalVersion)
                 .EnableNoRestore());
         });

    [Partition(2)] readonly Partition TestPartition;
    AbsolutePath TestResultDirectory => OutputDirectory / "test-results";
    IEnumerable<Project> TestProjects => TestPartition.GetCurrent(Solution.GetProjects("*.Tests"));
    Target Test => _ => _
            .DependsOn(Compile)
            .Produces(TestResultDirectory / "*.trx")
            .Produces(TestResultDirectory / "*.xml")
            .Partition(2)
            .Executes(() =>
            {
                DotNetTest(_ => _
                    .SetConfiguration(Configuration)
                    .SetFilter("Category=Unit")
                    .SetNoBuild(InvokedTargets.Contains(Compile))
                    .ResetVerbosity()
                    .SetResultsDirectory(TestResultDirectory)
                    .When(InvokedTargets.Contains(Coverage) || IsServerBuild, _ => _
                        .EnableCollectCoverage()
                        .SetCoverletOutputFormat(CoverletOutputFormat.cobertura)
                        .SetExcludeByFile("*.Generated.cs")
                        .When(IsServerBuild, _ => _
                            .EnableUseSourceLink()))
                    .CombineWith(TestProjects, (_, v) => _
                        .SetProjectFile(v)
                        .SetLogger($"trx;LogFileName={v.Name}.trx")
                        .SetCoverletOutput(TestResultDirectory / $"{v.Name}.xml")));

                TestResultDirectory.GlobFiles("*.trx").ForEach(x =>
                    AzurePipelines?.PublishTestResults(
                        type: AzurePipelinesTestResultsType.VSTest,
                        title: $"{Path.GetFileNameWithoutExtension(x)} ({AzurePipelines.StageDisplayName})",
                        files: new string[] { x }));
            });
    string CoverageReportDirectory => OutputDirectory / "coverage-report";
    string CoverageReportArchive => OutputDirectory / "coverage-report.zip";

    Target Coverage => _ => _
        .DependsOn(Test)
        .TriggeredBy(Test)
        .Consumes(Test)
        .Produces(CoverageReportArchive)
        .Executes(() =>
        {
            ReportGenerator(_ => _
                .SetReports(TestResultDirectory / "*.xml")
                .SetReportTypes(ReportTypes.HtmlInline)
                .SetTargetDirectory(CoverageReportDirectory)
                .SetFramework("netcoreapp2.1"));

            TestResultDirectory.GlobFiles("*.xml").ForEach(x =>
                AzurePipelines?.PublishCodeCoverage(
                    AzurePipelinesCodeCoverageToolType.Cobertura,
                    x,
                    CoverageReportDirectory));

            CompressZip(
                directory: CoverageReportDirectory,
                archiveFile: CoverageReportArchive,
                fileMode: FileMode.Create);
        });

    private string ChangelogFile => RootDirectory / "CHANGELOG.md";
    private AbsolutePath PackageDirectory => OutputDirectory / "packages";
    private IReadOnlyCollection<AbsolutePath> PackageFiles => PackageDirectory.GlobFiles("*.nupkg");
    private IEnumerable<string> ChangelogSectionNotes => ExtractChangelogSectionNotes(ChangelogFile);

    private Target Pack => _ => _
         .DependsOn(Compile)
         .Produces(PackageDirectory / "*.nupkg")
         .Executes(() =>
         {
             DotNetPack(_ => _
                 .SetProject(SourceDirectory / "KimaiDotNet.Core/KimaiDotNet.Core.csproj")
                 .SetNoBuild(InvokedTargets.Contains(Compile))
                 .SetConfiguration(Configuration)
                 .SetOutputDirectory(PackageDirectory)
                 .SetVersion(GitVersion.NuGetVersionV2)
                 .SetPackageReleaseNotes(GetNuGetReleaseNotes(ChangelogFile, GitRepository)));
         });

    private Target Publish => _ => _
     .ProceedAfterFailure()
     .DependsOn(Clean, Test, Pack)
     .Consumes(Pack)
     .Requires(() => !NuGetApiKey.IsNullOrEmpty() || !IsOriginalRepository)
     .Requires(() => GitHasCleanWorkingCopy())
     .Requires(() => Configuration.Equals(Configuration.Release))
     .Requires(() => IsOriginalRepository && GitRepository.IsOnMainBranch() ||
                     IsOriginalRepository && GitRepository.IsOnReleaseBranch() ||
                     !IsOriginalRepository && GitRepository.IsOnDevelopBranch())
     .Executes(() =>
     {
         if (!IsOriginalRepository)
         {
             DotNetNuGetAddSource(_ => _
                 .SetSource(GitHubPackageSource)
                 .SetUsername(GitHubActions.GitHubActor)
                 .SetPassword(GitHubToken));
         }

         Assert(PackageFiles.Count == 1, "packages.Count == 1");

         DotNetNuGetPush(_ => _
                 .SetSource(Source)
                 .SetApiKey(NuGetApiKey)
                 .CombineWith(PackageFiles, (_, v) => _
                     .SetTargetPath(v)),
             degreeOfParallelism: 5,
             completeOnFailure: true);
     });
}