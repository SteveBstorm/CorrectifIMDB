using System;
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
                LastName = p.LastName,
                FirstName = p.FirstName
            };
        }

        public static local.MovieToDal toLocal(this asp.MovieForm m)
        {
            return new local.MovieToDal
            {
                Title = m.Title,
                Description = m.Description,
                ReleaseYear = m.ReleaseYear,
                RealisatorID = m.RealisatorID,
                ScenaristID = m.ScenaristID
            };
        }
    }
}
