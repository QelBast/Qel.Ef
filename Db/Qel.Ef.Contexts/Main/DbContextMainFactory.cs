using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace Qel.Ef.Contexts.Main;

public class DbContextMainFactory(IDbContextPool<DbContextMain> pool) : PooledDbContextFactory<DbContextMain>(pool)
{
    public override DbContextMain CreateDbContext()
    {
        return base.CreateDbContext();
    }

    public override Task<DbContextMain> CreateDbContextAsync(CancellationToken cancellationToken = default)
    {
        return base.CreateDbContextAsync(cancellationToken);
    }
}