using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalaApp.Data;
using SalaApp.Models;

namespace SalaApp.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public IndexModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }
        public IList<Programare> Programare { get; set; }
        public string AntrenorSort { get; set; }
        public string ClientSort { get; set; }
         public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                IQueryable<Programare> programariQuery = _context.Programare
                 .Include(p => p.Antrenor)
                 .Include(p => p.Client);
              
                Programare = await programariQuery.ToListAsync();
            }
        }
    }
}
