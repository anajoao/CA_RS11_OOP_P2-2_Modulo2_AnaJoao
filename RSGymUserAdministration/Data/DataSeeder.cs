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
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public DataSeeder(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public void Seed()
        {
            // Criar o AdminUser explicitamente
            User admin = new AdminUser("Ana Oliveira", "admin", "adminpw", "912222233");

            // Adicionar o AdminUser ao repositório
            _userRepository.Add(admin);

            // Usar o AdminUser para criar outros tipos de usuários
            _userService.CreateUser(admin, "Carla Santos", "pUser", "powerpw", UserType.PowerUser);
            _userService.CreateUser(admin, "Jose Maria", "sUser", "simplepw", UserType.SimpleUser);
        }

    }
}
