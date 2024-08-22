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

            // O 'is' faz uma verificação segura se o objeto é de um tipo específico ou derivado desse tipo.
            if (user is AdminUser adminUser)
            {
                return $"{user.Username} - {user.Name}, {user.UserType}, Phone: {adminUser.PhoneNumber}";
            }

            // Retorna o formato padrão para outros tipos de usuários
            return $"{user.Username} - {user.Name}, {user.UserType}";

        }
    }
}
