using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Programari
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public EditModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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
       
           ViewData["AntrenorID"] = new SelectList(_context.Set<Antrenor>(), "ID", "Nume");
           ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "NumeClient");
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

            _context.Attach(Programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(Programare.ID))
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

        private bool ProgramareExists(int id)
        {
          return (_context.Programare?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
