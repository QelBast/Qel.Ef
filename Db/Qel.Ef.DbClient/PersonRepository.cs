using Microsoft.EntityFrameworkCore;
using Qel.Ef.Models;

namespace Qel.Ef.DbClient;

public class PersonRepository<TContext> : BaseRepository<TContext>, IPersonRepository
    where TContext : DbContext
{
    public Task Add(Person passport)
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

    public Task Update(Person entityNew)
    {
        throw new NotImplementedException();
    }

    public Task Update(Person entityOld, Person entityNew)
    {
        throw new NotImplementedException();
    }
}