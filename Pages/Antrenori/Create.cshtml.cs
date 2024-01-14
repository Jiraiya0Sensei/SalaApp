using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Antrenori
{
    public class CreateModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public CreateModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (ViewData["SportID"] == null)
            {
                var sporturi = _context.Sport.ToList();
                ViewData["SportID"] = new SelectList(sporturi, "ID", "Denumire");
            }
            return Page();
        }

        [BindProperty]
        public Antrenor Antrenor { get; set; } 
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Antrenor == null || Antrenor == null)
            {
                return Page();
            }

            _context.Antrenor.Add(Antrenor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
