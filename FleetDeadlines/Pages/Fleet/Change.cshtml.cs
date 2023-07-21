using FleetDeadlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FleetDeadlines.Pages.Fleet
{
    public class ChangeModel : PageModel
    {
        private readonly Data.LocalDbContext _context;

        public ChangeModel(Data.LocalDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ThisVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(ThisVehicle.RegistrationNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VehicleExists(string id)
        {
            return (_context.Vehicles?.Any(e => e.RegistrationNumber == id)).GetValueOrDefault();
        }
    }
}