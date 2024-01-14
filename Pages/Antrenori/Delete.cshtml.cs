using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Antrenori
{
    public class DeleteModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public DeleteModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Antrenor Antrenor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Antrenor == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenor.FirstOrDefaultAsync(m => m.ID == id);

            if (antrenor == null)
            {
                return NotFound();
            }
            else 
            {
                Antrenor = antrenor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Antrenor == null)
            {
                return NotFound();
            }
            var antrenor = await _context.Antrenor.FindAsync(id);

            if (antrenor != null)
            {
                Antrenor = antrenor;
                _context.Antrenor.Remove(Antrenor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
