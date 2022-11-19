using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class DetailsViewModel
    {
        public Product Product { set; get; }
        public List<Category> Categoreis { set; get; }
        public Item Item { set; get; }

    }
}
