using Serilog;
using StackOverflowTag.Class.DTO;
using StackOverflowTag.Class.Model;
using StackOverflowTag.Services.Interface;
using System.Text.Json;

namespace StackOverflowTag.Services
{
    public class TagApiService : ITagApiService
    {
        private readonly HttpClient _client;

        public TagApiService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("StackOverflowClient");
        }

        public async Task<IEnumerable<Tag>?> FetchTagsFromPage(int page)
        {
            try
            {
                var url = $"https://api.stackexchange.com/2.3/tags?page={page}&pagesize=100&order=desc&sort=popular&site=stackoverflow&filter=!)sAz6H(B0HuPN5)OO3Rt";
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                TagResponse tagResponse = JsonSerializer.Deserialize<TagResponse>(responseBody);

                return tagResponse?.items.Select(x => new Tag() { Count = x.count, Name = x.name }) ?? Enumerable.Empty<Tag>();
            }
            catch (HttpRequestException e)
            {
                Log.Information("\nException Caught!");
                Log.Information("Message :{0} ", e.Message);
            }
            return null;
        }
    }
}