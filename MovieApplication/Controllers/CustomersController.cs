using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MovieApplication.Controllerss
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
            _context.Dispose(); // libera los recursos
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
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

           

            return View("Create",customer);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {     
            return View(new Customer());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                /*var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };*/

                return View(customer);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerInDb.Nombre = customer.Nombre;
                customerInDb.Apellido = customer.Apellido;
                customerInDb.Edad = customer.Edad;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();


            return View(customer);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            /*return new List<Customer>()
            {
                new Customer(){Id=1,Nombre="Jorge1",Apellido="Perez1",Edad=21},
                new Customer(){Id=2,Nombre="Jorge2",Apellido="Perez2",Edad=22},
                new Customer(){Id=3,Nombre="Jorge3",Apellido="Perez3",Edad=23},
                new Customer(){Id=4,Nombre="Jorge4",Apellido="Perez4",Edad=24},
                new Customer(){Id=5,Nombre="Jorge5",Apellido="Perez5",Edad=25},
            };*/

            return _context.Customers.ToList();
        }

    }
}