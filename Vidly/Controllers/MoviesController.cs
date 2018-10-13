using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationContext _context;

        public MoviesController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("movies")]
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        [Route("movies/random")]
        public IActionResult Random()
        {
            var movie = new Movie {Name = "Shrek"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Carlos"},
                new Customer {Name = "Juan"}
            };

            var viewModel = new RandomMovieViewModel {Movie = movie, Customers = customers};

            return View(viewModel);
        }

        [Route("movies/edit/{id}")]
        public IActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        [Route("movies/released/{year:regex(\\d{{4}})}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, byte month)
        {
            return Content(string.Format("Year: {0}, Month: {1}", year, month));
        }
    }
}