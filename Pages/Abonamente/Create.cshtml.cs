using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Abonamente
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
            if (ViewData["ClientID"] == null)
            {
                var clienti = _context.Client.ToList();
                ViewData["ClientID"] = new SelectList(clienti, "ID", "NumeClient");
            }
            return Page();
        }

        [BindProperty]
        public Abonament Abonament { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Abonament == null || Abonament == null)
            {
                return Page();
            }

            _context.Abonament.Add(Abonament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
