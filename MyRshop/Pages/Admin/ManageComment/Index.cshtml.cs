using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.ManageComment
{
    public class IndexModel : PageModel
    {
        private readonly MyRshop.Data.MyRshopContext _context;

        public IndexModel(MyRshop.Data.MyRshopContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; }

        public async Task OnGetAsync()
        {
            Comment = await _context.Comment
                .Include(c => c.user).ToListAsync();
        }
    }
}
