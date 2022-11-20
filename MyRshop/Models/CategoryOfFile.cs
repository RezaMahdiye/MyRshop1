using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class CategoryOfFile
    {
        public virtual int Id{set;get;}
        public virtual string Name { set; get; }
        [NotMapped]
        public virtual IFormFile catePic { set; get; }
    }
}
