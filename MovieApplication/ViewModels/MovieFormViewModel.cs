using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApplication.Models;

namespace MovieApplication.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

       public Movie Movie { get; set; }
        

        public string Title
        {
            get
            {
                return Movie.Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Movie = new Movie()
            {
                Id = 0,
                Name = "",
                GenreId = 1
            };

        }

        public MovieFormViewModel(Movie movie)
        {
            this.Movie = movie;
        }
    }
}

