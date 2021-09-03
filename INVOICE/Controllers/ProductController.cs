using INVOICE.Models;
using INVOICE.Repository;
using INVOICE.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INVOICE.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository ProductRepository;
        public ProductController()
        {
            ProductRepository = new ProductRepository(new InvoiceContext());
        }
    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllProduct()
        {
            var products = ProductRepository.GetAllProducts();

            List<ProductVM> productVMs = new List<ProductVM>();
            foreach (var product in products)
            {
                ProductVM vM = new ProductVM()
                {
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ID = product.ID,
                    ImagPath = product.ImagPath
                };

                productVMs.Add(vM);
            }
            
            return Json(productVMs,JsonRequestBehavior.AllowGet);
        }

        
      
        public ActionResult AddProduct()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (product.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                string extension = Path.GetExtension(product.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff")+extension;
                product.ImagPath = "/Content/Images/" + fileName;
                product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/Content/Images/"),fileName));
   
            }
            if (ModelState.IsValid)
            { 
                int result = ProductRepository.AddProduct(product);
                if(result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("AddProduct");
                }
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Edit(int id)
        {

            Product product = ProductRepository.GetProductByID(id);
            return View(product);
        }

        
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            
            if (ModelState.IsValid)
            {
                int result = ProductRepository.UpdateProduct(product);
                if (result>0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit", product.ID);
                }

            }
            return View();
        }

        
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                ProductRepository.DeleteProduct(id);
            }
            
            return RedirectToAction("Index");
        }


    }
}
