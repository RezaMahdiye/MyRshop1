using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyRshop.Controllers
{
    public class CourseComputerController : Controller
    {
        public IActionResult Icdl()
        {
            return View();
        }
    }
}