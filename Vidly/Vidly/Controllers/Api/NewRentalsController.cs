using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //getting customers in database
            var customerInDb = _context.Customers                
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customerInDb == null)
                return BadRequest("Invalid customer ID.");

            //getting movies in database using a technique to make multiples compares and load them into a list
            var moviesInDb = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id));

            /* getting movies in database using another and simplest way
                var moviesInDb = new List<Movie>();
                foreach (var movieId in newRental.MovieIds)
                {
                    moviesInDb.Add(_context.Movies.SingleOrDefault(m => m.Id == movieId));
                }
            */

            //for each movie, create a new rental object for that movie and the given customer and then add them into database
            foreach (var movie in moviesInDb)
            {
                var rental = new Rental()
                {
                    Customer = customerInDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok("Recorded");

            //throw new Exception();
        }

    }
}
