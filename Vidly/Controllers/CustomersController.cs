using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly List<Customer> _customers = new List<Customer>
        {
            new Customer {Id = 1, Name = "Customer 1"},
            new Customer {Id = 2, Name = "Customer 2"}
        };

        [Route("customers")]
        public IActionResult Index()
        {
            return View(_customers);
        }

        [Route("customers/details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = _customers.Find(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }
    }
}