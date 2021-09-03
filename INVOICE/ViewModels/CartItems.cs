using INVOICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INVOICE.ViewModels
{
    public class CartItems
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
    public class CartData
    {
        public Product product { get; set; }
        public int Count { get; set; }
    }
}