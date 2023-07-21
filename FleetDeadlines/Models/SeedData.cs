﻿using FleetDeadlines.Data;
using Microsoft.EntityFrameworkCore;
using FleetDeadlines.Utils;

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

                // TODO: Make these requests parallel
                foreach (var vrn in testVRNs)
                {
                    context.Vehicles.Add(DvlaGet.withReg(vrn, "TEST"));
                }

                context.SaveChanges();
            }
        }
    }
}
