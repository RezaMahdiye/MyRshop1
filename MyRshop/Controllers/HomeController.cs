using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyRshop.Data;
using MyRshop.Data.Repositories;
using MyRshop.Models;
using ZarinpalSandbox;

namespace MyRshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyRshopContext _context;
        public HomeController(ILogger<HomeController> logger, MyRshopContext context)
        {
            _logger = logger;

            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Include(c => c.Item).ToList();
            return View(products);
        }
        [Route("Detail")]
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == id);
            var Item = _context.Items.Include(p => p.Product).SingleOrDefault(p => p.Id == id);
            if (product == null)

            {
                return NotFound();
            }
            var categories = _context.Products.Where(p => p.Id == id).SelectMany(c => c.CategoryToProducts)
                .Select(ca => ca.Category).ToList();
            var vm = new DetailsViewModel
            {
                Product = product,
                Categoreis = categories,
                Item = Item
            };
            return View(vm);
        }
        [Authorize]
        [Route("/AddToCart")]
        public IActionResult AddToCart(int classId, int itemId)
        {
            try
            {
                var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);

                var classp = _context.ClassProgram.Include(p => p.OrderDetails).ThenInclude(c=>c.Product).SingleOrDefault(c => c.Id == classId);
                if (classp != null && product != null)
                {
                    int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                    var user = _context.Users.Find(userId);
                    if (user == null)
                    {
                        return RedirectToAction("login", "account");
                    }
                    var order = _context.Order.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
                    if (order != null)
                    {
                        var orderDetail = _context.OrderDetail.FirstOrDefault(d => d.OrderId == order.OrderId && d.ClassProgramId == classp.Id /*&& d.ProductId == product.Id*/);
                        if (orderDetail != null)
                        {
                             orderDetail.Count +=1;
                        }
                        else
                        {
                            _context.OrderDetail.Add(new OrderDetail()
                            {
                                OrderId = order.OrderId,
                                Price = classp.Product.Item.Price,
                                ClassProgramId = classp.Id,
                                Count = 1,
                                ProductId = product.Id
                            });
                        }
                    }
                    else
                    {
                        order = new Order()
                        {
                            IsFinaly = false,
                            CreateDate = DateTime.Now,
                            UserId = userId,
                            Sum = 0
                        };
                        _context.Order.Add(order);
                        _context.SaveChanges();
                        _context.OrderDetail.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Price =classp.Product.Item.Price,
                            ClassProgramId=classp.Id,
                            Count = 1,
                            ProductId = product.Id

                        });
                    }
                    _context.SaveChanges();
                    UpdateSumOrder(order.OrderId);
                    return RedirectToAction("ShowCart");/*new {cId = classp.Id }*/
                }
                return View("Error");
            }
            catch (Exception m)
            {

                return View("Error");
            }
        }

        public void UpdateSumOrder(int orderId)
        {
            var order = _context.Order.Find(orderId);
            order.Sum = _context.OrderDetail.Where(o => o.OrderId == order.OrderId).Select(d => d.Count * d.Price).Sum();
            _context.Update(order);
            _context.SaveChanges();
        }

        [Authorize]

        public IActionResult ShowCart(/*int cId*/)
        {
           
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            
           var order = _context.Order.Where(o => o.UserId == userId && !o.IsFinaly)
                .Include(o => o.OrderDetail)
                //.ThenInclude(c => c.ClassProgram)

    .ThenInclude(c=>c.Product)
    .FirstOrDefault();

            //var orderDetail1 = _context.OrderDetail.Where(o => o.OrderId == order.OrderId).Include(o=>o.Order).ToList();
            //var order1 = _context.Order.Where(o => o.UserId == userId && !o.IsFinaly).Include(o => o.OrderDetail);

            //var OD = _context.OrderDetail.Include(o=>o.Order).Where(o => o.OrderId == order.OrderId).ToList();
            //var CP=_context.ClassProgram.Include(c=>c.Product).Where(c=>c.Id== cId).ToList();

            var OD = _context.OrderDetail.Include(c=>c.ClassProgram)/*.Where(c => c.ClassProgramId == cId).*/.ToList();
            var vm = new OrderProductVm { 
           
               orderDetails=OD,     
               order =order
            };
            return View(vm);
        }
        [Authorize]
        public IActionResult RemoveCart(int DetailId)
        {

            var orderDetail = _context.OrderDetail.SingleOrDefault(o=>o.DetailId== DetailId);
            _context.Remove(orderDetail);
            _context.SaveChanges();
            UpdateSumOrder(orderDetail.OrderId);
            //int cId1 = int.Parse(orderDetail.ClassProgramId.ToString());
            return RedirectToAction("ShowCart");/*,new{ cId=cId1}*/
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
        [Route("Courses")]
        public IActionResult Courses()
        {
            var products = _context.Products.ToList();
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Payment(int orderId)
        {
            var order = _context.Order.SingleOrDefault(o => !o.IsFinaly && o.OrderId==orderId);
            if (order == null)
            {
                return NotFound();
            }
            var payment = new Payment(order.Sum);
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره{order.OrderId}", $"http://localhost:5859/Home/OnlinPayment/" + order.OrderId, "rezamehdiye@gmail.com", "09132349878");
            if (res.Result.Status == 100)
            {
                return Redirect("http://sandbox.ZarinPal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }

        }
        public IActionResult OnlinPayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _context.Order.Find(id);
                var payment = new Payment(order.Sum);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    _context.Update(order);
                    _context.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }

            }
            return NotFound();
        }
    }
}
