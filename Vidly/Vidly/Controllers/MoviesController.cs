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
        
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModels
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModels
                {
                    Genres = _context.Genres.ToList(),
                    Movie = new Movie()
                };

                return View("MovieForm", viewModel);
            }

            // new movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            // existing movie
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var moviesViewModel = new MovieFormViewModels
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", moviesViewModel);
        }

    }
}