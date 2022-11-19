using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="لطفا{0} را قرار دهید")]
        [EmailAddress]
        [MaxLength(300)]
        [Remote("VerifyEmail","Account")]
        [Display(Name="ایمیل:")]
        public string Email { set; get; }

        [Required(ErrorMessage = "لطفا{0} را قرار دهید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور:")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.\d)[A-za-z\d]{6,20}$",ErrorMessage ="شامل حرف و عدد باشد")]
        public string Password { set; get; }
       
        [Required(ErrorMessage = "لطفا{0} را قرار دهید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "تکرار کلمه عبور:")]
        public string RePassword { set; get; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا{0} را قرار دهید")]
        [EmailAddress]
        [MaxLength(300)]
        [Display(Name = "ایمیل:")]
        public string Email { set; get; }
        [Required(ErrorMessage = "لطفا{0} را قرار دهید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور:")]
        public string Password { set; get; }
        [Display(Name = "مرا به خاطر بسپار ")]
        public bool RememberMe { set; get; }
    }
}
