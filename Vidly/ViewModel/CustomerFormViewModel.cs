using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            Birthday = customer.Birthday;
            MembershipTypeId = customer.MembershipTypeId;
        }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }
        
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }
        
        public string Title => Id == 0 ? "New Customer" : "Edit Customer";
    }
}