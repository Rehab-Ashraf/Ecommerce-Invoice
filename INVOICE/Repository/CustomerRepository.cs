using INVOICE.Models;
using INVOICE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INVOICE.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InvoiceContext Context;
        public CustomerRepository(InvoiceContext context)
        {
            this.Context = context;
        }
        
        public IEnumerable<Customer> GetAllCustomer()
        {
            return Context.Customers.ToList();
        }

        public Customer GetCustomerByID(int CustomerID)
        {
            return Context.Customers.Find(CustomerID);
        }

        public int AddCustomer(CustomerVM customer)
        {
            int result = -1;
            if (customer != null)
            {
                Customer cust = new Customer()
                {
                    Name = customer.Name,
                    Address = customer.Address ,
                    Email = customer.Email
                };
                Context.Customers.Add(cust);
                Context.SaveChanges();
                return cust.ID;
            }
            return result;
        }

        public int UpdateCustomer(Customer customer)
        {
            int result = -1;
            if (customer != null)
            {
                Customer editCustomer = Context.Customers.Find(customer.ID);
                editCustomer.Name = customer.Name;
                editCustomer.Address = customer.Address;
                editCustomer.Email = customer.Email;

                Context.SaveChanges();
                return customer.ID;
            }
            return result;
        }

        public void DeleteCustomer(int CustomerID)
        {
            Customer customer = Context.Customers.Find(CustomerID);
            Context.Customers.Remove(customer);
            Context.SaveChanges();
        }

        
    }
}