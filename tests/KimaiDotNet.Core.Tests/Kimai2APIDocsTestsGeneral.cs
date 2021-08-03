using FakeItEasy;

using MarkZither.KimaiDotNet;
using MarkZither.KimaiDotNet.Core.Tests.Configuration;
using MarkZither.KimaiDotNet.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    [UsesVerify]
    public class Kimai2APIDocsTestsDefault : TestBase
    {
        private HttpClient fakeHttpClient;
        public Kimai2APIDocsTestsDefault() : base()
        {
            this.fakeHttpClient = A.Fake<HttpClient>();
        }
        public class MessageHandler1 : DelegatingHandler
        {
            protected async override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Debug.WriteLine("Process request");
                // Call the inner handler.
                var response = await base.SendAsync(request, cancellationToken);
                Debug.WriteLine("Process response");
                return response;
            }
        }

        [Fact]
        public async Task GetCurrentUserLocaleUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetCurrentUserLocaleUsingGetWithHttpMessagesAsync(
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }
        [Fact]
        public async Task GetTimesheetConfigUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetTimesheetConfigUsingGetWithHttpMessagesAsync(
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }
        [Fact]
        public async Task PingWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.PingWithHttpMessagesAsync(
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }
        [Fact]
        public async Task VersionMethodWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.VersionMethodWithHttpMessagesAsync(
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }
    }
}
