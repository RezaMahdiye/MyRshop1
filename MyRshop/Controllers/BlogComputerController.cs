using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyRshop.Controllers
{
    public class BlogComputerController : Controller
    {
        public IActionResult SiteDesign()
        {
            return View();
        }
        public IActionResult SoftwareInstallation()
        {
            return View();
        }
        public IActionResult WindowsInstallation()
        {
            return View();
        }
        public IActionResult ProAccountingSoftware()
        {
            return View();
        }
        public IActionResult NetworkSetup()
        {
            return View();
        }

    }
}