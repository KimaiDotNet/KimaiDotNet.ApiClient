using System.Threading.Tasks;

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    [Trait("Category", "Integration")]
    public class KimaiClientTestsUser : TestBase
    {
        public KimaiClientTestsUser() : base() { }

        [Fact]
        public async Task GetCurrentUser_ReturnsCurrentUser()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Users.Me.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("kimai-admin", result.Username);
        }

        [Fact]
        public async Task ListUsers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Users.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetUserById_GetById_ReturnsUser()
        {
            // Arrange - admin user has ID 1 on a fresh container
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Users["1"].GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("kimai-admin", result.Username);
        }
    }
}

