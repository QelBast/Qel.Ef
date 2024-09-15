using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Qel.Ef.Contexts.Bases;

public abstract class MyCustomDbContextBase : DbContext
{
    public MyCustomDbContextBase(IConfiguration configuration)
    {
        Configuration = configuration;
        EntityConfigurationsAssembly = configuration["EntityConfigurationsAssemblyPath"];
    }

    IConfiguration Configuration { get; set; }

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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.LoadFrom(EntityConfigurationsAssembly + ".dll"));
        }
        
        base.OnModelCreating(modelBuilder);
    }
}