using INVOICE.Models;
using INVOICE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVOICE.Repository
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerByID(int CustomerID);
        int AddCustomer(CustomerVM  customer);
        int UpdateCustomer(Customer customer);
        void DeleteCustomer(int CustomerID);
    }
}
