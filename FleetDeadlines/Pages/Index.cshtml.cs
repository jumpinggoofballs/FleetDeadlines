﻿using FleetDeadlines.Data;
using FleetDeadlines.Models;
using Microsoft.AspNetCore.Mvc;
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


        public async Task OnGetAsync()
        {
            if (_context.Vehicles != null)
            {
                Vehicles = (IList<Vehicle>)await _context.Vehicles.ToListAsync();
            }
        }
    }
}