using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Classes
{
    internal class AdminUser : User
    {
        #region Properties

        public override UserType UserType
        {
            get { return UserType.AdminUser; }
            set {}
        }

        public string PhoneNumber {  get; set; }


        #endregion

        #region Constructors

        public AdminUser() : base()
        {
        }

        public AdminUser(string name, string username, string password, string phoneNumber) : base(name, username, password, UserType.AdminUser)
        {
            PhoneNumber = phoneNumber;
        }
        #endregion
    }
}
