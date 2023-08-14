using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
  public class BakeryContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorTreatEntity> FlavorTreatEntities { get; set; }

    public BakeryContext(DbContextOptions options) : base(options) { }

    // // --------Could this be waht is making stuff break?
    //     protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<FlavorTreatEntity>()
    //         .HasKey(ps => new { ps.TreatId, ps.FlavorId });
    // }
  }
}