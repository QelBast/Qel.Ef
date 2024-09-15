namespace Qel.Ef.Models.Bases;

public class BaseEntity<T>
{
    public required T Id { get; set; }
}