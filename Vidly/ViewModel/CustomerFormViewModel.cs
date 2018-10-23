using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title => (Customer.Name != null && Customer.Id != 0) ? "New Customer" : "Edit Customer";
    }
}