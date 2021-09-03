using INVOICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVOICE.Repository
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductByID(int ProductID);
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        void DeleteProduct(int ProductID);
    }
}
