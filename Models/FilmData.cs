using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farcas_Viorel_Proiect.Models
{
    public class FilmData
    {
        public IEnumerable<Film> Films { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FilmCategory> FilmCategories { get; set; }
    }
}
