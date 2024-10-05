using Microsoft.EntityFrameworkCore;
using Qel.Ef.Models.Bases;

namespace Qel.Ef.Models;

/// <summary>
/// Заявка в банк
/// </summary>
[Comment("Заявка в банк")]
public class Request : BaseEntity<long>
{
    public int Summa { get; set; }
    public int Period { get; set; }
}
