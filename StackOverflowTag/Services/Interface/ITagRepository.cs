using StackOverflowTag.Class.DTO;
using StackOverflowTag.Class.Model;

namespace StackOverflowTag.Services.Interface
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetPaginationTags(int page, int pageSize, string sortBy, bool desc);
    }
}