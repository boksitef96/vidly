using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
 
namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random() // moze i viewResult
        {
            var movie = new Movie() { Name = "Terminator" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}

            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            //return new ViewResult();
            //return Content("Hello World");
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" }); // treci param su sta se prenosi

        }

        // moze i bez navodjenja rute
        // mora id ne moze movieId jer je u RouteConfig tako podeseno
        public ActionResult Edit(int id)
        {
            return Content("Parametar id = " + id);
        }

        // movie
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

            return Content(String.Format("pageIndex = {0} and sortBy = {1}", pageIndex, sortBy));
        }

        //public ActionResult ByReleaseDate (int year, int? month)
        //{
        //    if (!month.HasValue)
        //    {
        //        month = 1;
        //    }
        //    return Content(year + "/" + month);
        //}

        [Route("movie/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int? month)
        {
            if (!month.HasValue)
            {
                month = 1;
            }
            return Content(year + "/" + month);
        }


    }
}