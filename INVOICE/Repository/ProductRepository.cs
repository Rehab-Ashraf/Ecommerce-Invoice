using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using INVOICE.Models;

namespace INVOICE.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly InvoiceContext Context;
        public ProductRepository(InvoiceContext context)
        {
            this.Context = context;
        }
       

        public IEnumerable<Product> GetAllProducts()
        {
            return Context.Products.ToList();
        }

        public Product GetProductByID(int ProductID)
        {
            return Context.Products.Find(ProductID);
        }
        public int AddProduct(Product product)
        {
            int result = -1;
            if (product != null)
            {
                Context.Products.Add(product);
                Context.SaveChanges();
                return product.ID;
            }
            return result;
        }
        public int UpdateProduct(Product product)
        {
            int result = -1;
            if (product != null)
            {
                Product modifyProduct = Context.Products.Find(product.ID);
                modifyProduct.Description = product.Description;
                modifyProduct.Cost = product.Cost;
                modifyProduct.Name = product.Name;
                //modifyProduct.ImagPath = product.ImagPath;
                Context.SaveChanges();
                return product.ID;
            }
            return result;
        }
        

        public void DeleteProduct(int ProductID)
        {
            Product DeleteProduct = Context.Products.Find(ProductID);
            Context.Products.Remove(DeleteProduct);
            Context.SaveChanges();
        }
    }
}