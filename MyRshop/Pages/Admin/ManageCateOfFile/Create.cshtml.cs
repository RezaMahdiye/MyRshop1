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

namespace MyRshop.Pages.Admin.ManageCateOfFile
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
            return Page();
        }

        [BindProperty]
        public CategoryOfFile CategoryOfFile { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryOfFiles.Add(CategoryOfFile);
            await _context.SaveChangesAsync();

            if (CategoryOfFile.catePic?.Length  > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Category", CategoryOfFile.Id + Path.GetExtension(CategoryOfFile.catePic.FileName));
                using (var stream=new FileStream(filepath, FileMode.Create))
                {
                    CategoryOfFile.catePic.CopyTo(stream);
                }

            }

            return RedirectToPage("./Index");
        }
    }
}
