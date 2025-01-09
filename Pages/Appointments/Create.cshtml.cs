using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectAutoCore.Data;
using ProiectAutoCore.Models;

namespace ProiectAutoCore.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly AutoRepresentationContext _context;

        public CreateModel(AutoRepresentationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "VIN");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CarId"] = new SelectList(_context.Cars, "Id", "VIN");
                ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "Name");
                return Page();
            }

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
