using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class AddEditFileViewModel
    {
        [Required(ErrorMessage = "لطفا نام فایل را وارد کنید.")]
        [Display(Name = "نام فایل:")]
        public string Name { set; get; }
        [Required(ErrorMessage = "لطفا توضیحات فایل را وارد کنید.")]
        [Display(Name = "توضیحات فایل:")]
        public string Description { set; get; }
        //     public IFormFile MyFile { set; get; }
        [Display(Name = "تاریخ ایجاد:")]
        public DateTime TimeSystem { set; get; }
        [ForeignKey("userId")]
        public int userId { get; set; }
        public IFormFile myFile1 { set; get; }
    }
}
