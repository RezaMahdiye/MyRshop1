using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin
{
    public class AddModel : PageModel
    {
        private MyRshopContext _context;

        public AddModel(MyRshopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { set; get; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStuck
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                Name = Product.Name,
                Item = item,
                Description = Product.Description,
                //Days=Product.Days,
                //HoleTime=Product.HoleTime,
                //TeacherName=Product.TeacherName,
                //BiginEndTime=Product.BiginEndTime,
                //BiginDate=Product.BiginDate

            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();

            if (Product.picture?.Length > 0)
            {
             

                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.Id + Path.GetExtension(Product.picture.FileName));//Product.picture.FileName Product.picture.FileName
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.picture.CopyTo(stream);
                }
               
            }


            return RedirectToPage("/admin/manageclassprogram/Index",pro.Id);
        }

    }
}
