using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.ManageClassProgram
{
    public class DeleteModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public DeleteModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassProgram ClassProgram { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassProgram = await _context.ClassProgram
                .Include(c => c.Product).FirstOrDefaultAsync(m => m.Id == id);

            if (ClassProgram == null)
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

            ClassProgram = await _context.ClassProgram.FindAsync(id);

            if (ClassProgram != null)
            {
                _context.ClassProgram.Remove(ClassProgram);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
