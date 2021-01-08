using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farcas_Viorel_Proiect.Models;

namespace Farcas_Viorel_Proiect.Data
{
    public class Farcas_Viorel_ProiectContext : DbContext
    {
        public Farcas_Viorel_ProiectContext (DbContextOptions<Farcas_Viorel_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Farcas_Viorel_Proiect.Models.Film> Film { get; set; }

        public DbSet<Farcas_Viorel_Proiect.Models.Director> Director { get; set; }

        public DbSet<Farcas_Viorel_Proiect.Models.Category> Category { get; set; }
    }
}
