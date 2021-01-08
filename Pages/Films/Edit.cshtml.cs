using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farcas_Viorel_Proiect.Data;
using Farcas_Viorel_Proiect.Models;

namespace Farcas_Viorel_Proiect.Pages.Films
{
    public class EditModel : FilmCategoriesPageModel
    {
        private readonly Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext _context;

        public EditModel(Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film = await _context.Film
                .Include(b => b.Director)
                .Include(b => b.FilmCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Film == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Film);

            ViewData["DirectorID"] = new SelectList(_context.Set<Director>(), "ID", "DirectorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmToUpdate = await _context.Film
                .Include(i => i.Director)
                .Include(i => i.FilmCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (filmToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Film>(
                filmToUpdate,
                "Film",
                i => i.Title, i => i.Length,
                i => i.Price, i => i.ReleaseDate, i => i.Director))
            {
                UpdateFilmCategories(_context, selectedCategories, filmToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateFilmCategories(_context, selectedCategories, filmToUpdate);
            PopulateAssignedCategoryData(_context, filmToUpdate);
            return Page();
        }
            
    }

 }
