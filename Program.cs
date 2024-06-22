using ManagementSystem.Models;
using ManagementSystem.View;
using System;
using System.Collections.Generic;
using System.IO;

namespace ManagementSystem
{
    internal class Program
    {
        private static int _option;

        private static List<User> _users;
        private static List<Role> _roles;
        private static List<Status> _statuses;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (File.Exists("users.json"))
                _users = JsonFileHandler.ReadFromJson<List<User>>("users.json");

            if (File.Exists("roles.json"))
                _roles = JsonFileHandler.ReadFromJson<List<Role>>("roles.json");

            if (File.Exists("statuses.json"))
                _statuses = JsonFileHandler.ReadFromJson<List<Status>>("statuses.json");

            JsonFileHandler.SaveToJson("users.json", _users);
            JsonFileHandler.SaveToJson("roles.json", _roles);
            JsonFileHandler.SaveToJson("statuses.json", _statuses);

            try
            {
                Console.WriteLine("Добро пожаловать!");
                Console.WriteLine("\nАвторизация\n");
                while (true)
                {
                    if (AuthDisplay.Login(_users, _roles))
                    {
                        string _role = AuthDisplay.GetRole();

                        switch (_role)
                        {
                            case "Manager":
                                MenuDisplay.ManagerMenu(_option, _roles);
                                break;
                            case "Worker":
                                MenuDisplay.WorkerMenu(_option, AuthDisplay.GetId());
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный логин или пароль! Попробуйте снова");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
