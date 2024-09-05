using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Qel.Api.Transport;
using Qel.Common.Console.Hosting.Generic;

namespace Qel.Common.Console.Hosting.QueueService;

public sealed class MonitorLoop(
    IBackgroundTaskQueue taskQueue,
    ILogger<MonitorLoop> logger,
    IHostApplicationLifetime applicationLifetime,
    ITransportRouter router,
    MonitorLoopOptions options)
{
    private readonly CancellationToken _cancellationToken = applicationLifetime.ApplicationStopping;
    private readonly MonitorLoopOptions _options = options;

    public void StartMonitorLoop()
    {
        logger.LogInformation($"{nameof(MonitorAsync)} loop is starting.");

        // Run a console user input loop in a background thread
        Task.Run(async () => await MonitorAsync());
    }

    private async ValueTask MonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            await taskQueue.QueueBackgroundWorkItemAsync(BuildWorkItemAsync);
        }
    }

    private async ValueTask BuildWorkItemAsync(CancellationToken token)
    {
        var guid = Guid.NewGuid();

        logger.LogInformation("Queued work item {Guid} is starting.", guid);
        
        while (!token.IsCancellationRequested)
        {
            try
            {
                await router.AllRouteWithOneConnection(token);
                token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException ex)
            {
                LogProcessCancellation(ex);
            }

            logger.LogInformation("Queued work item {Guid} is running.", guid);
        }

        logger.LogInformation("Queued Background Task {Guid} is complete.", guid);
    }

    private void LogProcessCancellation(OperationCanceledException ex)
    {
        logger.BeginScope("Отмена выполнения");
        logger.LogError("Возникло исключение {ex}", ex.Message);
        logger.LogTrace("{}", ex.StackTrace);
    }
}
