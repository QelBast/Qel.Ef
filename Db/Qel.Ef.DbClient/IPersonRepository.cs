using Qel.Ef.Models;

namespace Qel.Ef.DbClient;

public interface IPersonRepository
{
    /// <summary>
    /// Add passport entity to Db
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    public Task Add(Person passport);

    /// <summary>
    /// Get passport entity by person
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    public Task<Passport> Get(Person person);

    /// <summary>
    /// Update passport entity with the same id
    /// </summary>
    /// <param name="entityNew"></param>
    /// <returns></returns>
    public Task Update(Person entityNew);

    /// <summary>
    /// Replace one passport entity with another new
    /// </summary>
    /// <param name="entityOld"></param>
    /// <param name="entityNew"></param>
    /// <returns></returns>
    public Task Update(Person entityOld, Person entityNew);

    /// <summary>
    /// Delete passport entity
    /// </summary>
    /// <returns></returns>
    public Task Delete<T>(T passportId);
}