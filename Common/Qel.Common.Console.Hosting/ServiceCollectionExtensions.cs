using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Qel.Common.Console.Hosting.Generic;
using Qel.Common.Console.Hosting.QueueService;

namespace Qel.Common.Console.Hosting;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomDefaultConsoleServices(this IServiceCollection services, params ILoggingBuilder[] loggings)
    {

        foreach(var logging in loggings)
        {
            services
                .AddLogging(x => x = logging);
        }

        services.AddCustomDefaultHealthChecks();


            //.TryAddKeyedTransient<>("");
        return services;
    }

    public static IServiceCollection AddCustomQueryConsoleServices(this IServiceCollection services, IConfigurationManager configuration, params ILoggingBuilder[] loggings)
    {

        services.AddCustomDefaultConsoleServices()
            .AddKeyedSingleton<MonitorLoop>("Loop")
            .AddSingleton<IBackgroundTaskQueue>(_ =>
            {
                if (!int.TryParse(configuration["QueueCapacity"], out var queueCapacity))
                {
                    queueCapacity = 100;
                }

                return new DefaultCustomBackgroundTaskQueue(queueCapacity);
            });
        return services;
    }

    public static IServiceCollection AddCustomDefaultHealthChecks(this IServiceCollection services)
    {
        services
            .AddResourceMonitoring()
            .AddHealthChecks()
                .AddResourceUtilizationHealthCheck()
                .AddApplicationLifecycleHealthCheck();
        
        return services;
    }
}
