using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WidlyApp2.Models;
using WidlyApp2.ViewModels;
using System.Data.Entity;

namespace WidlyApp2.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
            
        }
        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek" };
        //    var customer = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customer
        //    };

        //    return View(viewModel);
        //}
        // GET: Movies/Random


        [Route("Movies/Released/{year}/{month:regex(\\d{2})}:range(1, 12)")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).Where(x => x.Id == id).FirstOrDefault();

            if (movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }

        }
    }
}