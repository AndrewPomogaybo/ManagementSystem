using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ManagementSystem
{
    public class DataDisplay
    {
        public static void Display() 
        {
            List<User> _readUsers = JsonFileHandler.ReadFromJson<List<User>>("users.json");
            List<Role> _readRoles = JsonFileHandler.ReadFromJson<List<Role>>("roles.json");

            // Вывод данных
            Console.WriteLine("Пользователи:");
            foreach (var user in _readUsers)
            {
                Console.WriteLine($"ID: {user.User_id}, Имя: {user.User_name}, Фамилия: {user.User_surname}, Логин: {user.User_login}, Роль: {user.User_role}");
            }

            Console.WriteLine("\nРоли:");
            foreach (var role in _readRoles)
            {
                Console.WriteLine($"ID: {role.Role_id}, Название: {role.Role_name}");
            }
        }

        public static void DisplayUsers()
        {
            List<User> _readUsers = JsonFileHandler.ReadFromJson<List<User>>("users.json");
            List<Role> _roles = JsonFileHandler.ReadFromJson<List<Role>>("roles.json");

            var _filteredUsers = _readUsers.Where(user => user.User_role == 2).ToList();

            Console.WriteLine("Пользователи:");
            foreach (var user in _filteredUsers)
            {
                string roleName = _roles.FirstOrDefault(r => r.Role_id == user.User_role)?.Role_name ?? "Не найдено";
                Console.WriteLine($"ID: {user.User_id}, Имя: {user.User_name}, Фамилия: {user.User_surname}, Логин: {user.User_login}, Роль: {roleName}");
            }
        }
    }
}
