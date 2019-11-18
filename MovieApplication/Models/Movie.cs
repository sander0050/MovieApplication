using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        
        [Required]
        public byte GenreId { get; set; }

        public string Description { get; set; }

    }
}