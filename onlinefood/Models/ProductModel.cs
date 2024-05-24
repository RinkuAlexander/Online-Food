using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace onlinefood.Models
{
    public class ProductModel
    {
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        public string Price { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        //[Required(ErrorMessage = "Please choose file to upload.")]
        [Display(Name = "Menu")]
        public string Image { get; set; }



        //public List<ProductModel> ShowallProducts { get; set; }
        public List<ProductModel> ShowProductsDetails { get; set; }

    }
}