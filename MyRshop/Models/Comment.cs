using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class Comment
    {
        public virtual int Id { set; get; }
        [Required(ErrorMessage = "لطفا پیام را وارد کنید.")]
        [Display(Name = "پیام:")]
        public virtual string Question { set; get; }

        [Display(Name = "پاسخ:")]
        public virtual string Answer { set; get; }
        [Display(Name = "وضعیت:")]
        public virtual bool IsResponsed { set; get; }
        [Display(Name = "زمان:")]
        public virtual DateTime Time { set; get; }
        [ForeignKey("userId")]
       
        public virtual int userId { set; get; }
        [Display(Name = "کاریر:")]
        public virtual Users user { set; get; }
    }
}
