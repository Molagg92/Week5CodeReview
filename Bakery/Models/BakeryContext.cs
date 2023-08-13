using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
  public class BakeryContext : DbContext
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorTreatEntity> FlavorTreatEntities { get; set; }

    public BakeryContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlavorTreatEntity>()
            .HasKey(ps => new { ps.TreatId, ps.FlavorId });
    }
  }
}