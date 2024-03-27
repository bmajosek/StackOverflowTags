using Microsoft.Extensions.Caching.Memory;
using StackOverflowTag.Class.Model;
using StackOverflowTag.Services.Interface;

namespace StackOverflowTag.Services
{
    public class TagRepository : ITagRepository
    {
        private readonly IMemoryCache _memoryCache;

        public TagRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Tag>?> GetPaginationTags(int page, int pageSize, string sortBy, bool desc)
        {
            var stackOverflowTags = (List<Tag>?)_memoryCache.Get(GlobalVariables.TagsKey);

            IEnumerable<Tag>? sortedTags = sortBy switch
            {
                GlobalVariables.Fields.Name => desc ? stackOverflowTags?.OrderByDescending(x => x.Name) : stackOverflowTags?.OrderBy(x => x.Name),
                GlobalVariables.Fields.Percentage => desc ? stackOverflowTags?.OrderByDescending(x => x.Percentage) : stackOverflowTags?.OrderBy(x => x.Percentage),
                _ => stackOverflowTags
            };

            return sortedTags?.Skip(page * pageSize).Take(pageSize);
        }
    }
}