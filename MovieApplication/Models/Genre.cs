using System.ComponentModel.DataAnnotations;

namespace MovieApplication.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}