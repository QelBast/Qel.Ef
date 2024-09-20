using Microsoft.EntityFrameworkCore;
using Qel.Ef.Models;

namespace Qel.Ef.DbClient;

public class PassportRepository<TContext> : BaseRepository<TContext>, IPassportRepository
    where TContext : DbContext
{
    public Task Add(Passport passport)
    {
        throw new NotImplementedException();
    }

    public Task Delete<T>(T passportId)
    {
        throw new NotImplementedException();
    }

    public Task<Passport> Get(Person person)
    {
        throw new NotImplementedException();
    }

    public Task Update(Passport passportNew)
    {
        throw new NotImplementedException();
    }

    public Task Update(Passport passportOld, Passport passportNew)
    {
        throw new NotImplementedException();
    }
}