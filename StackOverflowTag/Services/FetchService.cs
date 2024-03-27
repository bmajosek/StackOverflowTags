using StackOverflowTag.Class.Model;
using StackOverflowTag.Services.Interface;

namespace StackOverflowTag.Services
{
    public class FetchService : IFetchService
    {
        private readonly ITagCacheService _tagCacheService;
        private readonly ITagApiService _tagApiService;

        public FetchService(ITagCacheService tagCacheService, ITagApiService tagApiService)
        {
            _tagCacheService = tagCacheService;
            _tagApiService = tagApiService;
        }

        public async Task FetchTags(int amount)
        {
            int page = 1;
            List<Tag?> tagModels = new List<Tag?>();
            while (page * 100 <= amount)
            {
                var tags = await _tagApiService.FetchTagsFromPage(page++);
                tagModels.AddRange(tags);
            }
            _tagCacheService.CacheTags(tagModels);
        }
    }
}