using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INVOICE.Models
{
    public class InvoiceContext:DbContext
    {
        public InvoiceContext():base("DbConnection")
        {
            Database.SetInitializer(new InvoiceDBInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductInvoiceDetails> ProductInvoiceDetails { get; set; }
    }
}