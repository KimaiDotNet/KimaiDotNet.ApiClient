using MarkZither.KimaiDotNet;
using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Rest;

namespace KimaiDotNet.Console
{
    class Program
    {
        static async Task Main(string[] args) => await BuildCommandLine()
                    .UseHost(_ => Host.CreateDefaultBuilder(),
                        host =>
                        {
                            ServiceClientTracing.IsEnabled = true;
                            host.ConfigureAppConfiguration((hostingContext, config) =>
                            {
                                // The next 2 lines commented out as they are added by default in the correct order
                                // for more control first call config.Sources.Clear();
                                //config.AddJsonFile("appsettings.json", optional: true);
                                //config.AddEnvironmentVariables();
                                config.AddUserSecrets<Program>();
                                var configuration = config.Build();

                                if(args is null)
                                {
                                    //add some defaults from config
                                    var username = configuration.GetSection("Sample").GetValue<string>("username");
                                    var password = configuration.GetSection("Sample").GetValue<string>("password");
                                    var baseUrl = configuration.GetSection("Sample").GetValue<string>("baseurl");
                                    args = Array.Empty<string>();
                                    args = args.Append($"-u {username}").ToArray();
                                    args = args.Append($"-p {password}").ToArray();
                                    args = args.Append($"-b {baseUrl}").ToArray();
                                }

                                if (args != null)
                                {
                                    var switchMappings = new Dictionary<string, string>()
                                     {
                                         { "-c", "connectionstrings:mydb" },
                                         { "--connectionString", "connectionstrings:mydb" },
                                     };
                                    config.AddCommandLine(args, switchMappings);
                                }
                            })
                            .ConfigureServices((hostContext, services) =>
                            {
                                //services.AddOptions<SampleOptions>()
                                //    .Bind(hostContext.Configuration.GetSection(SampleOptions.Sample));
                                //services.AddSingleton<IKimaiAPIActions, KimaiAPIActions>();

                            });
                        })
                    .UseDefaults()
                    .Build()
                    .InvokeAsync(args);

        private static CommandLineBuilder BuildCommandLine()
        {
            var root = new RootCommand(@"$ MarkZither.KimaiDotNet.Console.exe --username ""username"" --password ""password"" -u ""http://localhost:8001"""){
                new Option<string>(aliases: new string[] { "--UserName", "-u" }){
                    Description = "The username",
                    IsRequired = true
                },
                new Option<string>(aliases: new string[] { "--password", "-p" }){
                    Description = "The API password of the user",
                    IsRequired = true
                },
                new Option<string>(aliases: new string[] { "--baseurl", "-b" }){
                    Description = "The base address of the Kimai server'",
                    IsRequired = true
                },
            };
            root.Handler = CommandHandler.Create<SampleOptions, IHost>(Run);
            return new CommandLineBuilder(root);
        }

        private static void Run(SampleOptions options, IHost host)
        {
            var serviceProvider = host.Services;
            //var poProcessor = serviceProvider.GetRequiredService<IKimaiAPIActions>();
            //var sampleOption = serviceProvider.GetRequiredService<SampleOptions>();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(typeof(Program));

            var userName = options.UserName;
            var password = options.Password;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(options.BaseUrl);
            client.DefaultRequestHeaders.Add("X-AUTH-USER", userName);
            client.DefaultRequestHeaders.Add("X-AUTH-TOKEN", password);

            Kimai2APIDocs docs = new Kimai2APIDocs(client, false);
            var version = docs.VersionMethod();

            System.Console.WriteLine($"Version Name: {version.Name}");
            System.Console.WriteLine($"Version Semver: {version.Semver}");
            System.Console.WriteLine($"Version Property: {version.VersionProperty}");
            logger.LogInformation(1000, "Calling Get Version as: {userName}", userName);
            //poProcessor.GetVersion();
        }
    }
}
