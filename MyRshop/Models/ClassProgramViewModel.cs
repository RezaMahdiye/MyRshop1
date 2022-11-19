using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class ClassProgramViewModel
    {
        public Product Product { set; get; }
        public Item Item { set; get; }
        public IList<ClassProgram> ClassProgram { set; get; }
       
    }
}
