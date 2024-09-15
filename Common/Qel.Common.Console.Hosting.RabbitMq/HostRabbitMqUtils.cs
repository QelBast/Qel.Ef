using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qel.Api.Transport;
using Qel.Api.Transport.RabbitMq.Client;
using Qel.Api.Transport.RabbitMq.Client.Models;
using Qel.Common.Console.Hosting.QueueService;

namespace Qel.Common.Console.Hosting.RabbitMq;

public static class HostRabbitMqUtils
{
    public static HostApplicationBuilder PackRabbitMqQueueConsoleApplicationHost<TProcesser, TMessage>(string[] args)
        where TProcesser : class, IMessageProcesser<TMessage>
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Logging.AddMyLoggingBuilderConfigures<CustomQueuedHostedService>();
        builder.Configuration.AddMyStandartConfigureProviders();

        builder.Services.AddCustomQueryConsoleServices(
            configuration: builder.Configuration,
            loggings: builder.Logging)
            .AddTransient<ITransportRouter, Router<TMessage>>()
            .AddTransient<IMessageProcesser<TMessage>, TProcesser>()
            .AddHostedService<CustomQueuedHostedService>();
        //builder.Metrics.
        var senderOps = builder.Configuration.GetSection(nameof(SenderOptions));
        var receiverOps = builder.Configuration.GetSection(nameof(ReceiverOptions));
        builder.Services.Configure<SenderOptions>(senderOps)
            .Configure<ReceiverOptions>(receiverOps);
        return builder;
    }

    /// <summary>
    /// Построить воркер приложение в связке с RabbitMQ
    /// </summary>
    /// <typeparam name="TProcesser">Класс обработки полученного сообщения</typeparam>
    /// <typeparam name="TMessage"></typeparam>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IHost BuildRabbitMqQueueConsoleApplicationHost<TProcesser, TMessage>(string[] args)
        where TProcesser : class, IMessageProcesser<TMessage>
    {
        var builder = PackRabbitMqQueueConsoleApplicationHost<TProcesser, TMessage>(args);

        return builder.Build();
    }

    
    private static void DefineDbContext<TBaseContext, TContext>(HostApplicationBuilder builder) 
        where TContext : TBaseContext
        where TBaseContext : DbContext
    {
        builder.Services.AddDbContextPool<TBaseContext, TContext>(options =>
        {
            
        });
    }

    public static async Task RunRabbitMqQueueConsoleApplicationHost<TProcesser, TMessage, TContext>(string[] args)
        where TProcesser : class, IMessageProcesser<TMessage>
    {
        IHost app = BuildRabbitMqQueueConsoleApplicationHost<TProcesser, TMessage>(args);
        await app.RunWithMonitorLoopAsync();
    }

}
