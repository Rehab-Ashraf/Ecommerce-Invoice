using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INVOICE.Models;
using INVOICE.ViewModels;

namespace INVOICE.Repository
{
    public class InvoiceRepository : IINOICERepository
    {
        private readonly InvoiceContext Context;
        public InvoiceRepository(InvoiceContext context)
        {
            this.Context = context;
        }
       
        public int NewInvoice(InvoiceVM invoice)
        {
            int result = -1;
            if (invoice != null)
            {
                InvoiceDetails invoiceDetails = new InvoiceDetails()
                {
                    InviceNumber = invoice.InviceNumber,
                    Date = DateTime.Now,
                    CustomerID = invoice.Customer.ID,
                    TotalPrice = invoice.TotalPrice
                };

                Context.InvoiceDetails.Add(invoiceDetails);
                Context.SaveChanges();

                foreach(Product proID in invoice.Products)
                {
                    ProductInvoiceDetails productInvoice = new ProductInvoiceDetails()
                    {
                        InvoiceID = invoiceDetails.ID,
                        ProductID = proID.ID
                    };
                    Context.ProductInvoiceDetails.Add(productInvoice);
                    
                }
                Context.SaveChanges();
                result = invoiceDetails.ID; 
            }
            
            return result;
        }

        public int UpdateInvoice(InvoiceVM invoice)
        {
            return -1;
        }

        public void DeleteInvoice(int InvoiceID)
        {
            
        }

        public IEnumerable<InvoiceVM> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        public InvoiceVM GetInvoiceByID(int InvoiceID)
        {
            throw new NotImplementedException();
        }
    }
}