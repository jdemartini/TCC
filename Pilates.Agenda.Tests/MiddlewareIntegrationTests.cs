using Pilates.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pilates.Agenda.Tests
{
    public class MiddlewareIntegrationTests : IClassFixture<GlobalHooks<Startup>>
    {
        public MiddlewareIntegrationTests(GlobalHooks<Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Theory]
        [InlineData("GET")]
        [InlineData("HEAD")]
        [InlineData("POST")]
        public async Task AllMethods_RemovesServerHeader(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/");

            // Act
            var response = await Client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("Test response", content);
            Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        }
    }
}
