using FleetDeadlines.Data;
using Microsoft.EntityFrameworkCore;
using FleetDeadlines.Utils;

namespace FleetDeadlines.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, string api, string key)
        {
            using (var context = new LocalDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LocalDbContext>>()))
            {
                // Pre-Checks
                context.Database.EnsureCreated();

                if (context == null || context.Vehicles == null)
                {
                    throw new ArgumentNullException("Null LocalDbContext");
                }

                if (context.Vehicles.Any())
                {
                    return;   // DB has been seeded
                }

                // Seeding
                List<string> testVRNs = new List<string>
                    // { "AA19AAA", "AA19EEE", "AA19PPP", "L2WPS", "AA19SRN", "AA19DSL", "AA19MOT", "AA19AMP"}; <- includes deliberately garbage entries
                    { "AA19AMP", "AA19MOT", "AA19PPP" };

                // TODO: Make these requests parallel
                // ^ Only possible with the modern HttpClient(), so not possible with the HttpWebRequest I currently use? (ref: https://stackoverflow.com/a/52338888)
                foreach (var vrn in testVRNs)
                {
                    context.Vehicles.Add(DvlaGet.withReg(vrn, api, key));
                }

                context.SaveChanges();
            }
        }
    }
}
