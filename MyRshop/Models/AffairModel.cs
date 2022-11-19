using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public enum ActivityType { بازرگانی, خدماتی, تولیدی };
    public class AffairModel
    {
        public int id { set; get; }
        [Required(ErrorMessage = "لطفا نوع فعالیت را انتخاب کنید.")]
        [Display(Name = "فعالیت:")]
        public ActivityType Activity { get; set; }
        [Required(ErrorMessage = "لطفا نام کارگاه را وارد کنید.")]
        [MaxLength(30)]
        [Display(Name = "نام کارگاه:")]
        public string WorkshopName { set; get; }
        [Required(ErrorMessage = "لطفا نام کارفرما را وارد کنید.")]
        [MaxLength(30)]
        [Display(Name = "کارفرما:")]
        public string BossName { set; get; }
        [Required(ErrorMessage = "لطفا آدرس را وارد کنید.")]
        [MaxLength(30)]
        [Display(Name = "آدرس:")]
        public string Address { set; get; }
        [Required(ErrorMessage = "لطفا تلفن را وارد کنید.")]
        [MaxLength(30)]
        [Display(Name = "تلفن:")]
        public string TellPhon { set; get; }
        [Display(Name = "توضیحات:")]
        public string Description { set; get; }


    }
}
