﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IUserRepository<User>
    {
        IEnumerable<User> GetAll();
        User GetOne(int Id);
        void Insert(User u);
        void Update(User u);
        bool Delete(int Id);
    }
}

