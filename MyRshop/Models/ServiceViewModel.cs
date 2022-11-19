using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class ServiceViewModel
    {
            [Required(ErrorMessage = "لطفا{0} را قرار دهید")]
            [MaxLength(300)]
            [Display(Name = "نام شرکت:")]
            public string ComponyName { set; get; }
            [Required(ErrorMessage = "لطفا{0} را قرار دهید")]
         
            [Display(Name = "توضیحات:")]
           
            public string Description { set; get; }
            [Required(ErrorMessage = "لطفا{0} را قرار دهید")]
            [MaxLength(50)]
            [DataType(DataType.PhoneNumber)]
           
            [Display(Name = "شماره همراه:")]
            public string Number { set; get; }
       
    }
}
