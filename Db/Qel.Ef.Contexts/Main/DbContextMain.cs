using Microsoft.EntityFrameworkCore;
using Qel.Ef.Contexts.Bases;
using Qel.Ef.Models;

namespace Qel.Ef.Contexts.Main;

public class DbContextMain : InMemoryDbContext
{
    public DbContextMain(DbContextOptions<DbContextMain> options) : base(options)
    {

    }
    public DbSet<Pizza>? Pizzas;

    
}
