using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApplication.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
           
            return View(GetCustomers());
            //return Redirect("Home/about");
            //return View("WebApplicationMoviePractica1/Views/Home/About");
        }

        public ActionResult Edit(int id)
        {
            return View(GetCustomers().Find(c => c.Id == id));

        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Save(Customer model)
        {
            return View(GetCustomers().Find(c => c.Id == model.Id));

        }

        public ActionResult Details(Customer model)
        {
            return View(GetCustomers().Find(c => c.Id == model.Id));

        }
        private List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer(){Id=1,Nombre="Jorge1",Apellido="Perez1",Edad=21},
                new Customer(){Id=2,Nombre="Jorge2",Apellido="Perez2",Edad=22},
                new Customer(){Id=3,Nombre="Jorge3",Apellido="Perez3",Edad=23},
                new Customer(){Id=4,Nombre="Jorge4",Apellido="Perez4",Edad=24},
                new Customer(){Id=5,Nombre="Jorge5",Apellido="Perez5",Edad=25},
            };
        }

    }
}