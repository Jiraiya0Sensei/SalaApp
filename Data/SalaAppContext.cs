using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaApp.Models;

namespace SalaApp.Data
{
    public class SalaAppContext : DbContext
    {
        public SalaAppContext (DbContextOptions<SalaAppContext> options)
            : base(options)
        {
        }

        public DbSet<SalaApp.Models.Abonament> Abonament { get; set; } = default!;

        public DbSet<SalaApp.Models.Antrenor>? Antrenor { get; set; }

        public DbSet<SalaApp.Models.Client>? Client { get; set; }

        public DbSet<SalaApp.Models.Programare>? Programare { get; set; }

        public DbSet<SalaApp.Models.Sport>? Sport { get; set; }
    }
}
