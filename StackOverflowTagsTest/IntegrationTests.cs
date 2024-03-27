using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowTagsTest
{
    public class TagControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TagControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData(1, 10)] // Valid scenario
        [InlineData(-1, 10)] // Invalid page
        [InlineData(1, -10)] // Invalid pageSize
        public async Task Get_CheckDiffrentScenarios_ReturnsExpectedResult(int page, int pageSize)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"/api/tag?page={page}&pageSize={pageSize}");

            if (page >= 0 && pageSize > 0)
            {
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            }
            else
            {
                Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Theory]
        [InlineData(100)] // Valid amount
        [InlineData(-1)] // Invalid amount
        public async Task RetrieveTags_CheckDiffrentScenarios_ReturnsExpectedResult(int amount)
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync($"/api/Tag/retrieve?amount={amount}", null);

            if (amount > 0)
            {
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                var content = await response.Content.ReadAsStringAsync();
                Assert.Contains("Tags are fetched.", content);
            }
            else
            {
                Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            }
        }
    }
}