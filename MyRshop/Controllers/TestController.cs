using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class TestController: Controller
    {
        public string Test1()
        {
            return "Test1";
        }
        public string Test2()
        {
            return "Test2";
        }
    }
}
