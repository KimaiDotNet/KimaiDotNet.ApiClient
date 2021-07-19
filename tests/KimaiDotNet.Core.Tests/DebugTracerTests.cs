using FakeItEasy;

using MarkZither.KimaiDotNet.Core;

using System;
using System.Collections.Generic;
using System.Net.Http;

using Xunit;

namespace MarkZither.KimaiDotNet.Core.Tests
{
    public class DebugTracerTests
    {


        public DebugTracerTests()
        {

        }

        private DebugTracer CreateDebugTracer()
        {
            return new DebugTracer();
        }

        [Fact]
        public void Information_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugTracer = this.CreateDebugTracer();
            string message = null;

            // Act
            debugTracer.Information(
                message);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void TraceError_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugTracer = this.CreateDebugTracer();
            string invocationId = null;
            Exception exception = null;

            // Act
            debugTracer.TraceError(
                invocationId,
                exception);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void ReceiveResponse_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugTracer = this.CreateDebugTracer();
            string invocationId = null;
            HttpResponseMessage response = null;

            // Act
            debugTracer.ReceiveResponse(
                invocationId,
                response);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void SendRequest_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugTracer = this.CreateDebugTracer();
            string invocationId = null;
            HttpRequestMessage request = null;

            // Act
            debugTracer.SendRequest(
                invocationId,
                request);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void Configuration_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugTracer = this.CreateDebugTracer();
            string source = null;
            string name = null;
            string value = null;

            // Act
            debugTracer.Configuration(
                source,
                name,
                value);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void EnterMethod_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugTracer = this.CreateDebugTracer();
            string invocationId = null;
            object instance = null;
            string method = null;
            IDictionary<string, object> parameters = null;

            // Act
            debugTracer.EnterMethod(
                invocationId,
                instance,
                method,
                parameters);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void ExitMethod_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugTracer = this.CreateDebugTracer();
            string invocationId = null;
            object returnValue = null;

            // Act
            debugTracer.ExitMethod(
                invocationId,
                returnValue);

            // Assert
            Assert.True(true);
        }
    }
}
