using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MyRshop.Data;
using MyRshop.Models;

namespace MyRshop.Controllers
{
    public class CommentController : Controller
    {
        private MyRshopContext _context;
        public CommentController( MyRshopContext context)
        {
            _context = context;
        }

   
        //    [Route("/Comment/Login")]
        public IActionResult Comment()
        {
            var comment = _context.Comment.Include(c => c.user).ToList();
            var vm = new CommentViewModel
            {
               CommentList=comment
            };
            
                return View(vm);
        }
        [HttpGet]
        public IActionResult Comment2()
        {
            
            var model = new Comment();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Comment2(Comment comment)
        {
          //  var user = _context.Users.Include(u => u.UserId);

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return RedirectToAction("login", "account");
            }
            var cm = new Comment()
            {
                Question = comment.Question,
                Time = DateTime.Now,
                userId = userId
            };
           _context.Comment.Add(cm);
            _context.SaveChanges();
            return View(cm);
        }
    }
}