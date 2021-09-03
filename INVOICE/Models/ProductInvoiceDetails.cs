using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INVOICE.Models
{
    public class ProductInvoiceDetails
    {
        public int ID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("InvoiceDetail")]
        public int InvoiceID { get; set; }
        public virtual InvoiceDetails InvoiceDetail { get; set; }
    }
}