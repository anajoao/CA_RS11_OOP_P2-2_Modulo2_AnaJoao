using RSGymUserAdministration.Enums;
using RSGymUserAdministration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace RSGymUserAdministration.Classes
{
    internal class AppUtility
    {

        #region ReadPassword
        // (https://stackoverflow.com/questions/3404421/password-masking-console-application) método para ler a senha do User enquanto a oculta, substituindo os caracteres por asteriscos (*).

        internal static string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);             // lê a tecla pressionada, sem a exibir e armazana a info na variavel
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");                                 // \b move o cursor para trás uma posição  
                    password = password.Substring(0, password.Length - 1);  // remove o ultimo caracter da senha
                }
                else if (!char.IsControl(keyInfo.KeyChar))                  // Verifica se a tecla pressionada não é uma tecla de controle (como Enter)
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);                              // loop para continuar enquanto o user não primir a tecla enter.

            return password;
        }
        #endregion

        #region Write Menus
        internal static int ShowMenuLogin()
        {
            int option;

            

            string[,] menuLogin =
            {
                {"1.", " Login"},
                {"2.", " Exit"},
            };


            Console.Clear();

            RSGymUtility.WriteTitle("Menu LOGIN", "", "\n\n");

            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    RSGymUtility.WriteMessage($"{menuLogin[r, c]}");
                }

                RSGymUtility.WriteMessage("\n");
            }

            do
            {
                RSGymUtility.WriteMessage("> ", "\n");

            } while (!int.TryParse(Console.ReadLine(), out option));

           

            return option;
        }

        internal static int ShowAdminUserMenu(User user)
        {
            int option;

            

            string[,] adminUserMenu =
            {
                {"1.", " Create user"},
                {"2.", " Edit"},
                {"3.", " Search"},
                {"4.", " List"},
                {"5.", " Logout"},
            };


            Console.Clear();

            RSGymUtility.WriteTitle($"Admin User Menu \t\t| Profile:{user.UserType}", "", "\n\n");

            for (int r = 0; r < adminUserMenu.GetLength(0); r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    RSGymUtility.WriteMessage($"{adminUserMenu[r, c]}");
                }

                RSGymUtility.WriteMessage("\n");
            }

            do
            {
                RSGymUtility.WriteMessage($"{user.Username}> ", "\n");

            } while (!int.TryParse(Console.ReadLine(), out option));

            

            return option;
        }

        internal static int SearchMenu(User user)
        {
            int option;

            string[,] powerUserMenu =
            {
                {"1.", " By Id"},
                {"2.", " By username"},
            };


            Console.Clear();

            RSGymUtility.WriteTitle($"Search Menu \t\t| Profile:{user.UserType}", "", "\n\n");

            for (int r = 0; r < powerUserMenu.GetLength(0); r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    RSGymUtility.WriteMessage($"{powerUserMenu[r, c]}");
                }

                RSGymUtility.WriteMessage("\n");
            }

            do
            {
                RSGymUtility.WriteMessage($"{user.Username}> ", "\n");

            } while (!int.TryParse(Console.ReadLine(), out option));

            return option;
        }

        internal static int CreateUserMenu(User user)
        {
            int option;

            string[,] createUserMenu =
            {
                {"1.", " Admin"},
                {"2.", " Power"},
                {"2.", " Simple"},
            };


            Console.Clear();

            RSGymUtility.WriteTitle($"Create User Menu \t\t| Profile:{user.UserType}", "", "\n\n");

            for (int r = 0; r < createUserMenu.GetLength(0); r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    RSGymUtility.WriteMessage($"{createUserMenu[r, c]}");
                }

                RSGymUtility.WriteMessage("\n");
            }

            do
            {
                RSGymUtility.WriteMessage($"{user.Username}> ", "\n");

            } while (!int.TryParse(Console.ReadLine(), out option));

            return option;
        }

        internal static int EditMenu(User user)
        {
            int option;

            string[,] powerUserMenu =
            {
                {"1.", " Name"},
                {"2.", " Password"},
                {"3.", " User Type"},
            };


            Console.Clear();

            RSGymUtility.WriteTitle($"Edit Menu \t\t| Profile:{user.UserType}", "", "\n\n");

            for (int r = 0; r < powerUserMenu.GetLength(0); r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    RSGymUtility.WriteMessage($"{powerUserMenu[r, c]}");
                }

                RSGymUtility.WriteMessage("\n");
            }

            do
            {
                RSGymUtility.WriteMessage($"{user.Username}> ", "\n");

            } while (!int.TryParse(Console.ReadLine(), out option));

            return option;
        }

        internal static int ShowPowerUserMenu(User user)
        {
            int option;

            string[,] powerUserMenu =
            {
                {"1.", " Search"},
                {"2.", " List"},
                {"3.", " Logout"},
            };


            Console.Clear();

            RSGymUtility.WriteTitle($"Power User Menu \t\t| Profile:{user.UserType}", "", "\n\n");

            for (int r = 0; r < powerUserMenu.GetLength(0); r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    RSGymUtility.WriteMessage($"{powerUserMenu[r, c]}");
                }

                RSGymUtility.WriteMessage("\n");
            }

            do
            {
                RSGymUtility.WriteMessage($"{user.Username}> ", "\n");

            } while (!int.TryParse(Console.ReadLine(), out option));


            return option;
        }

        internal static int ShowSimpleUserMenu(User user)
        {
            int option;

            string[,] simpleUserMenu =
            {
                {"1.", " List"},
                {"2.", " Logout"},
            };


            Console.Clear();

            RSGymUtility.WriteTitle($"Simple User Menu \t\t| Profile:{user.UserType}", "", "\n\n");

            for (int r = 0; r < simpleUserMenu.GetLength(0); r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    RSGymUtility.WriteMessage($"{simpleUserMenu[r, c]}");
                }

                RSGymUtility.WriteMessage("\n");
            }

            do
            {
                RSGymUtility.WriteMessage($"{user.Username}> ", "\n");

            } while (!int.TryParse(Console.ReadLine(), out option));

            return option;
        }
        #endregion

        #region Login Method
        internal static User Login(ILoginService loginService)
        {

            RSGymUtility.WriteMessage("Username: ");
            string username = Console.ReadLine();
            RSGymUtility.WriteMessage("Password: ");
            string password = ReadPassword();

            // Autenticar usuário
            User loggedInUser = loginService.Login(username, password);

            if (loggedInUser == null)
            {
                Console.WriteLine("Login failed, please try again");
            }

            return loggedInUser;
        }
        #endregion



    }
}
