using RSGymUserAdministration.Classes;
using RSGymUserAdministration.Enums;
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
            // AdminUser com o número de telefone
            User admin = new AdminUser("Ana Oliveira", "admin", "adminpw", "912222233");

            // PowerUser e SimpleUser
            User powerUser = new PowerUser("Carla Santos", "pUser", "powerpw");
            User simpleUser = new SimpleUser("Jose Maria", "sUser", "simplepw");

            // Adiciona os users
            _userService.CreateUser(admin, "Ana Oliveira", "admin", "adminpw", "912222233"); 
            _userService.CreateUser(admin, "Carla Santos", "pUser", "powerpw", UserType.PowerUser); 
            _userService.CreateUser(admin, "Jose Maria", "sUser", "simplepw", UserType.SimpleUser); 
        }

    }
}
