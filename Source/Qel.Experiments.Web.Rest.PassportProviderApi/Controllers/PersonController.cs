using Microsoft.AspNetCore.Mvc;
using Qel.Ef.DbClient;
using Qel.Ef.Models;

namespace Qel.Experiments.Web.Rest.PassportProviderApi.Controllers;

/// <summary>
/// CRUD-контроллер для управления заявителями
/// </summary>
/// <param name="logger">Логгер</param>
/// <param name="personRepo">Репозитория для работы с заявителями</param>
[ApiController]
[Route("api/[controller]", Name = "Persons")]
public class PersonController(ILogger<PassportController> logger,
    IPersonRepository personRepo, 
    IPassportRepository passportRepo) : ControllerBase
{
    readonly ILogger<PassportController> _logger = logger;
    readonly IPersonRepository _personRepo = personRepo;
    readonly IPassportRepository _passportRepo = passportRepo;

    /// <summary>
    /// Добавление заявителя в БД
    /// </summary>
    /// <param name="person">Заявитель</param>
    /// <returns></returns>
    [HttpPost(Name = "AddPerson")]
    [Consumes("text/plain")]
    [Produces("text/plain")]
    public async Task<IActionResult> Create(Person person)
    {
        await _personRepo.Add(person);
        return CreatedAtAction(nameof(Create), new { firstName = person.FirstName, lastName = person.LastName, passport = person.PassportId }, person );
    }

    /// <summary>
    /// Получение заявителя по его паспорту
    /// </summary>
    /// <param name="passport">Паспорт</param>
    /// <returns>Объект, содержащий данные о заявителе</returns>
    [HttpGet("Passport", Name = "GetPersonByPassport")]
    [Consumes("text/plain")]
    [Produces("text/plain")]
    public async Task<ActionResult<Person?>> Read(Passport passport)
    {
        var person = await _personRepo.Get(passport);
        return person;
    }

    /// <summary>
    /// Получение всех заявителей
    /// </summary>
    /// <returns>Список объектов, содержащих данные о заявителе</returns>
    [HttpGet(Name = "GetAllPersons")]
    [Consumes("text/plain")]
    [Produces("text/plain")]
    public async Task<ActionResult<List<Person>>> Read()
    {
        var persons = await _personRepo.Get();

        if(persons is not null)
        {
            return persons.ToList();
        }
        else
        {
            return NoContent();
        }
        
    }

    /// <summary>
    /// Обновление данных заявителя
    /// </summary>
    /// <param name="person">Заявитель</param>
    /// <returns></returns>
    [HttpPut(Name = "UpdatePerson")]
    [Consumes("text/plain")]
    [Produces("text/plain")]
    public async Task<ActionResult> Update(Person person)
    {
        await _personRepo.Update(person);
        return Ok();
    }

    /// <summary>
    /// Удаление заявителя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns></returns>
    [HttpDelete("{id}", Name = "DeletePerson")]
    [Consumes("text/plain")]
    [Produces("text/plain")]
    public async Task<IActionResult> Delete(long id)
    {
        await _personRepo.Delete(id);
        return NoContent();
    }
}