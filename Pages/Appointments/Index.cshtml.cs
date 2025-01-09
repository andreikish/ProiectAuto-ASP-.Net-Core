using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectAutoCore.Data;
using ProiectAutoCore.Models;

namespace ProiectAutoCore.Pages.Appointments
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ProiectAutoCore.Data.AutoRepresentationContext _context;

        public IndexModel(ProiectAutoCore.Data.AutoRepresentationContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointments
                .Include(a => a.Car)
                .Include(a => a.Service)
                .ToListAsync();
        }
    }
}
