using Microsoft.EntityFrameworkCore;
using Qel.Ef.Models.Bases;

namespace Qel.Ef.Models;

/// <summary>
/// Паспортные данные клиента
/// </summary>
[Comment("Паспортные данные клиента")]
public class Passport : BaseEntity<long>
{
    public int Serie { get; set; }
    public int Number { get; set; }
}
