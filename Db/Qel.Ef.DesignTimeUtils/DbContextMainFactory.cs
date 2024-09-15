using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Qel.Ef.Contexts.Main;

namespace Qel.Ef.Migrations;

public class DbContextMainFactory : IDesignTimeDbContextFactory<DbContextMain>
{
    public DbContextMain CreateDbContext(string[] args)
    {
        var confs = new ConfigurationManager();
        confs
        .AddJsonFile("migrsettings.json", false, false)
        .AddJsonFile($"migrsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();

        return new DbContextMain(confs);
    }
}
