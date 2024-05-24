using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace onlinefood.Models
{
    public class UserSignup
    {
        [Display(Name = "UserId")]
        public int UserId { get; set; }
       

        //[Required(ErrorMessage = "First name is required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
       //[Required(ErrorMessage = "Date of birth is required")]
       // [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}",ApplyFormatInEditMode =true)]
       // [onlinefood.Models.CustomValidationAttributeDemo.ValidBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth { get; set; }

       // [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }


        //[Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
       // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "Email  is required")]
       // [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Address  is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

       // [Required(ErrorMessage = "Username  is required")]
        [Display(Name = "User name")]
        public string Username { get; set; }

       // [Required(ErrorMessage = "Password  is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirm Password  is required")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public List<UserSignup> ShowallUser { get; set; }
        public List<UserSignup> UserInfo { get; set; }
    }
}