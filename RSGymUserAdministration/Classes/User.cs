using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Classes
{
    internal class User : IUser
    {

        #region Fields
        private string password;
        private string username;
        #endregion
        #region Properties
        public static int NextId = 1;
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username
        {
            get { return username; }
            set
            {
                if (value.Length != 5)
                {
                    throw new Exception("Username must have exactly 5 characters.");
                }

                username = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 5)
                {
                    throw new Exception("Password must be at least 9 characters long.");
                }
                password = value;
            }
        }
        public virtual UserType UserType { get; set; }

        #endregion

        #region Constructors

        public User()
        {
            UserId = 0;
            Name = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }

        public User(string name, string username, string password, UserType userType)
        {
            UserId = NextId++;
            Name = name;
            Username = username;
            Password = password;
            UserType = userType;
        }
        #endregion
    }
}
