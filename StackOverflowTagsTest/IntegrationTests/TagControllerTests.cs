using Microsoft.AspNetCore.Mvc.Testing;

namespace StackOverflowTagsTest.IntegrationTests
{
    public class TagControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TagControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Trait("Category", "IntegrationTest")]
        [Theory]
        [InlineData(1, 10)] // Valid scenario
        [InlineData(-1, 10)] // Invalid page
        [InlineData(1, -10)] // Invalid pageSize
        public async Task Get_CheckDiffrentScenarios_ReturnsExpectedResult(int page, int pageSize)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync($"/api/tag?page={page}&pageSize={pageSize}");

            //Assert
            if (page >= 0 && pageSize > 0)
            {
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            }
            else
            {
                Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Trait("Category", "IntegrationTest")]
        [Theory]
        [InlineData(100)] // Valid amount
        [InlineData(-1)] // Invalid amount
        public async Task RetrieveTags_CheckDiffrentScenarios_ReturnsExpectedResult(int amount)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.PostAsync($"/api/Tag/retrieve?amount={amount}", null);

            //Assert
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