using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Classes
{
    internal class FullInfoFormatter : IFormatInfo
    {
        public string FormatInfo(User user)
        {

            return $"{user.Username} - {user.Name}, {user.UserType}";

        }
    }
}
