using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.DataAccess;

public class DemoContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = default!;

    public DbSet<CarType> CarTypes { get; set; } = default!;

    public DemoContext(DbContextOptions<DemoContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly

        modelBuilder.Entity<Car>().Property(x => x.Make).HasMaxLength(50);
        modelBuilder.Entity<Car>().Property(x => x.Model).HasMaxLength(60);
        modelBuilder.Entity<Car>().Property(x => x.PhotoUrl).HasMaxLength(250);

        modelBuilder.Entity<CarType>().Property(x => x.Name).HasMaxLength(50);

    }
}
