using MovieApplication.Models;
using System;
using System.Collections.Generic;

namespace MovieApplication.ViewModels
{
    public class RentalFormViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        public Rental Rental { get; set; }
        public string Title
        {
            get
            {
                return Rental.Id != 0 ? "Edit Rental" : "New Rental";
            }
        }

        public RentalFormViewModel() {
            Rental = new Rental()
            {
                Id = 0,
                IdCustomer = 0,
                IdMovie = 0,
                DateReturned = null,
                DateRented = DateTime.Today
                
            };
        }

        public RentalFormViewModel(Rental rental)
        {
            this.Rental = rental;
        }
    }
}