using Microsoft.EntityFrameworkCore;

namespace Qel.Ef.DbClient;

public class BaseRepository<TContext> : IDisposable 
    where TContext : DbContext
{
    public BaseRepository(IDbContextFactory<TContext> db)
    {
        DbContext = db.CreateDbContext();
    }

    public TContext DbContext { get; }

    public void Dispose()
    {
        //GC.SuppressFinalize(DbContext);
        GC.SuppressFinalize(this);
    }
}