using DAL.Interface;
using DAL.Repository;
using LocalModel.Models;
using LocalModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LocalModel.Services
{
    public class UserService
    {
        UserRepo _repo;
        public UserService()
        {
            _repo = new UserRepo();
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public bool? CheckUser(User u)
        {
            bool? reponse = _repo.CheckUser(u.toDal());
            return reponse;
        }

        public User GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public User GetByMail(string Email)
        {
            return _repo.GetByEmail(Email).toLocal();
        }

        public void Register(User user)
        {
            _repo.Insert(user.toDal());
        }
    }
}
