using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyRshop.Controllers
{
    public class test1Controller : Controller
    {
        // GET: test1
        public ActionResult Index()
        {
            return View();
        }

        // GET: test1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: test1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: test1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: test1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: test1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: test1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: test1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}