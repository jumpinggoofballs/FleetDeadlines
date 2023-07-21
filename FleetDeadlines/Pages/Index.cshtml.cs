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