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

        public IActionResult Details(int Id)
        {
            return View(_service.GetOne(Id));
        }

        public IActionResult Create()
        {
            return View(new MovieForm());
        }




    }
}