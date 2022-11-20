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

namespace MyRshop.Pages.Admin.ManageCateOfFile
{
    public class DeleteModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public DeleteModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryOfFile CategoryOfFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryOfFile = await _context.CategoryOfFiles.FirstOrDefaultAsync(m => m.Id == id);

            if (CategoryOfFile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryOfFile = await _context.CategoryOfFiles.FindAsync(id);

            if (CategoryOfFile != null)
            {
                _context.CategoryOfFiles.Remove(CategoryOfFile);
                await _context.SaveChangesAsync();

                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Files",
                    "Category",
                    CategoryOfFile.Id + Path.GetExtension(CategoryOfFile.catePic.FileName));
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
