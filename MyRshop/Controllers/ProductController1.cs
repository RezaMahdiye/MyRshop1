using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyRshop.Controllers
{
    public class ProductController1 : Controller
    {
        // GET: /<controller>/
        private MyRshopContext _context;
        public ProductController1(MyRshopContext context)
        {

            _context = context;
        }
        [Route("Group/{id}/{name}")]
        [Route("Group")]
        public IActionResult ShowProductByGropeId(int id,string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryToProducts.Where(c => c.CategoryId == id).Include(c => c.Product).Select(c => c.Product).ToList();
                
            return View(products);
        }
    }
}
