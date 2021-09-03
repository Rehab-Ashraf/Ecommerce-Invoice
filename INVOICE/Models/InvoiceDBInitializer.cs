using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INVOICE.Models
{
    public class InvoiceDBInitializer: DropCreateDatabaseAlways<InvoiceContext>
    {
        protected override void Seed(InvoiceContext context)
        {
            IList<Product> defaultProducts = new List<Product>();

            defaultProducts.Add(new Product()
            { Name = "HP Lptop", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,", Cost = 900, ImagPath = "/Content/Images/laptop 1.jpg", });
            defaultProducts.Add(new Product()
            { Name = "Dell Lptop", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,", Cost = 890, ImagPath = "/Content/Images/laptop 2.jpg", });
            defaultProducts.Add(new Product()
            { Name = "Apple Lptop", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,", Cost = 900, ImagPath = "/Content/Images/laptop3.jpg", });

            context.Products.AddRange(defaultProducts);

            IList<Customer> defaultCustomers = new List<Customer>();
            defaultCustomers.Add(new Customer()
            { Name = "Aya", Email = "aya1312@gmail.com", Address="Cairo" });
            defaultCustomers.Add(new Customer()
            { Name = "Islam", Email = "islam@gmail.com", Address = "Cairo" });
            defaultCustomers.Add(new Customer()
            { Name = "Mohamed", Email = "mohamed@gmail.com", Address = "Cairo" });

            context.Customers.AddRange(defaultCustomers);


            base.Seed(context);
        }
        
    }
}