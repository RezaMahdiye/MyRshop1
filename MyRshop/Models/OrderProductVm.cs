using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class OrderProductVm
    {
        public Order order { get; set; }
        //public IList<ClassProgram> classProgram { get; set; }
        public  IList<OrderDetail> orderDetails{ get; set; }
    }
}
