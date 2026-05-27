using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    public class KimaiClientTestsDefault : TestBase
    {
        public KimaiClientTestsDefault() : base() { }

        [Fact]
        public async Task GetTimesheetConfig_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act & Assert
            Assert.True(false); // placeholder - needs live Kimai instance
        }

        [Fact]
        public async Task Ping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act & Assert
            Assert.True(false); // placeholder - needs live Kimai instance
        }

        [Fact]
        public async Task GetVersion_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Version.GetAsync();

            // Assert
            Assert.True(false); // placeholder - update assertion when connected to live instance
        }
    }
}
