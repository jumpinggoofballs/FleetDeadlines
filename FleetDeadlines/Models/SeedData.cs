using FleetDeadlines.Data;
using Microsoft.EntityFrameworkCore;

namespace FleetDeadlines.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LocalDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LocalDbContext>>()))
            {
                context.Database.EnsureCreated();

                if (context == null || context.Vehicles == null)
                {
                    throw new ArgumentNullException("Null LocalDbContext");
                }

                if (context.Vehicles.Any())
                {
                    return;   // DB has been seeded
                }

                context.Vehicles.AddRange(
                    new Vehicle
                    { RegistrationNumber = "Test 1" }
                );
                context.SaveChanges();
            }
        }
    }
}
