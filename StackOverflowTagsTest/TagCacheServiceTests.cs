using Microsoft.Extensions.Caching.Memory;
using StackOverflowTag.Class.Model;
using StackOverflowTag.Services;
using StackOverflowTag;

namespace StackOverflowTagsTest
{
    public class TagCacheServiceTests
    {
        [Fact]
        public void CacheTags_CheckIfProperlyReturns_CachesTagsWithCorrectPercentage()
        {
            // Arrange
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var service = new TagCacheService(memoryCache);
            var tags = new List<Tag>
                {
                    new() { Count = 400, Name = "tag_a" },
                    new() { Count = 600, Name = "tag_b" }
                };

            // Act
            service.CacheTags(tags);

            // Assert
            var cachedTags = memoryCache.Get<IEnumerable<Tag>>(GlobalVariables.TagsKey);
            Assert.NotNull(cachedTags);
            var cachedTagList = cachedTags.ToList();
            Assert.Equal(2, cachedTagList.Count);
            Assert.Equal(0.4m, Math.Round((decimal)cachedTagList[0].Percentage, 2));
            Assert.Equal(0.6m, Math.Round((decimal)cachedTagList[1].Percentage, 2));
        }
    }
}