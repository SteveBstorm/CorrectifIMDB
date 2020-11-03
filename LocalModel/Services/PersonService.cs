using DAL.Repository;
using local = LocalModel.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using LocalModel.Tools;
using System.Linq;
using DAL.Models;

namespace LocalModel.Services
{
    public class PersonService
    {
        private PersonRepo _repo;
        public PersonService()
        {
            _repo = new PersonRepo(); 

        }

        public local.Person GetOne(int Id)
        {
           return _repo.GetOne(Id).toLocal() ;
        }

        public local.CompletePerson GetComplete(int Id)
        {
            return _repo.GetOne(Id).toCPerson();
        }

        public IEnumerable<local.Person> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public void Create(local.Person p)
        {
            _repo.Insert(p.toDal());
        }
        

    }
}
