using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class Category
    {
        public int Id { set; get; }
         public String Name { set; get; }
        public string Description { set; get; }


        public ICollection<CategoryToProduct> CategoryToProduct { get; set; }
    }
}
