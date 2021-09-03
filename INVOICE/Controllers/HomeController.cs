using INVOICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INVOICE.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository ProductRepository;
        public HomeController()
        {
           ProductRepository = new ProductRepository(new Models.InvoiceContext());
        }
        
        public ActionResult Index()
        {
            var products = ProductRepository.GetAllProducts();
            return View(products);
        }

        public JsonResult ShowAllProducts()
        {
            var products = ProductRepository.GetAllProducts();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}