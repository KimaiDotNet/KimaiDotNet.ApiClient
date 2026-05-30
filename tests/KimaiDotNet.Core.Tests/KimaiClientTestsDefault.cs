using System.IO;
using System.Threading.Tasks;

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    [Trait("Category", "Integration")]
    public class KimaiClientTestsDefault : TestBase
    {
        public KimaiClientTestsDefault() : base() { }

        [Fact]
        public async Task GetTimesheetConfig_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Config.Timesheet.GetAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Ping_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Ping.GetAsync();

            // Assert
            Assert.NotNull(result);
            using var reader = new StreamReader(result);
            var body = await reader.ReadToEndAsync();
            Assert.Contains("pong", body);
        }

        [Fact]
        public async Task GetVersion_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateKimaiClient();

            // Act
            var result = await client.Api.Version.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.Version));
        }
    }
}

