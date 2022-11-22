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

namespace MyRshop.Pages.Admin.managefile
{
    public class EditModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;
        public static string extention;
        public EditModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileModel FileModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["CateId"] = new SelectList(_context.CategoryOfFiles, "Id", "Name");
      
            if (id == null)
            {
                return NotFound();
            }


            FileModel = await _context.FileModel.FirstOrDefaultAsync(m => m.id == id);
            extention = FileModel.Extention;
            if (FileModel == null)
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

            _context.Attach(FileModel).State = EntityState.Modified;

            try
            {
                //First Delet Old File pic
                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                 "wwwroot",
                "Files",
                FileModel.id + extention); /*Path.GetExtension(FileModel.myFile1.FileName));*/
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                //Then Add New File pic
                string s = Path.GetExtension(FileModel.myFile1.FileName);
                FileModel.Extention = s;
                filepath = Path.Combine(Directory.GetCurrentDirectory(),
                 "wwwroot",
                "Files",
                FileModel.id +s);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    FileModel.myFile1.CopyTo(stream);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileModelExists(FileModel.id))
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

        private bool FileModelExists(int id)
        {
            return _context.FileModel.Any(e => e.id == id);
        }
    }
}
