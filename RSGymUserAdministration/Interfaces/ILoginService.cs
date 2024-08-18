using RSGymUserAdministration.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymUserAdministration.Interfaces
{
    internal interface ILoginService
    {

        User Login(string username, string password);

    }
}
