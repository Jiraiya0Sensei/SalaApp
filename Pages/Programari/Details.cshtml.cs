using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Programari
{
    public class DetailsModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public DetailsModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

      public Programare Programare { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }
           Programare = await _context.Programare
               .Include(p => p.Client)
               .Include(p => p.Antrenor)
               .FirstOrDefaultAsync(m => m.ID == id);

            
            if (Programare == null)
            {
                return NotFound();
            }
            else 
            {
                Programare = Programare;
            }
            return Page();
        }
    }
}
