using System;
using System.ComponentModel.DataAnnotations;

namespace WWM.Application.Customers.Models
{
    public class CustomerDetailModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"[0-9]{2}[ -][0-9]{4}[ -][0-9]{4}", ErrorMessage = "The phone number must follow the pattern '00 0000 0000'")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
