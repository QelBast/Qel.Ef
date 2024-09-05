using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Qel.Common.Console.Hosting;

public abstract class HostedCustomConsoleService<T>(
    ILogger<T> logger,
    HealthCheckService health,
    IHostApplicationLifetime lifetime) : BackgroundService
{
    protected virtual ILogger<T> Logger { get; set; } = logger;
    protected virtual HealthCheckService HealthService { get; set; } = health;
    protected virtual IHostApplicationLifetime Lifetime { get; set; } = lifetime;
}
