using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WidlyApp2.Models;
using WidlyApp2.ViewModels;

namespace WidlyApp2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {


                var movies = new List<Movie>
            {
                new Movie {Name = "Wall-E"},
                new Movie {Name = "Constantine"}
            };

                return View(movies);
            
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customer = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customer
            };

            return View(viewModel);
        }
        // GET: Movies/Random
        [Route("movies/released/{year}/{month:regex(\\d{2})}:range(1, 12)")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
    }
}