using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Sporturi
{
    public class DeleteModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public DeleteModel(SalaApp.Data.SalaAppContext context)
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

            var sport = await _context.Sport.FirstOrDefaultAsync(m => m.ID == id);

            if (sport == null)
            {
                return NotFound();
            }
            else 
            {
                Sport = sport;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sport == null)
            {
                return NotFound();
            }
            var sport = await _context.Sport.FindAsync(id);

            if (sport != null)
            {
                Sport = sport;
                _context.Sport.Remove(Sport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
