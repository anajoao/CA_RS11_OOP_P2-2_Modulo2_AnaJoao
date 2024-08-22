using RSGymUserAdministration.Classes;
using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFormatInfo _formatter;

        public UserService(IUserRepository userRepository, IFormatInfo formatter)
        {
            _userRepository = userRepository;
            _formatter = formatter; 
        }

        public void CreateUser(User adminUser, string name, string username, string password, string phoneNumber)
        {
            if (adminUser.UserType != UserType.AdminUser)
            {
                throw new UnauthorizedAccessException("Only AdminUsers can create new users.");
            }

            var newUser = new AdminUser(name, username, password, phoneNumber);
            _userRepository.Add(newUser);
        }

        // Método para criar PowerUser e SimpleUser sem PhoneNumber
        public void CreateUser(User adminUser, string name, string username, string password, UserType userType)
        {
            if (adminUser.UserType != UserType.AdminUser)
            {
                throw new UnauthorizedAccessException("Only AdminUsers can create new users.");
            }

            User newUser;

            switch (userType)
            {
                case UserType.PowerUser:
                    newUser = new PowerUser(name, username, password);
                    break;
                case UserType.SimpleUser:
                    newUser = new SimpleUser(name, username, password);
                    break;
                default:
                    throw new ArgumentException("Invalid user.");
            }

            _userRepository.Add(newUser);
        }

        public void UpdateUser(User adminUser, string username, string newPassword, UserType newUserType, string newPhoneNumber = null)
        {
            if (adminUser.UserType != UserType.AdminUser)
            {
                throw new ArgumentException("Only AdminUsers can update users.");
            }

            User user = _userRepository.GetByUsername(username);
            if (user != null)
            {
                user.Password = newPassword;
                user.UserType = newUserType;
                
            }

            if (user is AdminUser adminToUpdate && newPhoneNumber != null)
            {
                adminToUpdate.PhoneNumber = newPhoneNumber;
            }

            _userRepository.Update(user);
        }

        public User GetUserById(User adminUser, int id)
        {
            if (adminUser.UserType != UserType.AdminUser)
            {
                throw new ArgumentException("Only AdminUsers can update users.");
            }

            return _userRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            
            return _userRepository.GetByUsername(username);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<string> ListUsers()
        {
            var users = _userRepository.GetAll();
            var formattedUsers = users.Select(user => _formatter.FormatInfo(user));
            return formattedUsers;
        }

    }
}
