using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
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
            await Verifier.Verify(result);
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
            await Verifier.Verify(result);
        }

        [Fact]
        public async Task GetUserById_GetById_ReturnsUser()
        {
            // Arrange
            var client = this.CreateKimaiClient();
            int id = 1;

            // Act
            var result = await client.Api.Users[id.ToString()].GetAsync();

            // Assert
            Assert.NotNull(result);
            await Verifier.Verify(result);
        }
    }
}
