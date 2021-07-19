using MarkZither.KimaiDotNet.Models;
using NSubstitute;
using System;
using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests.Models
{
    public class ActivityTests
    {


        public ActivityTests()
        {

        }

        private Activity CreateActivity()
        {
            return new Activity();
        }

        [Fact]
        public void Validate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var activity = this.CreateActivity();
            activity.Name = "testActivity";

            // Act
            activity.Validate();

            // Assert
            Assert.Equal("testActivity", activity.Name);
        }
    }
}
