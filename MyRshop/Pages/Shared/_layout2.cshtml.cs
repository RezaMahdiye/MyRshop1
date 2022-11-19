using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRshop.Pages.Shared
{
    public class _layout2Model : PageModel
    {
        public string Msg { get; set; }
        public void OnGetMenuCourse()
        {
            Msg = "menu1";
        }
        public void OnGetMenuUsers()
        {
            Msg = "menu2";
        }
        public void OnGetMenuContent()
        {
            Msg = "menu3";
        }
        public void OnGetMenuRequest()
        {
            Msg = "menu4";
        }
    }
}