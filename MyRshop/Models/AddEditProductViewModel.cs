using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class AddEditProductViewModel
    {
        
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        //public string BiginEndTime { set; get; }
        //public string BiginDate { set; get; }
        //public int HoleTime { get; set; }
        //public string TeacherName { set; get; }
        //public string Days { set; get; }
        public int Price { set; get; }
        public int QuantityInStuck { set; get; }
        public IFormFile picture { set; get; }
        public List<String>  CateName { set; get; }
        public List<int> Cateid { set; get; }
    }
}
