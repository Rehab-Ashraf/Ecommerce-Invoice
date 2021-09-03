using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INVOICE.ViewModels
{
    public class ProductVM
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        public string Description { get; set; }
        
        public double Cost { get; set; }
       
        public string ImagPath { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}