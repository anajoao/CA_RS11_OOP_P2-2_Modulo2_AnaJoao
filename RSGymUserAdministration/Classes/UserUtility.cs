using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using RSGymUserAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace RSGymUserAdministration.Classes
{
    public class UserUtility
    {


        #region Metodos de interação com users

        internal static void InfoCreateUser(User loggedInUser, IUserService userService)
        {
            // Mostrar o menu para escolher o tipo de usuário a ser criado
            int userTypeOption = AppUtility.CreateUserMenu(loggedInUser);
            UserType userType;

            switch (userTypeOption)
            {
                case 1:
                    userType = UserType.AdminUser;
                    break;
                case 2:
                    userType = UserType.PowerUser;
                    break;
                case 3:
                    userType = UserType.SimpleUser;
                    break;
                default:
                    RSGymUtility.WriteMessage("Invalid option selected.", "\n", "");
                    return;
            }

            // Solicitar as informações comuns a todos os tipos de usuários
            RSGymUtility.WriteMessage($"Full name: {loggedInUser.Username}> ", "\n", "");
            string name = Console.ReadLine();

            RSGymUtility.WriteMessage($"Username (exactly 5 characters): {loggedInUser.Username}> ", "\n", "");
            string username = Console.ReadLine();

            RSGymUtility.WriteMessage($"Password: {loggedInUser.Username}> ", "\n", "");
            string password = Console.ReadLine();

            if (userType == UserType.AdminUser)
            {
                RSGymUtility.WriteMessage($"Phone number: {loggedInUser.Username}> ", "\n", "");
                string phoneNumber = Console.ReadLine();

                // Chama o método CreateUser para AdminUser
                userService.CreateUser(loggedInUser, name, username, password, phoneNumber);
            }
            else
            {
                // Chama o método CreateUser para PowerUser ou SimpleUser
                userService.CreateUser(loggedInUser, name, username, password, userType);
            }

            RSGymUtility.WriteMessage("New user created successfully.", "\n", "");
        }


        private static string CaptureUsername(User user)
        {
            RSGymUtility.WriteMessage($"Username: {user.Username}> ", "\n", "");
            return Console.ReadLine();
        }

        private static string CapturePassword(User user)
        {
            RSGymUtility.WriteMessage($"Password: {user.Username}> ", "\n", "");
            return Console.ReadLine();
        }

        private static UserType CaptureUserType(User user)
        {
            UserType userType;
            do
            {
                RSGymUtility.WriteMessage($"Select the User Type (Admin, PowerUser, SimpleUser): {user.Username}> ", "\n", "");
            } while (!Enum.TryParse(Console.ReadLine(), out userType));




            return userType;
        }

        internal static void EditUser(User loggedInUser, IUserService userService)
        {
            string username = CaptureUsername(loggedInUser);
            var user = userService.GetUserByUsername(username);

            if (user == null)
            {
                RSGymUtility.WriteMessage("User not found.");
                return;
            }

            int editOption = AppUtility.EditMenu(loggedInUser);

            switch (editOption)
            {
                case 1:
                    RSGymUtility.WriteMessage($"New Name: {loggedInUser.Username}> ", "\n", "");
                    string newName = Console.ReadLine();
                    user.Name = newName;
                    userService.UpdateUser(loggedInUser, user.Username, user.Password, user.UserType, null);
                    RSGymUtility.WriteMessage("New name seccessfully updated.", "\n", "");
                    break;

                case 2:
                    string newPassword = CapturePassword(loggedInUser);
                    userService.UpdateUser(loggedInUser, user.Username, newPassword, user.UserType, null);
                    RSGymUtility.WriteMessage("Password successfully updated.", "\n", "");
                    break;

                case 3:
                    UserType newUserType = CaptureUserType(loggedInUser);
                    userService.UpdateUser(loggedInUser, user.Username, user.Password, newUserType, null);
                    RSGymUtility.WriteMessage("UserType successfully updated.", "\n", "");
                    break;
                case 4:
                    RSGymUtility.WriteMessage($"New phone number: {loggedInUser.Username}> ", "\n", "");
                    string phoneNumber = Console.ReadLine();
                    userService.UpdateUser(loggedInUser, user.Username, user.Password, user.UserType, phoneNumber);
                    RSGymUtility.WriteMessage("Phone number successfully updated.", "\n", "");
                    break;

                default:
                    RSGymUtility.WriteMessage("Invalid option.", "\n", "");
                    break;
            }
        }

        internal static void SearchUserById(User loggedInUser, IUserService userService)
        {
            int userId;
            bool isValidId;

            do
            {
                RSGymUtility.WriteMessage($"User ID: {loggedInUser.Username}> ", "\n", "");
                isValidId = int.TryParse(Console.ReadLine(), out userId);

                if (!isValidId)
                {
                    RSGymUtility.WriteMessage("Invalid ID format. Please enter a valid Id.", "\n", "");
                }
            } while (!isValidId);

            User user = userService.GetUserById(loggedInUser, userId);
            if (user != null)
            {
                FullInfoFormatter formatter = new FullInfoFormatter();
                string userInfo = formatter.FormatInfo(user);
                RSGymUtility.WriteMessage($"User: {userInfo}", "\n", "");
            }
            else
            {
                RSGymUtility.WriteMessage("User not found.", "\n", "");
            }
        }

        internal static void SearchUserByUsername(User loggedInUser, IUserService userService)
        {
            string username = CaptureUsername(loggedInUser);
            User user = userService.GetUserByUsername(username);

            if (user != null)
            {
                FullInfoFormatter formatter = new FullInfoFormatter();
                string formattedInfo = formatter.FormatInfo(user);
                RSGymUtility.WriteMessage(formattedInfo, "\n", "");
            }
            else
            {
                RSGymUtility.WriteMessage("User not found.");
            }
        }

        internal static void ListAllUsers(IUserService userService)
        {
            IEnumerable<string> users = userService.ListUsers();
            foreach (var u in users)
            {
                RSGymUtility.WriteMessage(u, "", "\n");
            }
        }

        #endregion

    }
}





