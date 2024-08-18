using Microsoft.SqlServer.Server;
using RSGymUserAdministration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSGymUserAdministration.Interfaces
{
    internal interface IUser
    {
        int UserId { get; }
        string Username { get; }
        string Password { get; }
        UserType UserType { get; }
    }
}
