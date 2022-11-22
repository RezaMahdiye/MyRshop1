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

namespace MyRshop.Pages.Admin.managefile
{
    public class DeleteModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public DeleteModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileModel FileModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FileModel = await _context.FileModel.FirstOrDefaultAsync(m => m.id == id);

            if (FileModel == null)
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

            FileModel = await _context.FileModel.FindAsync(id);

            if (FileModel != null)
            {
                string extention = FileModel.Extention;
                _context.FileModel.Remove(FileModel);
                await _context.SaveChangesAsync();
               


                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                  "wwwroot",
                  "Files",
                  FileModel.id.ToString()); /*+ Path.GetExtension(FileModel.myFile1.FileName)*/
            //    string fex = Path.GetExtension(FileModel.myFile1.FileName);/*Path.GetExtension(Path.GetExtension(filepath));*/ /*Path.GetExtension(filepath);*/
                
                if (System.IO.File.Exists(filepath+ extention))
                {
                    System.IO.File.Delete(filepath + extention);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
