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
            return View(_service.GetAll());
        }
        [AuthRequired]
        public IActionResult Details(int Id)
        {
            return View(_service.GetComplete(Id));
        }

        public IActionResult Create()
        {
            return View();
        }
        [AdminRequired]
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
        [AdminRequired]
        public IActionResult Delete(int Id)
        {
            if (!_service.Delete(Id))
            {
                TempData["error"] = "La personne doit être utilisée ailleurs et ne peut être supprimée.";
                TempData.Keep();
                //Error.SetMessage( "La personne doit être utilisée ailleurs et ne peut être supprimée.");
            }

            return RedirectToAction("Index");
        }
        [AdminRequired]
        public IActionResult Edit(int Id)
        {
            return View(_service.GetOne(Id).toForm());
        }
        [AdminRequired]
        [HttpPost]
        public IActionResult Edit(PersonForm p)
        {
            _service.Update(p.toLocal());
            return RedirectToAction("Index");
        }
    }
}