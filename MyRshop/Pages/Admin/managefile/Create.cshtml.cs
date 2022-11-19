using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Pages.Admin.managefile
{
    public class CreateModel : PageModel
    {
        private MyRshopContext _context;

        public CreateModel(MyRshopContext context)
        {
            _context = context;
        }

  
        [BindProperty]
        public AddEditFileViewModel FileModel { get; set; }

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}
        public void OnGet()
        {

        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return RedirectToAction("login", "account");
            }
            var myfile = new FileModel()
            {
                Description = FileModel.Description,
                Name = FileModel.Name,
                TimeSystem = FileModel.TimeSystem,
                userId = userId,
            };

            _context.Add(myfile);
            _context.SaveChanges();
       


            //_context.FileModel.Add(myfile);
            //await _context.SaveChangesAsync();

            if (FileModel.myFile1?.Length > 0)
            {


                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Files",
                    myfile.id + Path.GetExtension(FileModel.myFile1.FileName));//Product.picture.FileName
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    FileModel.myFile1.CopyTo(stream);
                }

            }


            return RedirectToPage("./Index");
        }
    }
}
