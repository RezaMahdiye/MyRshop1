using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class Item
    {
        public int Id{ set; get; }
      
        public int Price { set; get; }

        public int QuantityInStock { set; get; }

        public Product Product { set; get; }

           
    }
}
