﻿using RSGymUserAdministration.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Interfaces
{
    internal interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        User GetById(int id);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();

    }
}
