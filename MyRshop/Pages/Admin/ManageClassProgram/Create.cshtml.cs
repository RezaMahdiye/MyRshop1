using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.ManageClassProgram
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
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ClassProgram ClassProgram { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClassProgram.Add(ClassProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
