using Microsoft.EntityFrameworkCore;
using FleetDeadlines.Models;

namespace FleetDeadlines.Data;

public class LocalDbContext : DbContext
{
    public LocalDbContext(DbContextOptions<LocalDbContext> options)
        : base(options)
    {
    }

    public LocalDbContext() { }

    public DbSet<Vehicle> Vehicles { get; set; } = default!;

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    options.UseInMemoryDatabase("Vehicles.db");
    //}
}