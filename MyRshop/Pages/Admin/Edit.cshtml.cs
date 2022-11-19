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
    public class EditModel : PageModel
    {
        private MyRshopContext _context;

        public EditModel(MyRshopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { set; get; }
        public void OnGet(int id)
        {
            var product = _context.Products.Include(p => p.Item)
                                         .Where(p => p.Id == id)
                                         .Select(s => new AddEditProductViewModel() { 
                                                Id=s.Id,
                                                Description=s.Description,
                                                Name=s.Name,
                                                Price=s.Item.Price,
                                                QuantityInStuck=s.Item.QuantityInStock,
                                             //Days = s.Days,
                                             //HoleTime = s.HoleTime,
                                             //TeacherName = s.TeacherName,
                                             //BiginEndTime = s.BiginEndTime,
                                             //BiginDate=s.BiginDate
                                             
                                         }).FirstOrDefault();
            Product = product;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.Id);
            product.Name = Product.Name;
            //product.BiginDate = Product.BiginDate;
            //product.BiginEndTime = Product.BiginEndTime;
            //product.Days = Product.Days;
            //product.HoleTime = Product.HoleTime;
            //product.TeacherName = Product.TeacherName;
            product.Description = Product.Description;
            item.Price = Product.Price;
            item.QuantityInStock = Product.QuantityInStuck;
            _context.SaveChanges();
            if (Product.picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(Product.picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.picture.CopyTo(stream);
                }
            }
            return RedirectToPage("Index");
        }
        }
    }