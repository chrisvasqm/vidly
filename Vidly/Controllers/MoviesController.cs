using System;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index(int pageIndex = 1, string sortBy = "Name")
        {
            return Content(String.Format("pageIndex:{0} & sortBy: {1}", pageIndex, sortBy));
        }
        
        public IActionResult Random()
        {
            var movie = new Movie {Name = "Shrek"};
            
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            return Content("id: " + id);
        }
    }
}