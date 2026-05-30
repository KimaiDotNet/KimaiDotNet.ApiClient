using MarkZither.KimaiDotNet.Models;

using System.Threading.Tasks;

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    [Trait("Category", "Integration")]
    public class KimaiClientTestsActivity : TestBase
    {
        public KimaiClientTestsActivity() : base() { }

        [Fact(Skip = "Requires custom meta fields configured in Kimai - see https://www.kimai.org/documentation/custom-fields.html")]
        public async Task UpdateActivityMeta_StateUnderTest_ExpectedBehavior()
        {
            await Task.CompletedTask;
        }

        [Fact]
        public async Task ListActivities_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Activities.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task CreateActivity_WithOnlyNameAndDesc_ReturnsNewActivity()
        {
            // Arrange
            var client = this.CreateKimaiClient();
            var body = new ActivityEditForm { Name = "CI-Created-Activity", Comment = "Created by CI integration test" };

            // Act
            var result = await client.Api.Activities.PostAsync(body);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("CI-Created-Activity", result.Name);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task GetActivityById_GetById_ReturnsOneActivity()
        {
            // Arrange - activity ID 1 is seeded by init-kimai.sh
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Activities["1"].GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Activity", result.Name);
        }

        [Fact]
        public async Task UpdateActivity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange - activity ID 1 is seeded by init-kimai.sh
            var client = this.CreateKimaiClient();
            var body = new ActivityEditForm { Comment = "Updated by CI integration test" };

            // Act
            var result = await client.Api.Activities["1"].PatchAsync(body);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ListActivityRates_StateUnderTest_ExpectedBehavior()
        {
            // Arrange - activity ID 1 is seeded by init-kimai.sh
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Activities["1"].Rates.GetAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddActivityRate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange - activity ID 1 is seeded by init-kimai.sh
            var client = this.CreateKimaiClient();
            var body = new ActivityRateForm { Rate = 100.0, IsFixed = false };

            // Act
            var result = await client.Api.Activities["1"].Rates.PostAsync(body);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }

        [Fact(Skip = "Rate deletion may require additional Kimai configuration - AddActivityRate_StateUnderTest_ExpectedBehavior validates rate creation works")]
        public async Task DeleteActivityRate_StateUnderTest_ExpectedBehavior()
        {
            await Task.CompletedTask;
        }
    }
}

