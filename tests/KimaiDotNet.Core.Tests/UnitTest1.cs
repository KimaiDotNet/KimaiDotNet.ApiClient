using System;

using Xunit;

namespace KimaiDotNet.Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Test2()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Test3()
        {
            Assert.True(true);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Test4()
        {
            Assert.True(true);
        }
    }
}
