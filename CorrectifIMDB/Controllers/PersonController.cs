using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CorrectifIMDB.Models;
using CorrectifIMDB.Tools;
using LocalModel.Models;
using LocalModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorrectifIMDB.Controllers
{
    public class PersonController : Controller
    {
        PersonService _service;

        public PersonController()
        {
            _service = new PersonService();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int Id)
        {
            return View(_service.GetComplete(Id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonForm pf)
        {
            if(ModelState.IsValid)
            {
                _service.Create(pf.toLocal());

                return RedirectToAction("Index", "Movie");
            }

            return View(pf);
        }
    }
}