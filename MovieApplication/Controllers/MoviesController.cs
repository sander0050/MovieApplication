using MovieApplication.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MovieApplication.ViewModels;

namespace WebAppMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            // if (User.IsInRole(RoleName.CanManageMovies))
            return View(GetMovies());

            // return View("ReadOnlyList");
        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel MovieForm)
        {
            if (!ModelState.IsValid)
            {
                return View("MovieForm", MovieForm);
            }

            if (MovieForm.Movie.Id == 0)
            {
                _context.Movies.Add(MovieForm.Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == MovieForm.Movie.Id);
                movieInDb.Name = MovieForm.Movie.Name;
                movieInDb.Description = MovieForm.Movie.Description;
                movieInDb.GenreId = MovieForm.Movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        private IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }
    }
}