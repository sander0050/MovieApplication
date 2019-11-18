using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieApplication.Models;
using MovieApplication.ViewModels;

namespace MovieApplication.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rentals
        public ActionResult Index()
        {
            Console.WriteLine(GetRentals().First().Movie.Description);
            return View(GetRentals());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var movies = db.Movies.ToList();


            var viewModel = new RentalFormViewModel
            {
                Customers = customers,
                Movies = movies,
                Rental = new Rental()
            };
            return View("RentalForm", viewModel);
            //return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(RentalFormViewModel rentalForm)
        {
            if (!ModelState.IsValid)
            {
                return View("RentalForm", rentalForm);
            }
            if (rentalForm.Rental.Id == 0)
            {
                db.Rentals.Add(rentalForm.Rental);
            }
            else
            {
                var rentalInDb = db.Rentals.Single(m => m.Id == rentalForm.Rental.Id);
                rentalInDb.DateRented = rentalForm.Rental.DateRented;
                rentalInDb.DateReturned = rentalForm.Rental.DateReturned;
                rentalInDb.IdCustomer = rentalForm.Rental.IdCustomer;
                rentalInDb.IdMovie = rentalForm.Rental.IdMovie;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Rentals");
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            var viewModel = new RentalFormViewModel(rental)
            {
                Customers = db.Customers.ToList(),
                Movies = db.Movies.ToList()

            };

            return View("RentalForm", viewModel);
            //return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private IEnumerable<Rental> GetRentals()
        {
            return db.Rentals.Include(m => m.).Include(m => m.Movie).ToList();
        }
    }
}
