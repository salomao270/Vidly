using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
// using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        // [Route("Customers")]     // it doesnt necessary marke this here, because in RourConfig.cs has already a default 
        // route with this argument: url: "{controller}/{action}/{id}"
        public ActionResult Index()
        {
            var customers = GetCustomers();

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
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }

    }
}