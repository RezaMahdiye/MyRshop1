using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Controllers
{
    public class BlogAccountingController : Controller
    {
        private MyRshopContext _context;
        public BlogAccountingController(MyRshopContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult FinancialDepartment()
        {
            ViewBag.ShowBtn = 1;
            var model = new AffairModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult FinancialDepartment(AffairModel affairModel)
        {
            ViewBag.ShowBtn = 1;
            if (!ModelState.IsValid)
            {
                return View(affairModel);
            }

            AffairModel AffairModel = new AffairModel
            {
                   Activity=affairModel.Activity,
                   Address=affairModel.Address,
                   BossName=affairModel.BossName,
                   Description=affairModel.Description,
                   TellPhon=affairModel.TellPhon,
                   WorkshopName=affairModel.WorkshopName
            };
            _context.Add(AffairModel);
            _context.SaveChanges();
            return View("SuccessSave", affairModel);
        }
        public IActionResult TaxAffairs()
        {
            ViewBag.ShowBtn = 1;
            return View();
        }
        public IActionResult SoftwareInstalation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult IntroducingAccountant()
        {
            ViewBag.ShowBtn = 1;
            var model = new HirringModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult IntroducingAccountant(HirringModel hirringModel)
        {
            if (!ModelState.IsValid)
            {
                return View(hirringModel);
            }
            HirringModel hirringModel1 = new HirringModel { 
         
                Address= hirringModel.Address,
                Birthday= hirringModel.Birthday,
                Experience= hirringModel.Experience,
                FamilyName= hirringModel.FamilyName,
                Marital= hirringModel.Marital,
                SalaryPrice= hirringModel.SalaryPrice,
                Sex= hirringModel.Sex,
                SoftwareName= hirringModel.SoftwareName,
                TellPhon= hirringModel.TellPhon
            };
            _context.Add(hirringModel1);
            _context.SaveChanges();
            return View("SuccessSave", hirringModel);
        }
        public IActionResult TaxAdvice()
        {
            ViewBag.ShowBtn = 1;
            return View();
        }
        [HttpGet]
        public IActionResult HiringAccountant()
        {
            ViewBag.ShowBtn = 0;
            var model = new Request();

            return View(model);
        }
        [HttpPost]
        public IActionResult HiringAccountant(Request request)
        {
            ViewBag.ShowBtn = 0;
            if(!ModelState.IsValid)
                 return View(request);
            Request request1 = new Request()
            {
                Activity=request.Activity,
                Address=request.Address,
                Birthday=request.Birthday,
                BossName=request.BossName,
              
                Experience=request.Experience,
                Marital=request.Marital,
                SalaryPrice=request.SalaryPrice,
                SoftwareName=request.SoftwareName,
                Sex=request.Sex,
                Spetial=request.Spetial,
                TellPhon=request.TellPhon,
                WorkshopName=request.WorkshopName
                
            };
            _context.Add(request1);
            _context.SaveChanges();
            return View("SuccessSave",request);
        }
        public IActionResult HiringAccountant2()
        {
            return View();
        }
        public IActionResult HiringTeacher()
        {

            return View();
        }
    }
}