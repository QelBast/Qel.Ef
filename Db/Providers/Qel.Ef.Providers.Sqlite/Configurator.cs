using Microsoft.EntityFrameworkCore;

namespace Qel.Ef.Providers.Sqlite;

using Microsoft.Extensions.Configuration;
using Qel.Ef.Providers.Common;

public class Configurator : IProviderConfigurator
{
    public string? Tag { get; init; }

    public DbContextOptionsBuilder ConfigureOptionsBuilder(DbContextOptionsBuilder options)
    {
        return options.UseSqlite($"Data Source=");
    }

    public DbContextOptionsBuilder ConfigureOptionsBuilder(DbContextOptionsBuilder options, IConfiguration configuration)
    {
        throw new NotImplementedException();
    }
}
