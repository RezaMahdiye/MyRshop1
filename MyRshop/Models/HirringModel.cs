using MyRshop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public enum Salary { توافقی, اداری }
    public enum SpetialType { Accountent, programmer, ICDL, Photoshop, siteDesigner, Boors }

    public enum SpetialType1 { حسابدار, کدنویس, ICDL, فتوشاپ, طراح , بورس}


    public class HirringModel
    {

        public int Id { set; get; }
        [Required(ErrorMessage = "لطفا نام  را وارد کنید.")]
        [MaxLength(50)]
        [Display(Name = "نام:")]
        public string FamilyName { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد کنید.")]
        [Display(Name = "تاریخ تولد:")]
        public string Birthday { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "لطفا آدرس را وارد کنید.")]
        [Display(Name = "آدرس:")]
        public string Address { get; set; }
        [Required(ErrorMessage = "لطفا تلفن را وارد کنید.")]
        [MaxLength(30)]
        [Display(Name = "تلفن:")]
        public string TellPhon { set; get; }
        [Required(ErrorMessage = "لطفا سابقه کار را وارد کنید.")]
        [Display(Name = "سابقه کار:")]
        public string Experience { set; get; }
        [Required(ErrorMessage = "لطفا وضغیت تاهل را انتخاب کنید.")]
        [Display(Name = "وضغیت تاهل:")]
        public bool Marital { get; set; }
        [Required(ErrorMessage = "لطفا جنسیت را انتخاب کنید.")]
        [Display(Name = "جنسیت:")]
        public bool Sex { get; set; }
        [Required(ErrorMessage = "لطفا حقوق را انتخاب کنید")]
        [Display(Name = "حقوق:")]
        public Salary SalaryPrice { get; set; }
        [Required(ErrorMessage = "لطفا نوع تخصص را انتخاب کنید")]
        [Display(Name = "تخصص:")]
        public SpetialType Spetial { get; set; }
        [Required(ErrorMessage = "لطفا نرم افزار را وارد کنید")]
        [Display(Name = "نرم افزار:")]
        public string SoftwareName { set; get; }
    }
};