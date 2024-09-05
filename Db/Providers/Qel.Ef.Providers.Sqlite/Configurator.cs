using Microsoft.EntityFrameworkCore;

namespace Qel.Ef.Providers.Sqlite;

using Qel.Ef.Providers.Common;

public class Configurator : IProviderConfigurator
{
    public DbContextOptionsBuilder ConfigureOptionsBuilder (DbContextOptionsBuilder options)
    {
        return options.UseSqlite($"Data Source=");
    }
}
