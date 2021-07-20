using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MarkZither.KimaiDotNet.Core.Tests.Configuration;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    public static class TestHelper
    {
        public static IConfiguration GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                    .SetBasePath(outputPath)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddEnvironmentVariables()
                    .AddUserSecrets<TestBase>()
                    .Build();
        }

        public static KimaiApiOptions GetApplicationConfiguration(string outputPath)
        {
            var iConfig = GetIConfigurationRoot(outputPath);

            return (KimaiApiOptions)iConfig.Get(typeof(KimaiApiOptions));
        }
    }
    public sealed class Authorization
    {
        private static readonly Lazy<Authorization>
                lazy =
                new Lazy<Authorization>
                        (() => new Authorization());

        public static Authorization Instance { get { return lazy.Value; } }

        private Authorization()
        {
        }

        public string token;
    }
}