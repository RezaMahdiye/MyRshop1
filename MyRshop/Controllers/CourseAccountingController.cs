using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Controllers
{
    public class CourseAccountingController : Controller
    {
        private MyRshopContext _context;
        public CourseAccountingController(MyRshopContext context)
        {
            _context = context;
        }
        [Authorize]
        [Route("Accounting")]
        public IActionResult Accounting(int programId)
        {


            var program = _context.ClassProgram.Include(p => p.Product).Where(p => p.ProductId== programId).ToList();
            var product = _context.Products.Include(p=>p.Item).SingleOrDefault(p=>p.Id== programId);
            var Item= _context.Items.Include(p => p.Product).SingleOrDefault(p => p.Id == programId);
            var vm = new ClassProgramViewModel() { 
                      ClassProgram=program,
                      Product=product,
                      Item=Item
            };
            return View(vm);


        }
    }
}