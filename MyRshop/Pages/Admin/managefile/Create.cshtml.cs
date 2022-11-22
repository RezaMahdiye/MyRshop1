using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.managefile
{
    public class CreateModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public CreateModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CateId"] = new SelectList(_context.CategoryOfFiles, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public FileModel FileModel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string extention = Path.GetExtension(FileModel.myFile1.FileName);
            FileModel.Extention = extention;
           _context.FileModel.Add(FileModel);
            await _context.SaveChangesAsync();

            if (FileModel.myFile1?.Length > 0)
            {

               
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Files",
                    FileModel.id.ToString() + extention);//Product.picture.FileName Product.picture.FileName
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    FileModel.myFile1.CopyTo(stream);
                }

            }

            return RedirectToPage("./Index");
        }
    }
}
