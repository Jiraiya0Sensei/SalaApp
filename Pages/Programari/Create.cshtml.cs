using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Programari
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public CreateModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (ViewData["AntrenorID"] == null)
            {
                var antrenori = _context.Antrenor.ToList();
                ViewData["AntrenorID"] = new SelectList(_context.Antrenor, "ID", "Nume");
            }

            if (ViewData["ClientID"] == null)
            {
                var clientii = _context.Client.ToList();
                ViewData["ClientID"] = new SelectList(clientii, "ID", "NumeClient");
            }
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Programare == null)
            {
                // În caz de eșec de validare, revenim la pagina curentă
                return Page();
            }

            try
            {
                // Adăugăm programarea în context și salvăm modificările
                _context.Programare.Add(Programare);
                await _context.SaveChangesAsync();

                // Redirecționăm către pagina Index după succes
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Poți să gestionezi eroarea într-un mod specific aici sau să o loghezi
                ModelState.AddModelError("", $"Eroare la salvarea programării: {ex.Message}");
                return Page();
            }
        }
    }
}
