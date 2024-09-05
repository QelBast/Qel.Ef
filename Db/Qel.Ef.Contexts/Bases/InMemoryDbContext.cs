using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace Qel.Ef.Contexts.Bases;

public class InMemoryDbContext : DbContext
{
    public InMemoryDbContext(DbContextOptions options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "eftest.db");
        TypeName = this.GetType().Name;
    }

    /// <summary>
    /// Наименование типа контекста
    /// </summary>
    /// <value></value>
    public string TypeName { get; set; }

    /// <summary>
    /// Путь к контексту
    /// </summary>
    /// <value></value>
    public string DbPath { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data source={DbPath}");
    
    
}