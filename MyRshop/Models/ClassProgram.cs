using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class ClassProgram
    {
        
        public int Id { set; get; }
        [Required(ErrorMessage = "لطفا روز های برگزاری را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "روز های برگزاری:")]
        public string Days {set;get; }
        [Required(ErrorMessage = "لطفا ساعت های برگزاری را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "ساعت های برگزاری:")]
        public string BiginEndTime { set; get; }
        [Required(ErrorMessage = "لطفا تاریخ شروع دوره را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "تاریخ شروع دوره:")]
        public string BiginDate { set; get; }

        [Required(ErrorMessage = "لطفا کل ساعات را وارد کنید.")]
        [Display(Name = "کل ساعات:")]
        public int HoleTime { get; set; }
        [Required(ErrorMessage = "لطفا نام مدرس را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "نام مدرس:")]
        public string TeacherName { set; get; }
        [Required(ErrorMessage = "لطفا ظرفیت کلاس  را وارد کنید.")]
        [Display(Name = "ظرفیت کلاس:")]
        public int Capacity { set; get; }
        [ForeignKey("ProductId")]
        [Display(Name = "جهت دوره :")]
        public Product Product { set; get; }
        public int ProductId { set; get; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}
