using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.DataAccess;

public class DemoContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = default!;

    public DemoContext(DbContextOptions<DemoContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().Property(x => x.Make).HasMaxLength(50);
        modelBuilder.Entity<Car>().Property(x => x.Model).HasMaxLength(50);
        modelBuilder.Entity<Car>().Property(x => x.PhotoUrl).HasMaxLength(250);
    }
}
