using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CorrectifIMDB.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("test", "ma var session");
            return View();
        }
    }
}