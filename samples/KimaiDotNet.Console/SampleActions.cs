using MarkZither.KimaiDotNet;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

using System;
using System.Net.Http;
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
        public async Task<int> GetVersion()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-AUTH-USER", _sampleOptions.UserName);
            httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", _sampleOptions.Password);
            var adapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);
            adapter.BaseUrl = _sampleOptions.BaseUrl;
            var client = new KimaiClient(adapter);

            var version = await client.Api.Version.GetAsync();

            System.Console.WriteLine($"Version: {version?.Version}");
            System.Console.WriteLine($"Version Id: {version?.VersionId}");
            System.Console.WriteLine($"Copyright: {version?.Copyright}");
            _logger.LogInformation(1000, "Calling Get Version as: {userName}", _sampleOptions.UserName);
            return 0;
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
