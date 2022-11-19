using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class OrderDetail
    {
        [Key]
        public int DetailId { set; get; }
        [Required]
        public int OrderId { set; get; }
        public Order Order { set; get; }

        [Required]
        public int ProductId { set; get; }
        [Required]
        public int Count { set; get; }


        [ForeignKey("ProductId")]
        public Product Product { set; get; }

        public virtual ClassProgram ClassProgram { set; get; }
        public int? ClassProgramId { set; get; }

        [Required]
        public int Price { set; get; }
    }
}
