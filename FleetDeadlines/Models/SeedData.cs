using FleetDeadlines.Data;
using Microsoft.AspNetCore.Http.HttpResults;
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

                List<string> testVRNs = new List<string>
                    { "AA19AAA", "AA19EEE", "AA19PPP", "L2WPS", "AA19SRN", "AA19DSL", "AA19MOT", "AA19AMP"};

                foreach (var item in testVRNs)
                {
                    context.Vehicles.Add(new Vehicle { RegistrationNumber = item });
                }

                context.SaveChanges();
            }
        }
    }
}
