using INVOICE.Models;
using INVOICE.Repository;
using INVOICE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INVOICE.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepository;
        public CustomerController()
        {
            customerRepository = new CustomerRepository(new InvoiceContext());
        }
       
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult ShowCustomers()
        {
            var customers = customerRepository.GetAllCustomer();
            List<CustomerVM> customerVMs = new List<CustomerVM>();
            foreach (var customer in customers)
            {
                CustomerVM vM = new CustomerVM()
                {
                    Address = customer.Address,
                    Email = customer.Email,
                    ID = customer.ID,
                    Name = customer.Name
                };
                customerVMs.Add(vM);
            }
            return Json(customerVMs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerByID(int id)
        {
            Customer customer = customerRepository.GetCustomerByID(id);
            CustomerVM customerVM = new CustomerVM()
            {
                Address = customer.Address,
                Email = customer.Email,
                ID = customer.ID,
                Name = customer.Name

            };
            var data=Json(customerVM, JsonRequestBehavior.AllowGet);
            return data;
        }
        

      

        public ActionResult Add(CustomerVM customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.AddCustomer(customer);
                return Json( customer,JsonRequestBehavior.AllowGet);
            }
            return View("Create",customer);
        }


        public JsonResult Delete(int id)
        {
            customerRepository.DeleteCustomer(id);

            return Json(id,JsonRequestBehavior.AllowGet);
        }

        
    }
}
