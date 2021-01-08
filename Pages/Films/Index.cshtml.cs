using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farcas_Viorel_Proiect.Data;
using Farcas_Viorel_Proiect.Models;

namespace Farcas_Viorel_Proiect.Pages.Films
{
    public class IndexModel : PageModel
    {
        private readonly Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext _context;

        public IndexModel(Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get; set; }
        public FilmData FilmD { get; set; }
        public int FilmID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            FilmD = new FilmData();

            FilmD.Films = await _context.Film
                .Include(b => b.Director)
                .Include(b => b.FilmCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();


            if (id != null)
            {
                FilmID = id.Value;
                Film film = FilmD.Films
                    .Where(i => i.ID == id.Value).Single();
                FilmD.Categories = film.FilmCategories.Select(s => s.Category);
            }
        }
    }
}
