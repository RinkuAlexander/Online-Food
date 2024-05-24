using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace onlinefood.Models
{
    public class CateModel
    {
      //  internal readonly object file;

        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

       
        //[Required(ErrorMessage = "Please choose file to upload.")]
        [Display(Name = "Menu")]
        public string Image { get; set; }
        
    }
}