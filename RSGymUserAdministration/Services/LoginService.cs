using RSGymUserAdministration.Classes;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Services
{
    internal class LoginService : ILoginService
    {

        private readonly IUserService _userService;

        public LoginService(IUserService userService)
        {
            _userService = userService;
        }

        public User Login(string username, string password)
        {
            IEnumerable<User> users = _userService.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
