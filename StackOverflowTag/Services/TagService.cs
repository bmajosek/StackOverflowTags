using StackOverflowTag.Services.Interface;

namespace StackOverflowTag.Services
{
    public class TagService : ITagService
    {
        private readonly IFetchService _fetchService;

        public TagService(IFetchService fetchService)
        {
            _fetchService = fetchService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _fetchService.FetchTags(GlobalVariables.AmountOfTags);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}