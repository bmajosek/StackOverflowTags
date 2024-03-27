using Microsoft.Extensions.Caching.Memory;
using StackOverflowTag.Class.Model;
using StackOverflowTag.Services.Interface;

namespace StackOverflowTag.Services
{
    public class TagCacheService : ITagCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public TagCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void CacheTags(IEnumerable<Tag> tags)
        {
            float sumOfCounts = tags.Sum(x => x.Count);
            var updatedTags = tags.Select(x => { x.Percentage = x.Count / sumOfCounts; return x; }).ToList();
            _memoryCache.Set(GlobalVariables.TagsKey, updatedTags);
        }
    }
}