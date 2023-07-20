using FleetDeadlines.Data;
using FleetDeadlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace FleetDeadlines.Pages
{
    public class FleetModel : PageModel
    {
        private readonly FleetDeadlines.Data.LocalDbContext _context;

        public FleetModel(LocalDbContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicles { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Vehicles != null)
            {
                Vehicles = (IList<Vehicle>)await _context.Vehicles.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Movie.Add(Movie);
            //await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
