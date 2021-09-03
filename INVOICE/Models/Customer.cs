using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INVOICE.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Customer name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}