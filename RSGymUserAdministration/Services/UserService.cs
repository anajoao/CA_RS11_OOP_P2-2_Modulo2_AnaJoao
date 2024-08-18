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

        public void CreateUser(User adminUser, User newUser)
        {
            if (adminUser.UserType != UserType.AdminUser)
            {
                throw new UnauthorizedAccessException("Apenas administradores podem criar novos usuários.");
            }

            _userRepository.Add(newUser);
        }

        public void UpdateUser(User adminUser, string username, string newPassword, UserType newUserType)
        {
            if (adminUser.UserType != UserType.AdminUser)
            {
                throw new UnauthorizedAccessException("Apenas administradores podem editar usuários.");
            }

            User user = _userRepository.GetByUsername(username);
            if (user != null)
            {
                user.Password = newPassword;
                user.UserType = newUserType;
                _userRepository.Update(user);
            }
        }

        public User GetUserById(User adminUser, int id)
        {
            if (adminUser.UserType != UserType.AdminUser)
            {
                throw new UnauthorizedAccessException("Apenas administradores podem editar usuários.");
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
