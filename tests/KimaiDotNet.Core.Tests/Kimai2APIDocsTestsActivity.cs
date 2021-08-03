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
#pragma warning disable xUnit1000 // Test classes must be public
    class Kimai2APIDocsTestsActivity : TestBase
#pragma warning restore xUnit1000 // Test classes must be public
    {
        private HttpClient fakeHttpClient;
        public Kimai2APIDocsTestsActivity() : base()
        {
            this.fakeHttpClient = A.Fake<HttpClient>();
        }

        [Fact]
        public async Task UpdateActivityMetaUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Body body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateActivityMetaUsingPatchWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListActivitiesUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string project = null;
            string projects = null;
            string visible = null;
            string globals = null;
            string globalsFirst = null;
            string orderBy = null;
            string order = null;
            string term = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListActivitiesUsingGetWithHttpMessagesAsync(
                project,
                projects,
                visible,
                globals,
                globalsFirst,
                orderBy,
                order,
                term,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(result.Response.IsSuccessStatusCode);
            await Verifier.Verify(result.Body);
        }

        [Fact]
        public async Task CreateActivityUsingPostWithHttpMessagesAsync_WithOnlyNameAndDesc_ReturnsNewActivity()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            ActivityEditForm body = new ActivityEditForm("TestActivity", "MarkTest");
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateActivityUsingPostWithHttpMessagesAsync(
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(result.Response.IsSuccessStatusCode);
            await Verifier.Verify(result.Body);
        }

        [Fact]
        public async Task GetActivityByIdUsingGetWithHttpMessagesAsync_GetById_ReturnsOneActivity()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 862;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetActivityByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(result.Response.IsSuccessStatusCode);
            await Verifier.Verify(result.Body);
        }

        [Fact]
        public async Task UpdateActivityUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            ActivityEditForm body = null;
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateActivityUsingPatchWithHttpMessagesAsync(
                body,
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListActivityRatesUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListActivityRatesUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task AddActivityRateUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            ActivityRateForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.AddActivityRateUsingPostWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteActivityRateUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int rateId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DeleteActivityRateUsingDeleteWithHttpMessagesAsync(
                id,
                rateId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }
    }
}
