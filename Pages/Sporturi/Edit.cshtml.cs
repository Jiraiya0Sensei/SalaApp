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

namespace SalaApp.Pages.Sporturi
{
    public class EditModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public EditModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sport Sport { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sport == null)
            {
                return NotFound();
            }

            var sport =  await _context.Sport.FirstOrDefaultAsync(m => m.ID == id);
            if (sport == null)
            {
                return NotFound();
            }
            Sport = sport;
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

            _context.Attach(Sport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(Sport.ID))
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

        private bool SportExists(int id)
        {
          return (_context.Sport?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
