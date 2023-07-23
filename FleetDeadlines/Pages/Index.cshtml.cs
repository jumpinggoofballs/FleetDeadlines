using FleetDeadlines.Data;
using FleetDeadlines.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FleetDeadlines.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FleetDeadlines.Data.LocalDbContext _context;

        public IndexModel(LocalDbContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicles { get; set; } = default!;
        public IList<Vehicle> ValidVehicles { get; set; } = default!;
        
        public IList<Vehicle> ProblemVehicles { get; set; } = default!;


        public string DaysCalculations(Vehicle v)
        {
            DateTime motDate = DateTime.Parse(v.MotExpiryDate);
            DateTime taxDate = DateTime.Parse(v.TaxDueDate);

            if (motDate == taxDate)
            {
                return StylingInject(motDate, $"{DaysRemaining(motDate)} days remaining for both MOT and Tax");
            } 
            else if (motDate < taxDate)
            {
                return StylingInject(motDate, $"{DaysRemaining(motDate)} days remaining for MOT <br />{DaysRemaining(taxDate)} days remaining for Tax");
            } 
            else
            {
                return StylingInject(taxDate, $"{DaysRemaining(taxDate)} days remaining for Tax <br />{DaysRemaining(motDate)} days remaining for MOT");
            }
        }

        private int DaysRemaining(DateTime d)
        {
            TimeSpan timeSpan = d - DateTime.Now;
            return (int)timeSpan.TotalDays;
        }

        // Add coloration to upcomind deadlines text. 
        // Hacky and should be done in a better way, but it'll do for now
        private string StylingInject(DateTime deadline, string target)
        {
            // Past deadline(s)!
            if (DaysRemaining(deadline) < 0)
            {
                return $"<div style=\"color:red;\">{target}</div>";
            }
            
            // Closest deadline within two weeks
            if (DaysRemaining(deadline) < 14)
            {
                return $"<div style=\"color:blue;\">{target}</div>";
            }
            
            return target;
        }

        public async Task OnGetAsync()
        {
            if (_context.Vehicles != null)
            {
                Vehicles = (IList<Vehicle>)await _context.Vehicles.ToListAsync();

                Func<Vehicle, bool> validPredicate = obj => (obj.MotExpiryDate != null && obj.TaxDueDate != null) == true;

                ValidVehicles = Vehicles.Where(validPredicate).OrderBy(item => Math.Min(DateTime.Parse(item.MotExpiryDate).Ticks, DateTime.Parse(item.TaxDueDate).Ticks)).ToList();

                ProblemVehicles = Vehicles.Where(item => !validPredicate(item)).ToList();
            }
        }
    }
}