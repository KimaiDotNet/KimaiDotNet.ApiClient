using MarkZither.KimaiDotNet.Core.Tests.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    public class TestBase
    {
        internal HttpClient Client;
        internal KimaiApiOptions configuration;
        public TestBase()
        {
            configuration = TestHelper.GetApplicationConfiguration(Directory.GetCurrentDirectory());
            Client = new HttpClient();
            Client.BaseAddress = new Uri(configuration.Url);
            Client.DefaultRequestHeaders.Add("X-AUTH-USER", configuration.Username);
            Client.DefaultRequestHeaders.Add("X-AUTH-TOKEN", configuration.Password);
        }
        internal Kimai2APIDocs CreateKimai2APIDocs()
        {
            return new Kimai2APIDocs(
                this.Client, true);
        }
    }
}
