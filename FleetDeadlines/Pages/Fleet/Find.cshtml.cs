using FleetDeadlines.Models;
using FleetDeadlines.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FleetDeadlines.Pages.Fleet
{
    public class FindModel : PageModel
    {
        private readonly Data.LocalDbContext _context;

        public FindModel(Data.LocalDbContext context)
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

            //var vehicle = await _context.Vehicles.FirstOrDefaultAsync(m => m.RegistrationNumber == id);
            var vehicle = DvlaGet.withReg(id);

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(m => m.RegistrationNumber == id);
            if (vehicle != null)
            {
                // Always override with information from DVLA api
                _context.Attach(ThisVehicle).State = EntityState.Modified;
            }
            else
            {
                // The extra call to the DVLA API should not be necessary here
                // But without it, ThisVehicle seems to clear its contents as the page is navigating away - except for RegistrationNumber, oddly enough
                // TODO: More investigation needed
                _context.Vehicles.Add(DvlaGet.withReg(ThisVehicle.RegistrationNumber));
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}