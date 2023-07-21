using FleetDeadlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FleetDeadlines.Pages.Fleet
{
    public class DeleteModel : PageModel
    {
        private readonly Data.LocalDbContext _context;

        public DeleteModel(Data.LocalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicle ThisVehicle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(m => m.RegistrationNumber == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                ThisVehicle = vehicle;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle != null)
            {
                ThisVehicle = vehicle;
                _context.Vehicles.Remove(ThisVehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}