using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا فعالیت را وارد کنید.")]
        [Display(Name = "فعالیت:")]
        public ActivityType Activity { get; set; }
        [Required(ErrorMessage = "لطفا نام کارگاه را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "کارگاه:")]
        public string WorkshopName { set; get; }
        [Required(ErrorMessage = "لطفا نام کارفرما را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "کارفرما :")]
        public string BossName { set; get; }
        [Required(ErrorMessage = "لطفا آدرس را وارد کنید.")]
        [MaxLength(150)]
        [Display(Name = "آدرس:")]
        public string Address { set; get; }
        [Required(ErrorMessage = "لطفا تلفن را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "تلفن:")]
        public string TellPhon { set; get; }
        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "تاریخ:")]
        public string Birthday { get; set; }
        [Required(ErrorMessage = "لطفا سابقه کار را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "سابقه:")]
        public string Experience { set; get; }
        [Display(Name = "تاهل:")]
        public bool Marital { get; set; }
        [Display(Name = "جنسیت:")]
        public bool Sex { get; set; }
        [Display(Name = "حقوق:")]
        public Salary SalaryPrice { get; set;}
            [Display(Name = "تخصص:")]
        public SpetialType Spetial { get; set; }
        [Display(Name = "نرم اقزار:")]
        public string SoftwareName { set; get; }

    }
}
