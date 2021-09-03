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
    public class InvoiceController : Controller
    {
        private IINOICERepository INVOICEContext;
        public InvoiceController()
        {
            INVOICEContext = new InvoiceRepository(new InvoiceContext());
        }
        public ActionResult Index()
        {
            return View();
        }

        
        

        
        public ActionResult Create()
        {
           
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(InvoiceVM invoice)
        {
            if (ModelState.IsValid)
            {
                INVOICEContext.NewInvoice(invoice);
                
                return Json(invoice, JsonRequestBehavior.AllowGet); 
            }
            return Json(invoice);
        }

        public ActionResult InvoiceCreated()
        {
            return View();
        }


    }
}
