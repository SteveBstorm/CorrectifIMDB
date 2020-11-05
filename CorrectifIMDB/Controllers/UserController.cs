using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorrectifIMDB.Models;
using CorrectifIMDB.Tools;
using LocalModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorrectifIMDB.Controllers
{
    public class UserController : Controller
    {
        UserService _service;

        public UserController()
        {
            _service = new UserService();
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterFormModel model)
        {
            if(ModelState.IsValid)
            {
                _service.Register(model.toLocal());
                return RedirectToAction("Index", "Movie");
            }

            return View(model);
        }
    }
}