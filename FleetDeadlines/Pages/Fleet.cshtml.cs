using FleetDeadlines.Data;
using FleetDeadlines.Models;
using FleetDeadlines.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FleetDeadlines.Pages
{
    public class FleetModel : PageModel
    {
        private readonly FleetDeadlines.Data.LocalDbContext _context;

        public FleetModel(LocalDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? _NewRVN { get; set; }

        public Vehicle NewVehicle;

        public IList<Vehicle> Vehicles { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Vehicles != null)
            {
                Vehicles = (IList<Vehicle>)await _context.Vehicles.ToListAsync();
            }

            if (!string.IsNullOrEmpty(_NewRVN))
            {
                NewVehicle = DvlaGet.withReg(_NewRVN);
                Console.WriteLine(NewVehicle.Make);
            }
        }

        public async Task<IActionResult> OnPostRVNLookupAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _NewRVN = Request.Form["NewRVN"];
            //NewVehicle = DvlaGet.withReg(_NewRVN);
            //Console.WriteLine(NewVehicle.Make);

            return Page();
            //return RedirectToPage();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    //_context.Movie.Add(Movie);
        //    //await _context.SaveChangesAsync();

        //    return RedirectToPage();
        //}
    }
}
