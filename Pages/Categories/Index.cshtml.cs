using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farcas_Viorel_Proiect.Data;
using Farcas_Viorel_Proiect.Models;

namespace Farcas_Viorel_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext _context;

        public IndexModel(Farcas_Viorel_Proiect.Data.Farcas_Viorel_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
