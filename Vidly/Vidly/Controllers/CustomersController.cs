using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
// using Vidly.ViewModels;

namespace Vidly.Controllers
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
            _context.Dispose();
        }

        // GET: Customers
        // [Route("Customers")]     // it doesnt necessary marke this here, because in RourConfig.cs has already a default 
        // route with this argument: url: "{controller}/{action}/{id}"
        public ActionResult Index()
        {
            // var customers = GetCustomers();

            // this customer's property is a DB set defined in our DB context
            // it really get customers from database when Entity Framework iterates over this object (its called deferred execution, for that reason we insert Tolist() method to gets at this time.
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            return View(customers);
            // it was an ViewModel example
            // ViewCustomersViewModel viewCustomers = new ViewCustomersViewModel { Customers = customers };
            // return View(viewCustomers);
        }

        //[Route("Customers/{id}")]
        //public ActionResult Index(int id)
        // [Route("Customers/{id}")]
        public ActionResult Details(int id)
        {
            // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}