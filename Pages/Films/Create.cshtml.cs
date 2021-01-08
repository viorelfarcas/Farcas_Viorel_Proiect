using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Farcas_Viorel_Proiect.Data;
using Farcas_Viorel_Proiect.Models;

namespace Farcas_Viorel_Proiect.Pages.Films
{
    public class CreateModel : FilmCategoriesPageModel
    {
        private readonly Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext _context;

        public CreateModel(Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DirectorID"] = new SelectList(_context.Set<Director>(), "ID", "DirectorName");

            var film = new Film();
            film.FilmCategories = new List<FilmCategory>();

            PopulateAssignedCategoryData(_context, film);

            return Page();
        }

        [BindProperty]
        public Film Film { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newFilm = new Film();
            if (selectedCategories != null)
            {
                newFilm.FilmCategories = new List<FilmCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FilmCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newFilm.FilmCategories.Add(catToAdd);
                }
            }


            if (await TryUpdateModelAsync<Film>(
                newFilm,
                "Film",
                i => i.Image, i => i.Length, i => i.Title,
                i => i.Price, i => i.ReleaseDate, i => i.DirectorID))
            {
                _context.Film.Add(newFilm);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newFilm);
            return Page();

           
        }
    }
}
