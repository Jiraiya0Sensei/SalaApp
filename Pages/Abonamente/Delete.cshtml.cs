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
    public class DeleteModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public DeleteModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Abonament Abonament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Abonament == null)
            {
                return NotFound();
            }

            var abonament = await _context.Abonament.FirstOrDefaultAsync(m => m.ID == id);

            if (abonament == null)
            {
                return NotFound();
            }
            else 
            {
                Abonament = abonament;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Abonament == null)
            {
                return NotFound();
            }
            var abonament = await _context.Abonament.FindAsync(id);

            if (abonament != null)
            {
                Abonament = abonament;
                _context.Abonament.Remove(Abonament);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
