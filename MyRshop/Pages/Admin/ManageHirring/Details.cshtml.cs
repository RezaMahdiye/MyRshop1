using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.ManageHirring
{
    public class DetailsModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public DetailsModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

        public HirringModel HirringModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HirringModel = await _context.Hirring.FirstOrDefaultAsync(m => m.Id == id);

            if (HirringModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
