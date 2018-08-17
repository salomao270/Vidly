using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            // return Content("Bonjour");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home");   // (nameOfTheAction, nameOfTheController);
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" } );
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            // return View(movie);
            return View(viewModel);
        }

        // Route(url_template), template: the pattern of the route to match"
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]        // regex(regular_expression) to apply regular expression, \\d{2} is a constraint which means matchs 2 digits such as: 04
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        // Movies/Index
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}