using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorrectifIMDB.Models;
using CorrectifIMDB.Tools;
using LocalModel.Models;
using LocalModel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CorrectifIMDB.Controllers
{
    public class AuthController : Controller
    {
        UserService _service;

        public AuthController()
        {
            _service = new UserService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OnGetPartial() =>
            new PartialViewResult
            {
                ViewName = "_Auth",
                ViewData = ViewData
            };

        public IActionResult Login(LoginViewModel model)
        {
            bool? test = _service.CheckUser(model.toLocal());

            if(test == null) {
                TempData["LoginError"] = "Email ou mot de passe invalide";
            }

            if(test == false)
            {
                TempData["LoginError"] = "Votre compte est désactivé, veuillez contacter un admin";
            }

            if(test == true)
            {
                HttpContext.Session.SetUser(_service.GetByMail(model.Email));
            }

            return RedirectToAction("Index", "Movie");
        }
        [AuthRequired]
        public IActionResult Logout()
        {
            HttpContext.Session.Disconnect();
            return RedirectToAction("Index", "Movie");
        }
    }
}