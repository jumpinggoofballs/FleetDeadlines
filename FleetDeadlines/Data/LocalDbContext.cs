using Microsoft.EntityFrameworkCore;
using FleetDeadlines.Models;

namespace FleetDeadlines.Data;

public class LocalDbContext : DbContext
{
    public LocalDbContext(DbContextOptions<LocalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; } = default!;
}