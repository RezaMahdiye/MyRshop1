using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRshop.Data;

namespace MyRshop.Pages.Admin.ManageUsers.manage
{
    public class ManageFileModel : PageModel
    {
        private MyRshopContext _context;

        public ManageFileModel(MyRshopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public FileMode MyFile1 { set; get; }
        public void OnGet()
        {

        }
        public IActionResult onPost()
        {
            if (!ModelState.IsValid)
                return Page();
            //var file1 = new MyFile1()
            //{

            //};

            //if (MyFile.MyFile?.Length > 0)
            //{
            //    string filePath = Path.Combine(Directory.GetCurrentDirectory(),
            //        "wwwroot",
            //        "images",
            //        .Id + Path.GetExtension(myfile.FileName));
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        myfile.CopyTo(stream);
            //    }
            //}
            return RedirectToPage("/");
        }
    }
}

