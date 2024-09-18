using Microsoft.Extensions.DependencyInjection;
using Qel.Common.Console.Hosting;
using Qel.Common.Console.Hosting.RabbitMq;
using Qel.Ef.Contexts.Main;

namespace Qel.Ef.Test.ConsoleApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = HostRabbitMqUtils.PackRabbitMqQueueConsoleApplicationHost<MessageProcesser, string>(args);
        
        builder.Services
            .AddDbContext<DbContextMain>()
            .AddDbContextFactory<DbContextMain>();
        
        builder
        .Build()
        .RunWithMonitorLoopAsync()
        .Wait();
    }
}