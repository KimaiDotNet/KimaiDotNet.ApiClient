using MarkZither.KimaiDotNet.Core.Tests.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

using System;
using System.IO;
using System.Net.Http;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    public class TestBase
    {
        internal KimaiClient Client;
        internal KimaiApiOptions configuration;
        public TestBase()
        {
            configuration = TestHelper.GetApplicationConfiguration(Directory.GetCurrentDirectory());
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration.Password}");
            var adapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);
            adapter.BaseUrl = configuration.Url;
            Client = new KimaiClient(adapter);
        }
        internal KimaiClient CreateKimaiClient()
        {
            return Client;
        }
    }
}
