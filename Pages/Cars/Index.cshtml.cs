using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectAutoCore.Data;
using ProiectAutoCore.Models;

namespace ProiectAutoCore.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ProiectAutoCore.Data.AutoRepresentationContext _context;

        public IndexModel(ProiectAutoCore.Data.AutoRepresentationContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                .Include(c => c.Client).ToListAsync();
        }
    }
}
