﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp = CorrectifIMDB.Models;
using local = LocalModel.Models;


namespace CorrectifIMDB.Tools
{
    public static class Mappers
    {
        public static local.Person toLocal(this asp.PersonForm p)
        {
            return new local.Person
            {
                Id = p.Id,
                LastName = p.LastName,
                FirstName = p.FirstName
            };
        }

        public static local.MovieToDal toLocal(this asp.MovieForm m)
        {
            return new local.MovieToDal
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ReleaseYear = m.ReleaseYear,
                RealisatorID = m.RealisatorID,
                ScenaristID = m.ScenaristID
            };
        }

        public static asp.MovieForm toForm(this local.Movie m)
        {
            return new asp.MovieForm
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                RealisatorID = m.Realisator.Id,
                ScenaristID = m.Scenarist.Id,
                ReleaseYear = m.ReleaseYear
            };
        }

        public static asp.PersonForm toForm(this local.Person p)
        {
            return new asp.PersonForm
            {
                Id = p.Id,
                LastName = p.LastName,
                FirstName = p.FirstName
            };
        }

        public static local.User toLocal(this asp.LoginViewModel l)
        {
            return new local.User
            {
                Email = l.Email,
                Password = l.Password
            };
        }

        public static local.User toLocal(this asp.RegisterFormModel model)
        {
            return new local.User
            {
                Email = model.Email,
                Password = model.Password,
                LastName = model.LastName,
                FirstName = model.FirstName,
                BirthDate = model.BirthDate,
            };
        }

        public static asp.RegisterFormModel toForm(this local.User model)
        {
            return new asp.RegisterFormModel
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                LastName = model.LastName,
                FirstName = model.FirstName,
                BirthDate = model.BirthDate,
            };
        }
    }
}
