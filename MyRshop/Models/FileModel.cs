using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class FileModel
    {
        public int id { set; get; }
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
        [Display(Name = "کاربر:")]
        public int userId { get; set; }
        public Users Users { get; set; }
        [ForeignKey("CateId")]
        [Required(ErrorMessage = "لطفا دسته فایل را وارد کنید.")]
        [Display(Name = "گروه دسته بندی:")]
        public virtual int CateId { set; get; }
        public virtual CategoryOfFile CategoryOfFile { set; get; }
        [Required(ErrorMessage = "لطفا  فایل را وارد کنید.")]
        [NotMapped]
        [Display(Name = "فایل:")]
        public IFormFile myFile1 { set; get; }
    }
}
