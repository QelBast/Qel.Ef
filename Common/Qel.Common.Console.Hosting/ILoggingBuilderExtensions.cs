using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Qel.Common.Console.Hosting;

public static class ILoggingBuilderExtensions
{
    public static ILoggingBuilder AddMyLoggingBuilderConfigures<T>(this ILoggingBuilder builder)
    {
        return builder
            .AddConsole(o =>
            {

            })
            .AddOpenTelemetry(o =>
            {
                
            })
            .AddEventSourceLogger();
    }
}
