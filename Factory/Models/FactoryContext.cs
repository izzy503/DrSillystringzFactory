using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryDbContext : DbContext
  {
    public DbSet<Engineer> EngineersSet { get; set; }
    public DbSet<Machine> MachinesSet { get; set; }
    public DbSet<MachineEngineer> MachineEngineersSet { get; set; }

    public FactoryDbContext(DbContextOptions options) : base(options) { }
  }
}
