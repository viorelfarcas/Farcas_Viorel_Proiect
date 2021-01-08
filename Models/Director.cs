using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farcas_Viorel_Proiect.Models
{
    public class Director
    {
        public int ID { get; set; }
        public string DirectorName { get; set; }
        public ICollection<Film> Films { get; set; } //navigation property
    }
}
