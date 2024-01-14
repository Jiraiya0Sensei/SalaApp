using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Abonamente
{
    public class DetailsModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public DetailsModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

      public Abonament Abonament { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Abonament == null)
            {
                return NotFound();
            }

            Abonament = await _context.Abonament
               .Include(p => p.Client)
               .Include(p => p.Sport)
               .FirstOrDefaultAsync(m => m.ID == id);
            if (Abonament == null)
            {
                return NotFound();
            }
            else 
            {
                Abonament = Abonament;
            }
            return Page();
        }
    }
}
