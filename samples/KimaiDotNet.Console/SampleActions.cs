using MarkZither.KimaiDotNet;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KimaiDotNet.Console
{
    public class KimaiAPIActions : IKimaiAPIActions
    {
        private readonly ILogger _logger;
        private readonly SampleOptions _sampleOptions;
        public KimaiAPIActions(ILoggerFactory loggerFactory, IOptions<SampleOptions> sampleOptions)
        {
            _logger = loggerFactory.CreateLogger(typeof(KimaiAPIActions));
            _sampleOptions = sampleOptions.Value;
        }
        public Task<int> GetVersion()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_sampleOptions.BaseUrl);
            client.DefaultRequestHeaders.Add("X-AUTH-USER", _sampleOptions.UserName);
            client.DefaultRequestHeaders.Add("X-AUTH-TOKEN", _sampleOptions.Password);

            Kimai2APIDocs docs = new Kimai2APIDocs(client, false);
            var version = docs.VersionMethod();

            System.Console.WriteLine($"Version Name: {version.Name}");
            System.Console.WriteLine($"Version Semver: {version.Semver}");
            System.Console.WriteLine($"Version Property: {version.VersionProperty}");
            _logger.LogInformation(1000, "Calling Get Version as: {userName}", _sampleOptions.UserName);
            _logger.LogDebug(1000, "Got {translations} translations from the database ", 2);
            return Task.FromResult(0);
        }
    }

    public interface IKimaiAPIActions
    {
        /// <summary>
        /// Get the version details
        /// </summary>
        /// <returns></returns>
        public Task<int> GetVersion();
    }
}
