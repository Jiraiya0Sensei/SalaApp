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
    public class IndexModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public IndexModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        public IList<Antrenor> Antrenor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Antrenor != null)
            {
                IQueryable<Antrenor> antrenoriQuery = _context.Antrenor
                 .Include(p => p.Sport);  
                 

                Antrenor = await antrenoriQuery.ToListAsync();
            }
        }
    }
}
