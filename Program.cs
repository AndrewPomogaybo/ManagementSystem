
using ManagementSystem.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;



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

            List<User> _users = new List<User>();

            _users = GenerateData.WriteData(_users);
            UserLoader _userLoader = new UserLoader("users.json");
            _userLoader.SaveUserToJson(_users);

            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("");
            Console.WriteLine("Авторизация");
            Console.WriteLine("");
            Console.WriteLine("Логин:");
            _login = Console.ReadLine();
            Console.WriteLine("Пароль:");
            _password = Console.ReadLine();


            if(Auntification.IsCorrectAuth(_login, _password, _users) != null)
            {
                Console.WriteLine($"Добро пожаловать {Auntification.IsCorrectAuth(_login, _password, _users).User_name}");
                Console.WriteLine("");
                string _role = Auntification.GetRole(Auntification.IsCorrectAuth(_login, _password, _users).User_id, _users)[0]?.Role_name;

                switch (_role)
                {
                    case "manager":
                        Console.WriteLine("Вход выполнен как управляющий");

                        Console.WriteLine("Меню:" +
                            "\n1-Посмотреть Базу"+"" +
                            "\n2-Назначить задачу"+
                            "\n3-Добавить сотрудника");
                        _option = Convert.ToInt32(Console.ReadLine());

                        OptionsController.ShowOption(_option, _users);

                        break;
                    case "worker":
                        Console.WriteLine("Вход выполнен как работник");

                        Console.WriteLine("Меню:" +
                            "\n1-Посмотреть задачи");
                        break;

                }
            }
            Console.ReadKey();
        }
    }
}
