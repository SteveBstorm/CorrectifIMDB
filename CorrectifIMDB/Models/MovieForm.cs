using LocalModel.Models;
using LocalModel.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectifIMDB.Models
{
    public class MovieForm
    {
        private PersonService _service;
        public MovieForm()
        {
            _service = new PersonService();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }

        public int RealisatorID { get; set; }

        public IEnumerable<Person> Real
        {
            get { return _service.GetAll().OrderBy(s => s.LastName); }
        }

        //public IEnumerable<SelectListItem> Real
        //{
        //    get
        //    {
        //        foreach (var item in _service.GetAll())
        //            yield return new SelectListItem
        //            {
        //                Text = item.LastName,
        //                Value = item.Id.ToString()
        //            };
        //    }
        //}
        public int ScenaristID { get; set; }

        public IEnumerable<Person> Scen
        {
            get { return _service.GetAll().OrderBy(s => s.LastName); }
        }

        //public IEnumerable<SelectListItem> Scen
        //{
        //    get
        //    {
        //        foreach (var item in _service.GetAll())
        //            yield return new SelectListItem
        //            {
        //                Text = item.LastName,
        //                Value = item.Id.ToString()
        //            };
        //    }
        //}
    }
}
