using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Antrenori
{
    public class EditModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public EditModel(SalaApp.Data.SalaAppContext context)
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

            var antrenor =  await _context.Antrenor
                .Include(p => p.Sport)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (antrenor == null)
            {
                return NotFound();
            }
           // Antrenor = antrenor;
            ViewData["SportID"] = new SelectList(_context.Set<Sport>(), "ID", "Denumire");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Antrenor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntrenorExists(Antrenor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AntrenorExists(int id)
        {
          return (_context.Antrenor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
