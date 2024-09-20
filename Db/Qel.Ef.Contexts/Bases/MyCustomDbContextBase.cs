using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Qel.Ef.Contexts.Bases;

public abstract class MyCustomDbContextBase : DbContext
{
    const string prefixPath = "bin/Debug/net9.0/";
    public MyCustomDbContextBase(IConfiguration configuration)
    {
        EntityConfigurationsAssembly = configuration["EntityConfigurationsAssemblyPath"];
    }

    string? EntityConfigurationsAssembly { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableDetailedErrors()
        .EnableSensitiveDataLogging()
        .EnableServiceProviderCaching()
        .EnableThreadSafetyChecks();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if(EntityConfigurationsAssembly is not null)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.LoadFrom(Path.Combine($"{prefixPath}", $"{EntityConfigurationsAssembly}.dll")));
        }
        
        base.OnModelCreating(modelBuilder);
    }
}