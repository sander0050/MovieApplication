using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApplication.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View(GetMovies());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(GetMovies().Find(c => c.Id == id));
        }

        public ActionResult Edit(int id)
        {
            return View(GetMovies().Find(c => c.Id == id));
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){Id=1,Name="Joker",Description="this is the description for Joker"},
                new Movie(){Id=2,Name="Avengers",Description="this is the description for Avengers"},
                new Movie(){Id=3,Name="John Wick",Description="this is the description for John Wick"},
                new Movie(){Id=4,Name="Malefica",Description="this is the description for Malefica"},
                new Movie(){Id=5,Name="Fast and Furious",Description="this is the description for Fast and Furious"},
            };
        }
    }
}