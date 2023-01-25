using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.DTOS
{
    public class MovieDtos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        public GenreDtos Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}