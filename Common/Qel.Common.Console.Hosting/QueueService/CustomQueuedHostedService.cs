using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Qel.Common.Console.Hosting.Generic;

namespace Qel.Common.Console.Hosting.QueueService;

public sealed class CustomQueuedHostedService(
    IBackgroundTaskQueue taskQueue,
    ILogger<CustomQueuedHostedService> logger,
    HealthCheckService healthService,
    IHostApplicationLifetime lifetime) : HostedCustomConsoleService<CustomQueuedHostedService>(logger, healthService, lifetime)
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation("""
            {Name} is running.
            Tap W to add a work item to the 
            background queue.
            """,
            nameof(CustomQueuedHostedService));

        return ProcessTaskQueueAsync(stoppingToken);
    }

    private async Task ProcessTaskQueueAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                Func<CancellationToken, ValueTask>? workItem =
                    await taskQueue.DequeueAsync(stoppingToken);

                await workItem(stoppingToken);
            }
            catch (OperationCanceledException)
            {
                // Prevent throwing if stoppingToken was signaled
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred executing task work item.");
            }
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation(
            $"{nameof(CustomQueuedHostedService)} is stopping.");

        await base.StopAsync(stoppingToken);
    }
}
