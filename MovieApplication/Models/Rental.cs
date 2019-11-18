using MovieApplication.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace MovieApplication.Models
{
    public class Rental
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public byte IdCustomer { get; set;}
        [Required]
        public byte IdMovie { get; set; }

  
        public Customer Customer { get; set; }

   
        public Movie Movie { get; set; }

        [Required]
        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}