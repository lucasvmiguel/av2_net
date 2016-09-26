using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace av2_net.Persistence
{
  public class TempModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class ApplicationContext : DbContext
  {
    public DbSet<TempModel> TempModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=./app.db");
    }
  }
}
