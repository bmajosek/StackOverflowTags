using StackOverflowTag.Services;
using Microsoft.Extensions.Caching.Memory;
using StackOverflowTag.Class.Model;
using StackOverflowTag;

namespace StackOverflowTagsTest
{
    public class TagRepositoryTests
    {
        private readonly TagRepository _tagRepository;
        private readonly MemoryCache _memoryCache;

        public TagRepositoryTests()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _tagRepository = new TagRepository(_memoryCache);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task GetPaginationTags_CheckIfProperlyReturns_ReturnsPaginatedSortedTags()
        {
            // Arrange
            var tags = new List<Tag>
                {
                    new() { Name = "tag_c", Count = 600, Percentage = 0.6f },
                    new() { Name = "tag_a", Count = 100, Percentage = 0.1f },
                    new() { Name = "tag_b", Count = 300, Percentage = 0.3f }
                };

            _memoryCache.Set(GlobalVariables.TagsKey, tags);

            // Act
            var result = await _tagRepository.GetPaginationTags(0, 2, GlobalVariables.Fields.Name, false);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("tag_a", resultList[0].Name);
            Assert.Equal("tag_b", resultList[1].Name);
        }
    }
}