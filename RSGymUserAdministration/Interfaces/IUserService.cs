using RSGymUserAdministration.Classes;
using RSGymUserAdministration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Interfaces
{
    internal interface IUserService
    {
        void CreateUser(User adminUser, string name, string username, string password, string phoneNumber);
        void CreateUser(User adminUser, string name, string username, string password, UserType userType);
        void UpdateUser(User adminUser, string username, string newPassword, UserType newUserType);
        User GetUserById(User adminUser, int id);
        User GetUserByUsername(string username);
        IEnumerable<User> GetAllUsers();
        IEnumerable<string> ListUsers();
    }
}
