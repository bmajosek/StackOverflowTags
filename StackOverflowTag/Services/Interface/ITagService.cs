namespace StackOverflowTag.Services.Interface
{
    public interface ITagService : IHostedService
    {
        Task StartAsync(CancellationToken cancellationToken);

        Task StopAsync(CancellationToken cancellationToken);
    }
}