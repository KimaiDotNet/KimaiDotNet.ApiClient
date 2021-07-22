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
    public class Kimai2APIDocsTestsUser : TestBase
    {
        private HttpClient fakeHttpClient;
        public Kimai2APIDocsTestsUser() : base()
        {
            this.fakeHttpClient = A.Fake<HttpClient>();
        }

        [Fact]
        public async Task GetCurrentUserUsingGetWithHttpMessagesAsync_GetCurrentUser_ReturnsCurrentUser()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetCurrentUserUsingGetWithHttpMessagesAsync(
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(result.Response.IsSuccessStatusCode);
            await Verifier.Verify(result.Body);
        }

        [Fact]
        public async Task ListUsersUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string visible = null;
            string orderBy = null;
            string order = null;
            string term = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListUsersUsingGetWithHttpMessagesAsync(
                visible,
                orderBy,
                order,
                term,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(result.Response.IsSuccessStatusCode);
            Assert.IsType<List<UserCollection>>(result.Body);
        }

        [Fact]
        public async Task CreateUserUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            UserCreateForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateUserUsingPostWithHttpMessagesAsync(
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetUserByIdUsingGetWithHttpMessagesAsync_GetById1_ReturnsJohnUser()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 1;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetUserByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(result.Response.IsSuccessStatusCode);
            await Verifier.Verify(result.Body);
        }

        [Fact]
        public async Task UpdateUserUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            UserEditForm body = null;
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateUserUsingPatchWithHttpMessagesAsync(
                body,
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }
    }
}
