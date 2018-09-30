using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        [Route("movies")]
        public IActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-y"}
            };
            
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