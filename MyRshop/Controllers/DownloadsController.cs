using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;

namespace MyRshop.Controllers
{
   
    public class DownloadsController : Controller
    {
        private IHostingEnvironment Environment;
        private MyRshopContext _context;
        public DownloadsController(MyRshopContext context)
        {
            _context = context;
        }
        public IActionResult DownloadsIndex(int id)
        {
            var myFiles = _context.FileModel.Include(f => f.CategoryOfFile).Where(f=>f.CateId==id).ToList();
            return View(myFiles);




        }
        public IActionResult CateOfFile()
        {
            //var myFiles = _context.FileModel.Include(f => f.Users).ToList();
            //return View(myFiles);
            var Categoreis = _context.CategoryOfFiles.ToList();
            return View(Categoreis);



        }
        public IActionResult DownloadsSoftware()
        {
        
            return View();
        }
        [HttpGet]
        public IActionResult DownloadFile1()
        {
            
            return RedirectToAction("DownloadFile1");
        }
        [HttpPost]
        public IActionResult DownloadFile1(int id)
        {
          //  DownloadFile(id.ToString());
            return RedirectToAction("DownloadFile1");
        }
        public FileResult DownloadFile(string id, string extention)
        {
            string fileName = id.ToString()+ extention;
            //Build the File Path.
            string path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Files" , fileName/*+ Path.GetExtension(fileName)*/); 

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName/* Path.GetExtension(fileName)*/);
        }
    }
}