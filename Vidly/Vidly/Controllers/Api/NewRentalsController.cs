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
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            //getting customers in database
            var customerInDb = _context.Customers                
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customerInDb == null)
                return BadRequest("Invalid customer ID.");

            //getting movies in database using a technique to make multiples compares and load them into a list
            var moviesInDb = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (moviesInDb.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");
                movie.NumberAvailable--;

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
