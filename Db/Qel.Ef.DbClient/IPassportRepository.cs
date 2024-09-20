using Qel.Ef.Models;

namespace Qel.Ef.DbClient;

public interface IPassportRepository
{
    /// <summary>
    /// Add passport entity to Db
    /// </summary>
    /// <param name="passport"></param>
    public Task Add(Passport passport);

    /// <summary>
    /// Get passport entity by person
    /// </summary>
    /// <param name="person"></param>
    public Task<Passport> Get(Person person);

    /// <summary>
    /// Update passport entity with the same id
    /// </summary>
    /// <param name="passportNew"></param>
    /// <returns></returns>
    public Task Update(Passport passportNew);

    /// <summary>
    /// Replace one passport entity with another new
    /// </summary>
    /// <param name="passportNew"></param>
    /// <returns></returns>
    public Task Update(Passport passportOld, Passport passportNew);

    /// <summary>
    /// Delete passport entity
    /// </summary>
    /// <returns></returns>
    public Task Delete<T>(T passportId);
}
