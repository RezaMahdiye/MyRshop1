using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;

namespace MyRshop.Controllers
{
    public class DownloadsController : Controller
    {
        private MyRshopContext _context;
        public DownloadsController(MyRshopContext context)
        {
            _context = context;
        }
        public IActionResult DownloadsIndex()
        {
            var myFiles = _context.FileModel.Include(f => f.Users).ToList();
            return View(myFiles);
        }
        public IActionResult DownloadsSoftware()
        {
        
            return View();
        }
    }
}