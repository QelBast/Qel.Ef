using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qel.Ef.Providers.Common;

namespace Qel.Ef.DbClient.Extensions;

public static class DbContextServiceCollectionExtensions
{
    public static IServiceCollection AddRepository<TIRepository, TRepository, TContext>(
        this IServiceCollection services, 
        IConfiguration configuration, 
        IEnumerable<IProviderConfigurator> providerConfigurators)
        
        where TIRepository : class
        where TRepository : class, TIRepository
        where TContext : DbContext
    {
        return services.AddTransient<TIRepository, TRepository>()
            .AddPooledDbContextFactory<TContext>(builder => 
                {
                    var section = JsonSerializer.Deserialize<RepositoryOptions>(
                        configuration.GetRequiredSection($"{typeof(TContext).Name}{typeof(TRepository).Name}").ToString() ?? string.Empty) 
                        ?? new() { ContextDbProvider = "Postgres" };
                    builder.EnableDetailedErrors(section.DetailedErrors)
                        .EnableSensitiveDataLogging(section.SensitiveDataLogging)
                        .EnableServiceProviderCaching(section.ServiceProviderCaching)
                        .EnableThreadSafetyChecks(section.ThreadSafetyChecks);
                    var providerConfiguredOptions = 
                    builder = new ProviderSelector(providerConfigurators).SelectProvider(
                        repositoryName: typeof(TContext).Name,
                        builder: builder,
                        config: configuration);
                }
            );
    }

    public static IServiceCollection AddRepositories<TContext>(
        this IServiceCollection services,
        string key,
        IConfiguration configuration,
        IEnumerable<IProviderConfigurator> providerConfigurators,
        Action<IRepositoryRegistration<TContext>> registerRepositories)
        where TContext : DbContext
    {
        services.AddPooledDbContextFactory<TContext>(builder => 
            {
                var section = JsonSerializer.Deserialize<RepositoryOptions>(
                    configuration.GetRequiredSection($"{typeof(TContext).Name}{key}").ToString() ?? string.Empty) 
                    ?? new() { ContextDbProvider = "Postgres" };
                builder.EnableDetailedErrors(section.DetailedErrors)
                    .EnableSensitiveDataLogging(section.SensitiveDataLogging)
                    .EnableServiceProviderCaching(section.ServiceProviderCaching)
                    .EnableThreadSafetyChecks(section.ThreadSafetyChecks);
                var providerConfiguredOptions = 
                builder = new ProviderSelector(providerConfigurators).SelectProvider(
                    repositoryName: typeof(TContext).Name,
                    builder: builder,
                    config: configuration);
            }
        );
        var registration = new RepositoryRegistration<TContext>(services);
        registerRepositories(registration);

        return services;
    }
}