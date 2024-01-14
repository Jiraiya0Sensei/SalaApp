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
    public class IndexModel : PageModel
    {
        private readonly SalaApp.Data.SalaAppContext _context;

        public IndexModel(SalaApp.Data.SalaAppContext context)
        {
            _context = context;
        }

        public IList<Abonament> Abonament { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Abonament != null)
            {
                IQueryable<Abonament> abonamenteQuery = _context.Abonament
                 .Include(p => p.Client)
                 .Include(p => p.Sport);

                Abonament = await abonamenteQuery.ToListAsync();
            }
        }
    }
}
