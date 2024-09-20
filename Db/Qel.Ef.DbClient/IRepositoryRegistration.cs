using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Qel.Ef.DbClient;

public interface IRepositoryRegistration<TContext>
    where TContext : DbContext
{
    public void AddRepository<TIRepository, TRepository>()
        where TIRepository : class
        where TRepository : class, TIRepository;
}