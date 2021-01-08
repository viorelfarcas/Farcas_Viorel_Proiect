using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farcas_Viorel_Proiect.Models
{
    public class Film
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Film Title")]
        public string Title { get; set; }

        [Display(Name = "Length (min)")]
        public int Length { get; set; }

        [Display(Name = "Price ($)")]
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Director")]
        public int DirectorID { get; set; }
        public Director Director { get; set; } //navigation property

        [Display(Name = "Genres")]
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
