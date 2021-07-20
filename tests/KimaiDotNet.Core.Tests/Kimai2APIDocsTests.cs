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

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    public class Kimai2APIDocsTests
    {
        private HttpClient fakeHttpClient;
        private HttpClient Client;
        private KimaiApiOptions configuration;
        public Kimai2APIDocsTests()
        {
            this.fakeHttpClient = A.Fake<HttpClient>();
            configuration = TestHelper.GetApplicationConfiguration(Directory.GetCurrentDirectory());
            Client = new HttpClient();
            Client.BaseAddress = new Uri(configuration.Url);
            Client.DefaultRequestHeaders.Add("X-AUTH-USER", configuration.Username);
            Client.DefaultRequestHeaders.Add("X-AUTH-TOKEN", configuration.Password);
        }

        private Kimai2APIDocs CreateKimai2APIDocs()
        {
            return new Kimai2APIDocs(
                this.Client, true);
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
        }

        [Fact]
        public async Task CreateActivityUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            ActivityEditForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateActivityUsingPostWithHttpMessagesAsync(
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetActivityByIdUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetActivityByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
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
        public async Task UpdateCustomerMetaUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Body body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateCustomerMetaUsingPatchWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListCustomersUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string visible = null;
            string order = null;
            string orderBy = null;
            string term = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListCustomersUsingGetWithHttpMessagesAsync(
                visible,
                order,
                orderBy,
                term,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task CreateCustomerUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            CustomerEditForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateCustomerUsingPostWithHttpMessagesAsync(
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetCustomerByIdUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string id = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetCustomerByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task UpdateCustomerUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            CustomerEditForm body = null;
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateCustomerUsingPatchWithHttpMessagesAsync(
                body,
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListCustomerRatesUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListCustomerRatesUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task CreateCustomerRateUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            CustomerRateForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateCustomerRateUsingPostWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteCustomerRateUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int rateId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DeleteCustomerRateUsingDeleteWithHttpMessagesAsync(
                id,
                rateId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task UpdateProjectMetaUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Body body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateProjectMetaUsingPatchWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListProjectUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string customer = null;
            string customers = null;
            string visible = null;
            string start = null;
            string end = null;
            string ignoreDates = null;
            string order = null;
            string orderBy = null;
            string term = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListProjectUsingGetWithHttpMessagesAsync(
                customer,
                customers,
                visible,
                start,
                end,
                ignoreDates,
                order,
                orderBy,
                term,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task CreateProjectUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            ProjectEditForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateProjectUsingPostWithHttpMessagesAsync(
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetProjectByIdUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string id = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetProjectByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task UpdateProjectUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            ProjectEditForm body = null;
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateProjectUsingPatchWithHttpMessagesAsync(
                body,
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetProjectRateUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetProjectRateUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task CreateProjectRateUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            ProjectRateForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateProjectRateUsingPostWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteProjectRateUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int rateId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DeleteProjectRateUsingDeleteWithHttpMessagesAsync(
                id,
                rateId,
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

        [Fact]
        public async Task ListTagsUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string name = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListTagsUsingGetWithHttpMessagesAsync(
                name,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task CreateTagUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            TagEditForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateTagUsingPostWithHttpMessagesAsync(
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteTagUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DeleteTagUsingDeleteWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListTeamUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListTeamUsingGetWithHttpMessagesAsync(
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task CreateTeamUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            TeamEditForm body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateTeamUsingPostWithHttpMessagesAsync(
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetTeamByIdUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string id = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetTeamByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task UpdateTeamUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            TeamEditForm body = null;
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateTeamUsingPatchWithHttpMessagesAsync(
                body,
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteTeamUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DeleteTeamUsingDeleteWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task AddTeamMemberUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int userId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.AddTeamMemberUsingPostWithHttpMessagesAsync(
                id,
                userId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteTeamMemberUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int userId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DeleteTeamMemberUsingDeleteWithHttpMessagesAsync(
                id,
                userId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GrantTeamCustomerAccessUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int customerId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GrantTeamCustomerAccessUsingPostWithHttpMessagesAsync(
                id,
                customerId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task RevokeTeamCustomerAccessUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int customerId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.RevokeTeamCustomerAccessUsingDeleteWithHttpMessagesAsync(
                id,
                customerId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GrantTeamProjectAccessUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int projectId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GrantTeamProjectAccessUsingPostWithHttpMessagesAsync(
                id,
                projectId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task RevokeTeamProjectAccessUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int projectId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.RevokeTeamProjectAccessUsingDeleteWithHttpMessagesAsync(
                id,
                projectId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GrantTeamActivityAccessUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int activityId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GrantTeamActivityAccessUsingPostWithHttpMessagesAsync(
                id,
                activityId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task RevokeTeamActivityAccessUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            int activityId = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.RevokeTeamActivityAccessUsingDeleteWithHttpMessagesAsync(
                id,
                activityId,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListUserTimesheetsUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string user = null;
            string begin = null;
            string size = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListUserTimesheetsUsingGetWithHttpMessagesAsync(
                user,
                begin,
                size,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListUsersActiveTimesheetsUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListUsersActiveTimesheetsUsingGetWithHttpMessagesAsync(
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task StopActiveTimesheetRecordUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.StopActiveTimesheetRecordUsingPatchWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task RestartTimesheetUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            BodyModel body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.RestartTimesheetUsingPatchWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DuplicateTimesheetUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DuplicateTimesheetUsingPatchWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task SwitchTimesheetLockUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.SwitchTimesheetLockUsingPatchWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task UpdateTimesheetMetaUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Body body = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateTimesheetMetaUsingPatchWithHttpMessagesAsync(
                id,
                body,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ListTimesheetsRecordsUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            string user = null;
            string customer = null;
            string customers = null;
            string project = null;
            string projects = null;
            string activity = null;
            string activities = null;
            string page = null;
            string size = null;
            string tags = null;
            string orderBy = null;
            string order = null;
            string begin = null;
            string end = null;
            string exported = null;
            string active = null;
            string full = null;
            string term = null;
            string modifiedAfter = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.ListTimesheetsRecordsUsingGetWithHttpMessagesAsync(
                user,
                customer,
                customers,
                project,
                projects,
                activity,
                activities,
                page,
                size,
                tags,
                orderBy,
                order,
                begin,
                end,
                exported,
                active,
                full,
                term,
                modifiedAfter,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task CreateTimesheetRecordUsingPostWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            TimesheetEditForm body = null;
            string full = null;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.CreateTimesheetRecordUsingPostWithHttpMessagesAsync(
                body,
                full,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetTimesheetRecordByIdUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetTimesheetRecordByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task UpdateTimesheetRecordUsingPatchWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            TimesheetEditForm body = null;
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.UpdateTimesheetRecordUsingPatchWithHttpMessagesAsync(
                body,
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteTimesheetRecordUsingDeleteWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.DeleteTimesheetRecordUsingDeleteWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task GetCurrentUserUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
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
            Assert.True(false);
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
            Assert.True(false);
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
        public async Task GetUserByIdUsingGetWithHttpMessagesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kimai2APIDocs = this.CreateKimai2APIDocs();
            int id = 0;
            Dictionary<string, List<string>> customHeaders = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await kimai2APIDocs.GetUserByIdUsingGetWithHttpMessagesAsync(
                id,
                customHeaders,
                cancellationToken);

            // Assert
            Assert.True(false);
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
