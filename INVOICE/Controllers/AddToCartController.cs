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
    public class AddToCartController : Controller
    {
        private IProductRepository ProductRepository;
        public AddToCartController()
        {
            ProductRepository = new ProductRepository(new InvoiceContext());
        }
        

       
        public ActionResult Myorder( )
        {
            return View();

        }
        public JsonResult All()
        {
            List<CartItems> items = CartController.CartItems;
            List<CartData> cartData = new List<CartData>();
            cartData = ProductRepository.GetAllProducts().Where(c => items.Any(i => i.Id == c.ID))
                .Select(s => new CartData
                {
                    product = new Product
                    {
                        ID = s.ID,
                        Cost = s.Cost,
                        Description = s.Description,
                        ImagPath = s.ImagPath,
                        ImageUpload = s.ImageUpload,
                        Name = s.Name
                    },
                    Count = items.Where(d => d.Id == s.ID).First().Count
                }).ToList();
            var ff = Json(cartData, JsonRequestBehavior.AllowGet);
            return ff;
        }
        public ActionResult Remove(int id)
        {
            
            if(CartController.CartItems.Find(c => c.Id == id).Count>1)
                CartController.CartItems.Find(c => c.Id == id).Count -= 1;
            else
                CartController.CartItems.Remove(CartController.CartItems.Find(c => c.Id == id));
           
            return Json(id,JsonRequestBehavior.AllowGet);

        }
        public ActionResult Clear()
        {
            bool result = false;
            if (CartController.CartItems.Count > 0)
            {
                CartController.CartItems.Clear();
                result = true;
            }
            else
            {
                result = false;
            }
           

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}