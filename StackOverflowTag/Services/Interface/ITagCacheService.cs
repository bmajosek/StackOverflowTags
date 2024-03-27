using StackOverflowTag.Class.Model;

namespace StackOverflowTag.Services.Interface
{
    public interface ITagCacheService
    {
        void CacheTags(IEnumerable<Tag> tags);
    }
}