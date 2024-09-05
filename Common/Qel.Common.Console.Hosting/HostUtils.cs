using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qel.Common.Console.Hosting.QueueService;

namespace Qel.Common.Console.Hosting;

# warning Подумать как бы вынести это в отдельную репу

public static class HostUtils
{
    public static IHost BuildConsoleHost(string[] args)
        => Host.CreateDefaultBuilder(args)
            .UseConsoleLifetime()
            //.ConfigureLogging()
            .ConfigureServices((context, services) 
                => services.BuildServiceProvider()).Build();

    public static IHost BuildDefaultConsoleApplicationHost(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddCustomDefaultConsoleServices();
        builder.Configuration.AddMyStandartConfigureProviders();
        //builder.Logging.AddMyLoggingBuilderConfigures<T>();
        //builder.Metrics.
        
        return builder.Build();
    }
    public static IHost BuildQueueConsoleApplicationHost(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Logging.AddMyLoggingBuilderConfigures<CustomQueuedHostedService>();
        builder.Configuration.AddMyStandartConfigureProviders();

        builder.Services.AddCustomQueryConsoleServices(
            configuration: builder.Configuration, 
            loggings: builder.Logging)
            .AddHostedService<CustomQueuedHostedService>();
        //builder.Metrics.
        
        return builder.Build();
    }

    public static async Task RunQueueConsoleApplicationHost(string[] args)
    {
        IHost app = BuildQueueConsoleApplicationHost(args);
        await app.RunWithMonitorLoopAsync();
    }

    public static HostBuilderContext GetHostBuilderContext()
    {
        return new HostBuilderContext(new Dictionary<object, object>());
    }
}