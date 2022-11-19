using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRshop.Models;

namespace MyRshop.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Service()
        {
            return View();
        }
   
    }
}