using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CustomersController()
        {
            _context = new ApplicationContext();
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll() => _context.Customers.ToList();

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        [HttpPut]
        public ActionResult<Customer> Update(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            customerInDb.Name = customer.Name;
            customerInDb.Birthday = customer.Birthday;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

            return customer;
        }

        [HttpDelete]
        public ActionResult<Customer> Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }
    }
}