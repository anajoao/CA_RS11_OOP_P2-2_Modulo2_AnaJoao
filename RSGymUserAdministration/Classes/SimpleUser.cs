using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Classes
{
    internal class SimpleUser : User
    {
        #region Properties

        public override UserType UserType
        {
            get { return UserType.SimpleUser; }
            set {}
        }


        #endregion

        #region Constructors

        public SimpleUser() : base()
        {
        }

        public SimpleUser(string name, string username, string password) : base(name, username, password, UserType.SimpleUser)
        {
        }
        #endregion

    }
}
