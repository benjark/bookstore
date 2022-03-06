using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseID { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a valid name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the first address line:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Please enter the city:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter the state:")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter the ZIP Code:")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter the country:")]
        public string Country { get; set; }

        [BindNever]
        public bool PurchaseReceived { get; set; }
    }
}
