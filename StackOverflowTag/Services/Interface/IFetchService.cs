namespace StackOverflowTag.Services.Interface
{
    public interface IFetchService
    {
        Task FetchTags(int amount);
    }
}