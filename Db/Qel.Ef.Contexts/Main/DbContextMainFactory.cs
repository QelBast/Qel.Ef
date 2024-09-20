using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Qel.Ef.Contexts.Main;

public class DbContextMainFactory() : IDbContextFactory<DbContextMain>
{
    public DbContextMain CreateDbContext()
    {
        var confs = new ConfigurationManager();
        confs
        //.AddJsonFile("appsettings.json", false, false)
        //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
        .AddEnvironmentVariables()
        .Build();

        return new DbContextMain(confs);
    }
}