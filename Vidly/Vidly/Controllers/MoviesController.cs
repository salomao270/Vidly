using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //examples of ActionResults return types:
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
            // MVC pattern will search for controllerName/Random.cshtml
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

        public ActionResult Index()
        {
            // var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.GenreType).ToList();

            // MVC pattern will search for controllerName/Index.cshtml
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            // var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //public IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Shrek" },
        //        new Movie { Id = 2, Name = "Em busca da felicidade" }
        //    };
        //}

    }
}