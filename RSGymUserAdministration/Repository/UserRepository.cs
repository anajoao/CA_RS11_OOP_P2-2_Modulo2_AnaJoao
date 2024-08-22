using RSGymUserAdministration.Classes;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>();

        public void Add(User user)
        {
            users.Add(user);
        }

        public void Update(User user)
        {
            User existingUser = GetById(user.UserId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Password = user.Password;
                existingUser.UserType = user.UserType;
            }
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(u => u.UserId == id);
        }

        public User GetByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

    }
}
