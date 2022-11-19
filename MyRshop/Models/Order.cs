using FsCheck;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class Order
    {
        [Key]
       public int OrderId { set; get; }
        [Required]
        public int UserId { set; get; }
        [Required]
        public DateTime CreateDate { set; get; }

        public bool IsFinaly { set; get; }
        [ForeignKey("UserId")]
        public Users Users { set; get; }
        public List<OrderDetail> OrderDetail { set; get; }
        [Required]
        public int Sum { set; get; }
    }
}
