﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectAutoCore.Data;
using ProiectAutoCore.Models;

namespace ProiectAutoCore.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectAutoCore.Data.AutoRepresentationContext _context;

        public DetailsModel(ProiectAutoCore.Data.AutoRepresentationContext context)
        {
            _context = context;
        }

        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Client = client;
            }
            return Page();
        }
    }
}
