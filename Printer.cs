using ManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace ManagementSystem
{
    public class Printer
    {
        public void PrintUsers(List<User> users)
        {
            Console.WriteLine("Пользвоатели:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.User_id}, Имя: {user.User_name}, Фамилия: {user.User_surname}, Логин: {user.User_login}, Пароль: {user.User_password}");
            }
        }

        public void PrintRoles(List<Role> roles)
        {
            Console.WriteLine("Роли:");
            foreach (var role in roles)
            {
                Console.WriteLine($"ID: {role.Role_id}, Роль: {role.Role_name}");
            }
        }
    }
}
