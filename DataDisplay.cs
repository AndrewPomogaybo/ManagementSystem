using ManagementSystem.Models;
using System;
using System.Collections.Generic;


namespace ManagementSystem
{
    public class DataDisplay
    {
        public static void Display() 
        {
            List<User> readUsers = JsonFileHandler.ReadFromJson<List<User>>("users.json");
            List<Role> readRoles = JsonFileHandler.ReadFromJson<List<Role>>("roles.json");

            // Вывод данных
            Console.WriteLine("Пользователи:");
            foreach (var user in readUsers)
            {
                Console.WriteLine($"ID: {user.User_id}, Имя: {user.User_name}, Фамилия: {user.User_surname}, Логин: {user.User_login}, Роль: {user.User_role}");
            }

            Console.WriteLine("\nРоли:");
            foreach (var role in readRoles)
            {
                Console.WriteLine($"ID: {role.Role_id}, Название: {role.Role_name}");
            }
        }
    }
}
