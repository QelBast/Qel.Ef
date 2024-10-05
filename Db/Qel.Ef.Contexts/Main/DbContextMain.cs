using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Qel.Ef.Contexts.Bases;
using Qel.Ef.Models;
using Qel.Ef.Providers.Common;
using Qel.Ef.Providers.Postgres;

namespace Qel.Ef.Contexts.Main;

public class DbContextMain : MyCustomDbContextBase
{
    public DbContextMain(DbContextOptions options) : base(options)
    {

    }

    static List<IProviderConfigurator> Configurators { get; } = [new Configurator(nameof(DbContextMain))];
    IConfiguration? Configuration { get; set; }

    #region Sets
    public DbSet<Person>? Persons { get; set; }
    public DbSet<Passport>? Passports { get; set; }
    public DbSet<Request>? Requests {get; set; }
    #endregion
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
