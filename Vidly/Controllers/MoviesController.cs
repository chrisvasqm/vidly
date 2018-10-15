using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationContext _context;

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
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }
        
        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
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

        [Route("movies/new")]
        public IActionResult New()
        {
            return View();
        }
    }
}