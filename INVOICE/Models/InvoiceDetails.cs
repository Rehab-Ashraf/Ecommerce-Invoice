using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INVOICE.Models
{
    public class InvoiceDetails
    {
        
        [Key]
        public int ID { get; set; }
        public string InviceNumber { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; } 
        public double TotalPrice { get; set; }
        public virtual ICollection<ProductInvoiceDetails> ProductInvoiceDetails { get; set; }

    }
}