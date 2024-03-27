using StackOverflowTag.Class.Model;

namespace StackOverflowTag.Services.Interface
{
    public interface ITagApiService
    {
        Task<IEnumerable<Tag>?> FetchTagsFromPage(int amount);
    }
}