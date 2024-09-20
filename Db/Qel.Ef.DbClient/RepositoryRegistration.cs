using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Qel.Ef.DbClient;

public class RepositoryRegistration<TContext> : IRepositoryRegistration<TContext>
    where TContext : DbContext
{
    private readonly IServiceCollection _services;

    public RepositoryRegistration(IServiceCollection services)
    {
        _services = services;
    }

    public void AddRepository<TIRepository, TRepository>()
        where TIRepository : class
        where TRepository : class, TIRepository
    {
        _services.AddTransient<TIRepository, TRepository>();
    }
}