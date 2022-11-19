using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.ManageComment
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
        ViewData["userId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
