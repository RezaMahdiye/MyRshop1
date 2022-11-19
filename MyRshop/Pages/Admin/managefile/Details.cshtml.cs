using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.managefile
{
    public class DetailsModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public DetailsModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

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
    }
}
