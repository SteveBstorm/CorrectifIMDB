using System;
using System.Collections.Generic;
using System.Text;

using local = LocalModel.Models;
using dal = DAL.Models;
using System.Runtime.CompilerServices;
using LocalModel.Services;

namespace LocalModel.Tools
{
    public static class Mappers
    {
        static PersonService _service = new PersonService();
        static MovieService _movieService = new MovieService();

        public static local.Movie toLocal(this dal.Movie m)
        {
            return new local.Movie {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ReleaseYear = m.ReleaseYear,
                Realisator = _service.GetOne(m.RealisatorID),
                Scenarist = _service.GetOne(m.ScenaristID),
                Actors = _movieService.GetActors(m.Id)
            };
        }

        public static local.Person toLocal(this dal.Person p)
        {
            return new local.Person
            {
                Id = p.Id,
                LastName = p.LastName,
                FirstName = p.FirstName
            };
        }

        public static dal.Person toDal(this local.Person p)
        {
            return new dal.Person
            {
                Id = p.Id,
                LastName = p.LastName,
                FirstName = p.FirstName
            };
        }

        public static local.CompletePerson toCPerson(this dal.Person p)
        {
            return new local.CompletePerson
            {
                Id = p.Id,
                LastName = p.LastName,
                FirstName = p.FirstName,
                RealMovies = _movieService.GetByRealisatorId(p.Id),
                ScenMovies = _movieService.GetByScenaristId(p.Id),
                ActAs = _service.GetActs(p.Id)
            };
        }

        public static dal.Movie toDal(this local.MovieToDal m)
        {
            return new dal.Movie
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ReleaseYear = m.ReleaseYear,
                RealisatorID = m.RealisatorID,
                ScenaristID = m.ScenaristID
            };
        }

        public static local.Actor toLocal(this dal.Actor a)
        {
            return new local.Actor
            {
                Role = a.Role,
                LastName = a.LastName,
                FirstName = a.FirstName
            };
        }

        public static local.ActIn toLocal(this dal.ActIn a)
        {
            return new local.ActIn
            {
                Role = a.Role,
                MovieTitle = a.MovieTitle
            };
        }

    }
}
