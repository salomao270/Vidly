using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var memberhsipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = memberhsipTypes
            };

            return View("CustomerForm", viewModel);
        }

        // When New.cshtml form send their request data to this Action, ASP.NET MVC will bind that form request data to this viewModel object with all that values encapsulated in their object properties.
        [HttpPost]
        // public ActionResult Create(NewCustomerViewModel viewModel)
        public ActionResult Save(Customer customer)       // because our form request data in CustomerForm.cshtml key values are Customer type, MVC could binds it as Customer object as well
        {
            // it is a new customer, so it is add process
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            // it is an existing customer, so it is update process based on its corresponding id
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);                
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            // We can override the MVC convention, for convention the MVC search for the View with the same same of the Action name, but we can change it for another View result name as here)
            return View("CustomerForm", viewModel);
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
            // var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}