using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.ManageCateOfFile
{
    public class EditModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public EditModel(MyRshop.Data.MyRshopContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryOfFile).State = EntityState.Modified;

            try
            {
                //First Delet Old File pic
                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                 "wwwroot",
                "Files",
                "Category",
                CategoryOfFile.Id + Path.GetExtension(CategoryOfFile.catePic.FileName));
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                //Then Add New File pic
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    CategoryOfFile.catePic.CopyTo(stream);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryOfFileExists(CategoryOfFile.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryOfFileExists(int id)
        {
            return _context.CategoryOfFiles.Any(e => e.Id == id);
        }
    }
}
