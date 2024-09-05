using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qel.Common.Console.Hosting.QueueService;

namespace Qel.Common.Console.Hosting;

public static class HostExtensions
{
    public static async Task DelayAndReportAsync(this IHost app)
    {
        var services = app.Services.GetRequiredService<IEnumerable<IHostedService>>();

        // Ensure app started...
        //TODO: сделать более явную логику обработки старта приложения
        await Task.Delay(500);

        foreach(var service in services)
        {
            if (service != null)
            {
                //await service.;
            }
        }
        
    }

    public static async Task RunWithMonitorLoopAsync(this IHost app)
    {
        MonitorLoop monitorLoop = app.Services.GetRequiredKeyedService<MonitorLoop>("Loop");
        monitorLoop.StartMonitorLoop();
        await app.RunAsync();
    }
}
