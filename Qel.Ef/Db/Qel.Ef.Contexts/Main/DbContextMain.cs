using Microsoft.EntityFrameworkCore;
using Qel.Ef.Contexts.Bases;
using Qel.Ef.Models;

namespace Qel.Ef.Contexts.Main;

public class DbContextMain : BaseDbContext
{
    public DbContextMain(DbContextOptions<DbContextMain> options) : base(options)
    {
        TypeName = this.GetType().Name;
    }
    public DbSet<Pizza>? Pizzas;

    
}
