using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;



namespace ManagementSystem
{
    internal class Program
    {
        private static string _login;
        private static string _password;
        private static int _option;

        private static List<User> _users;
        private static List<Role> _roles;
        private static List<Status> _statuses;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            _users = FillData.FillUsers();
            _roles = FillData.FillRoles();
            _statuses = FillData.FillStatus();

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
                while (true)
                {
                    if (Login(_users, _roles))
                    {
                        
                        string _role = Authentification.GetRole(_login, _password, _users, _roles);

                        switch (_role)
                        {
                            case "Manager":
                                MenuDisplay.ManagerMenu(_option, _roles);
                                break;
                            case "Worker":
                                MenuDisplay.WorkerMenu(_option, Authentification.GetId(_login, _password, _users));
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



        private static bool Login(List<User> users, List<Role> roles)
        {
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("\nАвторизация\n");//Я подготовил двух пользователей
                                                 //Введите Manager Manager чтобы войти под управляющим
                                                 //Введите Worker Worker чтобы войти под работником
            _login = Input.GetLoginInput(_login);
            _password = Input.GetPasswordInput(_password);

            return Authentification.AuthenticateUser(_login, _password, users, roles);
        }
    }
}
