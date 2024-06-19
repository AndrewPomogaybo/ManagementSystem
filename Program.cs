using ManagementSystem.Models;
using System;
using System.Collections.Generic;



namespace ManagementSystem
{
    internal class Program
    {
        private static string _login;
        private static string _password;
        private static int _option;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<User> _users = new List<User>
            {
                new User { User_id = 1, User_name = "Manager", User_surname = "Manager", User_login = "Manager", User_password = "Manager", User_role = 1 },
                new User { User_id = 2, User_name = "Worker", User_surname = "Worker", User_login = "Worker", User_password = "Worker", User_role = 2 }
            };

            List<Role> _roles = new List<Role>
            {
                new Role { Role_id = 1, Role_name = "Manager" },
                new Role { Role_id = 2, Role_name = "Worker" }
            };

            JsonFileHandler.SaveToJson("users.json", _users);
            JsonFileHandler.SaveToJson("roles.json", _roles);

        _auth:
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("");
            Console.WriteLine("Авторизация");
            Console.WriteLine("");
            Console.WriteLine("Логин:");
            _login = Console.ReadLine();
            Console.WriteLine("Пароль:");
            _password = Console.ReadLine();

            if (Authentification.AuthenticateUser(_login,_password,_users,_roles))
            {
                string _role = Authentification.GetRole(_login, _password, _users, _roles);

                switch (_role)
                {
                    case "Manager":
                        Console.WriteLine("Вы вошли как управляющий");
                        Console.WriteLine("Меню:" + "" +
                            "\n 1-Просмотр БД" + "\n 2-Добавить задачу" + "\n 3-Добавить сотрудника \n 4-Выход");

                        _option = Convert.ToInt32(Console.ReadLine());

                        switch (_option)
                        {
                            case 1:
                               DataDisplay.Display();
                               break;
                            case 4:
                               goto _auth;      
                        }
                        break;

                    case "Worker":
                        Console.WriteLine("Вы вошли как работник");
                        Console.WriteLine("Меню:" + "\n 1-Просмотр задач \n 2-Выход");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Логин или пароль введен неверно!");
                goto _auth;
            }
            
            
            Console.ReadKey();
        }
    }
}
