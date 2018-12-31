using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WidlyApp2.Models;

namespace WidlyApp2.Controllers
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

        //List<Customer> customers = new List<Customer>
        //{
        //    new Customer {Id = 1, Name = "Lebowski"},
        //    new Customer {Id = 2, Name = "Dude"}
        //};

        // GET: Movies
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);

        }


        [Route("Customers/Details")]
        public ActionResult Details()
        {
                return HttpNotFound();
        }



        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).Where(x => x.Id == id).FirstOrDefault();

            if(customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
           
        }

    }
}
