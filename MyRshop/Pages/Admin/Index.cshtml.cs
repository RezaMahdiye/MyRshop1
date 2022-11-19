using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MyRshopContext _context;
       public IEnumerable<Product> products { set; get; }
        public IndexModel(MyRshopContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            products = _context.Products.Include(p=>p.Item);
        }
        public void Onpost()
        {
          
        }
    }
}