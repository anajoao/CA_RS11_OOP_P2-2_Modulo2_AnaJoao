using RSGymUserAdministration.Classes;
using RSGymUserAdministration.Data;
using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using RSGymUserAdministration.Repository;
using RSGymUserAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace RSGymUserAdministration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RSGymUtility.SetUnicodeConsole();

            try
            {
                RSGymUtility.SetUnicodeConsole();

                IUserRepository userRepository = new UserRepository();
                IFormatInfo formatter = new FullInfoFormatter();
                IUserService userService = new UserService(userRepository, formatter);
                ILoginService loginService = new LoginService(userService);

                // Dados iniciais (seeding)
                DataSeeder seeder = new DataSeeder(userService);
                seeder.Seed();

                //IUser loggedInUser = UserUtility.Login(loginService);
                User currentUser = null;
                bool loggedIn = false;
                bool exit = false;

                do
                {

                    while (!loggedIn)
                    {
                        int loginOption = AppUtility.ShowMenuLogin();

                        switch (loginOption)
                        {

                            case 1:
                                Console.Clear();
                                RSGymUtility.WriteTitle("Login", "", "\n");
                                currentUser = AppUtility.Login(loginService);
                                if (currentUser != null)
                                {
                                    loggedIn = true;
                                }
                                break;
                            case 2:
                                exit = true;
                                break;
                        }

                        if (exit)
                        {
                            break;
                        }
                    }

                    while (loggedIn)
                    {

                        switch (currentUser.UserType)
                        {

                            case UserType.AdminUser:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                int optionA = AppUtility.ShowAdminUserMenu(currentUser);

                                switch (optionA)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        RSGymUtility.WriteTitle("Create User", "", "\n");
                                        UserUtility.InfoCreateUser(currentUser, userService);
                                        RSGymUtility.PauseConsole();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        RSGymUtility.WriteTitle("Edit User", "", "\n");
                                        UserUtility.EditUser(currentUser, userService);
                                        RSGymUtility.PauseConsole();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        RSGymUtility.WriteTitle("Search User", "", "\n");
                                        int searchOption = AppUtility.SearchMenu(currentUser);
                                        switch (searchOption)
                                        {
                                            case 1:
                                                Console.Clear();
                                                RSGymUtility.WriteTitle("Search User by ID");
                                                UserUtility.SearchUserById(currentUser, userService);
                                                break;
                                            case 2:
                                                Console.Clear();
                                                RSGymUtility.WriteTitle("Search User by Username");
                                                UserUtility.SearchUserByUsername(currentUser, userService);
                                                break;
                                            default:
                                                RSGymUtility.WriteMessage("Invalid Option.");
                                                break;
                                        }
                                        RSGymUtility.PauseConsole();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        RSGymUtility.WriteTitle("List Users", "", "\n");
                                        UserUtility.ListAllUsers(userService);
                                        RSGymUtility.PauseConsole();
                                        break;
                                    case 5:
                                        loggedIn = false;
                                        break;
                                }
                                Console.ResetColor();
                                break;
                            case UserType.PowerUser:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                int optionP = AppUtility.ShowPowerUserMenu(currentUser);

                                switch (optionP)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        RSGymUtility.WriteTitle("Search User", "", "\n");
                                        UserUtility.SearchUserByUsername(currentUser, userService);
                                        RSGymUtility.PauseConsole();
                                        break;

                                    case 2:
                                        Console.Clear();
                                        RSGymUtility.WriteTitle("List Users", "", "\n");
                                        UserUtility.ListAllUsers(userService);
                                        RSGymUtility.PauseConsole();
                                        break;

                                    case 3:
                                        loggedIn = false;
                                        break;

                                    default:
                                        RSGymUtility.WriteMessage("Invalid Option.", "", "\n");
                                        break;
                                }
                                Console.ResetColor();
                                break;
                            case UserType.SimpleUser:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                int optionS = AppUtility.ShowSimpleUserMenu(currentUser);

                                switch (optionS)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        RSGymUtility.WriteTitle("List Users", "", "\n");
                                        UserUtility.ListAllUsers(userService);
                                        RSGymUtility.PauseConsole();
                                        break;

                                    case 2:
                                        loggedIn = false;
                                        break;

                                    default:
                                        RSGymUtility.WriteMessage("Invalid Option.", "", "\n");
                                        break;
                                }
                                Console.ResetColor();
                                break;
                        }
                    }
                } while (!loggedIn && !exit);
            }

            catch (Exception ex)
            {
                RSGymUtility.WriteMessage($"Error: {ex.Message}", "\n\n");
            }


            RSGymUtility.TerminateConsole();

        }
    }
}
