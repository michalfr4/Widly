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
            return Content(year + "/" + month);
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

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genre
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    ReleaseDate = movie.ReleaseDate,
                    NumberInStock = movie.NumberInStock,
                    GenreId = movie.GenreId,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);

            }


            if (movie.Id == 0)
            {
                movie.AddDate = DateTime.Now;
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                //TryUpdateModel(customerInDb);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}