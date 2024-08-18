﻿using RSGymUserAdministration.Enums;
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
            UserType userType;

            RSGymUtility.WriteMessage($"Full name: {loggedInUser.Username}> ", "\n", "");
            string name = Console.ReadLine();

            RSGymUtility.WriteMessage($"Username (exactly 5 characters): {loggedInUser.Username}> ", "\n", "");
            string username = Console.ReadLine();

            RSGymUtility.WriteMessage($"Password: {loggedInUser.Username}> ", "\n", "");
            string password = Console.ReadLine();

            do
            {
                RSGymUtility.WriteMessage($"Select the User Type (Admin, PowerUser, SimpleUser): {loggedInUser.Username}> ", "\n", "");
            } while (!Enum.TryParse(Console.ReadLine(), out userType));

            User newUser = new User(name, username, password, userType);

            userService.CreateUser(loggedInUser, newUser);

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
                    userService.UpdateUser(loggedInUser, user.Username, user.Password, user.UserType);
                    RSGymUtility.WriteMessage("New name seccessfully updated.");
                    break;

                case 2:
                    string newPassword = CapturePassword(loggedInUser);
                    userService.UpdateUser(loggedInUser, user.Username, newPassword, user.UserType);
                    RSGymUtility.WriteMessage("Password successfully updated.");
                    break;

                case 3:
                    UserType newUserType = CaptureUserType(loggedInUser);
                    userService.UpdateUser(loggedInUser, user.Username, user.Password, newUserType);
                    RSGymUtility.WriteMessage("UserType successfully updated.");
                    break;

                default:
                    RSGymUtility.WriteMessage("Invalid option.");
                    break;
            }
        }

        internal static void SearchUserById(User loggedInUser, IUserService userService)
        {
            RSGymUtility.WriteMessage($"User ID: {loggedInUser.Username}> ", "\n", "");
            int userId;
            if (int.TryParse(Console.ReadLine(), out userId))
            {
                User user = userService.GetUserById(loggedInUser, userId);
                if (user != null)
                {
                    RSGymUtility.WriteMessage($"User: {user.Username} - {user.Name}, User Type: {user.UserType}", "\n", "");
                }
                else
                {
                    RSGymUtility.WriteMessage("User not found.");
                }
            }
            else
            {
                RSGymUtility.WriteMessage("Invalid ID format.");
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




