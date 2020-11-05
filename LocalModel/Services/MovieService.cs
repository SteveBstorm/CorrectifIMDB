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

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public void Update(MovieToDal m)
        {
            _repo.Update(m.toDal());
        }

        public void Create(MovieToDal m)
        {
            _repo.Insert(m.toDal());
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

        public IEnumerable<local.Actor> GetActors(int Id)
        {
            return _repo.GetActorsByFilmId(Id).Select(x => x.toLocal());
        }

        public void SetAsActor(int MovieId, int PersonId, string Role)
        {
            _repo.SetAsActor(MovieId, PersonId, Role);
        }
    }
}
