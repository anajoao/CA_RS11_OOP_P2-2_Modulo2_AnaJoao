using RSGymUserAdministration.Classes;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Data
{
    internal class DataSeeder
    {
        private readonly IUserService _userService;

        public DataSeeder(IUserService userService)
        {
            _userService = userService;
        }

        public void Seed()
        {
            User admin = new AdminUser("Ana Oliveira", "admin", "adminpw");
            User powerUser = new PowerUser("Carla Santos", "pUser", "powerpw");
            User simpleUser = new SimpleUser("Jose Maria", "sUser", "simplepw");

            _userService.CreateUser(admin, admin);
            _userService.CreateUser(admin, powerUser);
            _userService.CreateUser(admin, simpleUser);
        }

    }
}
