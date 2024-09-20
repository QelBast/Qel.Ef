using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Qel.Ef.Contexts.Bases;
using Qel.Ef.Models;
using Qel.Ef.Providers.Common;
using Qel.Ef.Providers.Postgres;

namespace Qel.Ef.Contexts.Main;

public class DbContextMain : MyCustomDbContextBase
{
    public DbContextMain(IConfiguration configuration) : base(configuration)
    {
        Configuration = configuration;
    }

    static List<IProviderConfigurator> Configurators { get; } = [new Configurator(nameof(DbContextMain))];
    IConfiguration Configuration { get; set; }

    #region Sets
    public DbSet<Person>? Persons;
    public DbSet<Passport>? Passports;
    public DbSet<Request>? Requests;
    #endregion
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var providedOptions = new ProviderSelector(Configurators).SelectProvider(
                        repositoryName: GetType().Name,
                        builder: optionsBuilder,
                        config: Configuration);
            base.OnConfiguring(providedOptions);
        }
    }
}
