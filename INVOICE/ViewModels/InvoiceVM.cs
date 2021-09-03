using INVOICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INVOICE.ViewModels
{
    public class InvoiceVM
    {
        public string InviceNumber { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public List<Product> Products { get; set; }

    }
}