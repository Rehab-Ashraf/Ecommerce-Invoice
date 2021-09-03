using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INVOICE.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required(ErrorMessage ="cost is required")]
        [Range(minimum:1,maximum:100000)]
        public double Cost { get; set; }
        [Required(ErrorMessage ="you have to selete an image")]
        [DisplayName("Image")]
        public string  ImagPath { get; set; }
        public virtual ICollection<ProductInvoiceDetails> ProductInvoiceDetails { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Product()
        {
            ImagPath = "~/Content/Images/img3.jpg";
            
        }
    }
}