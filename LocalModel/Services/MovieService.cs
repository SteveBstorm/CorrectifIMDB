using DAL.Repository;
using local = LocalModel.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using LocalModel.Tools;
using System.Linq;
using LocalModel.Models;

namespace LocalModel.Services
{
    public class MovieService
    {
        private MovieRepo _repo;
        public MovieService()
        {
            _repo = new MovieRepo(); 

        }

        public void Create(Movie m)
        {

        }

        public local.Movie GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public IEnumerable<local.Movie> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public IEnumerable<local.Movie> GetByRealisatorId(int Id)
        {
            return _repo.GetByRealisatorId(Id).Select(x => x.toLocal());
        }

        public IEnumerable<local.Movie> GetByScenaristId(int Id)
        {
            return _repo.GetByScenaristId(Id).Select(x => x.toLocal());
        }
    }
}
