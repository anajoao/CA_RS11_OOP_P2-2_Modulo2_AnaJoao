using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Classes
{
    internal class PowerUser : User
    {

        #region Properties

        public override UserType UserType
        {
            get { return UserType.PowerUser; }
            set {}
        }


        #endregion

        #region Constructors

        public PowerUser() : base()
        {
        }

        public PowerUser(string name, string username, string password) : base(name, username, password, UserType.PowerUser)
        {
        }
        #endregion
    }
}
