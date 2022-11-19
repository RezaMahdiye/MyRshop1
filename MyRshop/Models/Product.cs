using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class Product
    {
        //public Product()
        //{
        //    Categories = new List<Category>();
        //}
        public int Id { set; get; }
        [Required(ErrorMessage = "لطفا نام دوره را وارد کنید.")]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required(ErrorMessage = "لطفا توضیحات را وارد کنید.")]
        public string Description { set; get; }
        //[Required(ErrorMessage = "لطفا کل ساعات را وارد کنید.")]
        //public int HoleTime { get; set; }
        //[Required(ErrorMessage = "لطفا نام مدرس را وارد کنید.")]
        //[MaxLength(50)]
        //public string TeacherName { set; get; }
        //[Required(ErrorMessage = "لطفا ساعت شروع و پایان را وارد کنید.")]
        //[MaxLength(50)]
        //public string BiginEndTime { set; get; }
        //[Required(ErrorMessage = "لطفا تاریخ شروع دوره را وارد کنید.")]
        //[MaxLength(50)]
        //public string BiginDate { set; get; }
        //[Required(ErrorMessage = "لطفا روز های برگزاری را وارد کنید.")]
        //[MaxLength(100)]
        //public string Days { set; get; }
        public int ItemId { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        //public List<Category> Categories { set; get; }
        public Item Item { get; set; }

        //public ICollection<Item> Items { get; set; }

       // public List<OrderDetail> OrderDetail { get; set; }

    }
}
