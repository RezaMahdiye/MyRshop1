using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;


namespace MyRshop.Pages.Admin
{

    public class DeleteModel : PageModel
    {
        private MyRshopContext _context;

        public DeleteModel(MyRshopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { set; get; }
        public void OnGet(int id)
        {
             Product = _context.Products.FirstOrDefault(p => p.Id==id);


        } 
        public IActionResult OnPost()
        {
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.Id);
            _context.Products.Remove(product);
            _context.Items.Remove(item);
            _context.SaveChanges();

                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
         
            return RedirectToPage("Index");
        }
    }
}