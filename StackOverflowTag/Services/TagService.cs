using Microsoft.Extensions.Caching.Memory;
using Serilog;
using StackOverflowTag.Class.DTO;
using StackOverflowTag.Services.Interface;
using System.Text.Json;

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