using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectAutoCore.Data;
using ProiectAutoCore.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ProiectAutoCore.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly AutoRepresentationContext _context;

        public CreateModel(AutoRepresentationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Form submission started.");

            Console.WriteLine($"ClientId: {Car.ClientId}");
            Console.WriteLine($"Make: {Car.Make}");
            Console.WriteLine($"Model: {Car.Model}");
            Console.WriteLine($"Year: {Car.Year}");
            Console.WriteLine($"VIN: {Car.VIN}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid.");
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error for {key}: {error.ErrorMessage}");
                    }
                }

                ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email");
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            Console.WriteLine("Car saved successfully!");
            return RedirectToPage("./Index");
        }


    }
}
