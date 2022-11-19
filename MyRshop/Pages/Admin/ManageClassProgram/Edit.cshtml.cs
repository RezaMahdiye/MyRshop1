using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.ManageClassProgram
{
    public class EditModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public EditModel(MyRshop.Data.MyRshopContext context)
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
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
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

            _context.Attach(ClassProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassProgramExists(ClassProgram.Id))
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

        private bool ClassProgramExists(int id)
        {
            return _context.ClassProgram.Any(e => e.Id == id);
        }
    }
}
