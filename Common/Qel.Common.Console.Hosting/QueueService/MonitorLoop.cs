using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Qel.Api.Transport;
using Qel.Common.Console.Hosting.Generic;

namespace Qel.Common.Console.Hosting.QueueService;

public sealed class MonitorLoop(
    IBackgroundTaskQueue taskQueue,
    ILogger<MonitorLoop> logger,
    IHostApplicationLifetime applicationLifetime,
    ITransportRouter router,
    IOptions<MonitorLoopOptions> options)
{
    private readonly CancellationToken _cancellationToken = applicationLifetime.ApplicationStopping;
    private readonly MonitorLoopOptions _options = options.Value;

    /// <summary>
    /// Run a console user input loop in a background thread
    /// </summary>
    public void StartMonitorLoop()
    {
        switch (_options.Mode)
        {
            case "Auto":
                logger.LogInformation($"{nameof(AutoMonitorAsync)} loop is starting.");
                Task.Run(async () => await AutoMonitorAsync());
                break;
            case "Semi":
                logger.LogInformation($"{nameof(SemiMonitorAsync)} loop is starting.");
                Task.Run(async () => await SemiMonitorAsync());
                break;
            case "Single":
                logger.LogInformation($"{nameof(SingleMonitorAsync)} loop is starting.");
                Task.Run(async () => await SingleMonitorAsync());
                break;
        }
        
    }

    private async ValueTask AutoMonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            await taskQueue.QueueBackgroundWorkItemAsync(BuildWorkItemAsync);
        }
    }
    private async ValueTask SemiMonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            await taskQueue.QueueBackgroundWorkItemAsync(BuildWorkItemAsync);
        }
    }
    private async ValueTask SingleMonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            var keyStroke = System.Console.ReadKey();
            if (keyStroke.Key == ConsoleKey.Spacebar)
            { 
                // Enqueue a background work item
                await taskQueue.QueueBackgroundWorkItemAsync(BuildWorkItemAsync);
            }
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
