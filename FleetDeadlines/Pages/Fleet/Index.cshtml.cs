using FleetDeadlines.Data;
using FleetDeadlines.Models;
using FleetDeadlines.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FleetDeadlines.Pages.Fleet
{
    public class IndexModel : PageModel
    {
        private readonly LocalDbContext _context;

        public IndexModel(LocalDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? NewRVN { get; set; }

        public Vehicle NewVehicle;

        public IList<Vehicle> Vehicles { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Vehicles != null)
            {
                Vehicles = await _context.Vehicles.ToListAsync();
            }

            //if (!string.IsNullOrEmpty(_NewRVN))
            //{
            //    NewVehicle = DvlaGet.withReg(_NewRVN);
            //    Console.WriteLine(NewVehicle.Make);
            //}
        }
    }
}
