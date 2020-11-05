using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorrectifIMDB.Models;
using CorrectifIMDB.Tools;
using LocalModel.Models;
using LocalModel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorrectifIMDB.Controllers
{
    public class MovieController : Controller
    {
        MovieService _service;
        public MovieController()
        {
            _service = new MovieService();
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        [AuthRequired]
        public IActionResult Details(int Id)
        {
            
            return View(_service.GetOne(Id));
        }
        [AdminRequired]
        public IActionResult Create()
        {
            return View(new MovieForm());
        }
        [AdminRequired]
        [HttpPost]
        public IActionResult Create(MovieForm mf)
        {
            _service.Create(mf.toLocal());
            return RedirectToAction("Index");
        }
        [AdminRequired]
        public IActionResult Update(int Id)
        {
            return View(_service.GetOne(Id).toForm());
        }
        [AdminRequired]
        [HttpPost]
        public IActionResult Update(MovieForm m)
        {
            _service.Update(m.toLocal());
            return RedirectToAction("Index");
        }
        [AdminRequired]
        public IActionResult Delete(int Id)
        {
            _service.Delete(Id);
            return RedirectToAction("Index");
        }


    }
}