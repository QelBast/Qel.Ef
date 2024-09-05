using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qel.Api.Transport;
using Qel.Api.Transport.RabbitMq.Client;
using Qel.Common.Console.Hosting.QueueService;

namespace Qel.Common.Console.Hosting.RabbitMq;

public static class HostRabbitMqUtils
{
    public static IHost BuildRabbitMqQueueConsoleApplicationHost<T, K>(string[] args) where T : class, IMessageProcesser<K>
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Logging.AddMyLoggingBuilderConfigures<CustomQueuedHostedService>();
        builder.Configuration.AddMyStandartConfigureProviders();

        builder.Services.AddCustomQueryConsoleServices(
            configuration: builder.Configuration, 
            loggings: builder.Logging)
            .AddTransient<ITransportRouter, Router<K>>()
            .AddTransient<IMessageProcesser<K>, T>()
            .AddHostedService<CustomQueuedHostedService>();
        //builder.Metrics.
        
        return builder.Build();
    }

}
