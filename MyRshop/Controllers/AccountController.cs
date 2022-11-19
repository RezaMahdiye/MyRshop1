using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyRshop.Data.Repositories;
using MyRshop.Models;

namespace MyRshop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #region register
        [HttpGet]
        //[Route("Register")]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
       // [Route("Register")]

        public IActionResult Register(RegisterViewModel Register)
        {

            if (!ModelState.IsValid)
            {
                return View(Register);
            }
            if (_userRepository.IsExistUserByEmail(Register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت نام کرده است");
                return View(Register);
            }
            Users user = new Users
            {
                Email = Register.Email.ToLower(),              
                Password = Register.Password,
                IsAdmin = false,
                RegisterDate = DateTime.Now
            };
            _userRepository.AddUser(user);
            return View("SuccessRegister", Register);
        }
        #endregion

        #region Login
        //[Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
       // [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            else
            {
                var user = _userRepository.GetUserForLogin(login.Email.ToLower(),login.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
                    return View(login);
                }
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                 new Claim("IsAdmin", user.IsAdmin.ToString()),
               // new Claim("CodeMeli", user.Email),

            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe
                };

                HttpContext.SignInAsync(principal, properties);

                return Redirect("/");
            }

        }
        #endregion
        public IActionResult VerifyEmail(string Email)
        {
            if(_userRepository.IsExistUserByEmail(Email.ToLower()))
            {
                return Json($"ایمیل{Email}تکراری می باشد");
            }
            return Json(true);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}