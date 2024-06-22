using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ManagementSystem
{
    public class DataDisplay
    {
        private static List<User> _readUsers = JsonFileHandler.ReadFromJson<List<User>>("users.json");
        private static List<Role> _readRoles = JsonFileHandler.ReadFromJson<List<Role>>("roles.json");
        private static List<Status> _readStatuses = JsonFileHandler.ReadFromJson<List<Status>>("statuses.json");
        private static List<Task> _readTasks = JsonFileHandler.ReadFromJson<List<Task>>("tasks.json");
        public static void Display() 
        {
            Console.WriteLine("Пользователи:");
            foreach (var user in _readUsers)
            {
                var roleName = _readRoles.FirstOrDefault(r => r.Role_id == user.User_role)?.Role_name ?? "Unknown";
                Console.WriteLine($"ID: {user.User_id}, Имя: {user.User_name}, Фамилия: {user.User_surname}, Логин: {user.User_login}, Роль: {roleName}");
            }

            Console.WriteLine("\nРоли:");
            foreach (var role in _readRoles)
            {
                Console.WriteLine($"ID: {role.Role_id}, Название: {role.Role_name}");
            }

            Console.WriteLine("\nСтатусы:");
            foreach (var status in _readStatuses)
            {
                Console.WriteLine($"ID: {status.Status_id}, Название: {status.Status_name}");
            }

            Console.WriteLine("\nЗадачи:");
            foreach (var task in _readTasks)
            {
                string _userName = _readUsers.FirstOrDefault(u => u.User_id == task.Task_user)?.User_name ?? "Пользователь не найден";
                string _statusName = _readStatuses.FirstOrDefault(s => s.Status_id == task.Task_status)?.Status_name ?? "Статус не найден";
                string _userSurname = _readUsers.FirstOrDefault(u => u.User_id == task.Task_user)?.User_surname ?? "Пользователь не найден";

                Console.WriteLine($"ID: {task.Task_id}, Название: {task.Task_name}, Описание: {task.Task_description}, Назначенный пользователь: {_userName} {_userSurname}, Статус: {_statusName}");
            }
        }

        public static void DisplayUsers(bool hidePwd = false)
        {
            var _filteredUsers = _readUsers.Where(user => user.User_role == 2).ToList();

            Console.WriteLine("Пользователи:");
            foreach (var user in _filteredUsers)
            {
                string _roleName = _readRoles.FirstOrDefault(r => r.Role_id == user.User_role)?.Role_name ?? "Не найдено";
                Console.WriteLine($"ID: {user.User_id}, Имя: {user.User_name}, Фамилия: {user.User_surname}, Логин: {user.User_login}, Роль: {_roleName}");
            }
        }

        public static void DisplayTasks(int id)
        {
            var _currentUser = _readUsers.FirstOrDefault(u => u.User_id == id);

            if (_currentUser == null)
            {
                Console.WriteLine("Пользователь не найден");
                return;
            }

            var _userTasks = _readTasks.Where(t => t.Task_user == id).ToList();

            if (_userTasks.Any())
            {
                foreach (var task in _userTasks)
                {
                    var _statusName = _readStatuses.FirstOrDefault(s => s.Status_id == task.Task_status)?.Status_name ?? "Статус не найден";
                    Console.WriteLine($"Задача:  ID: {task.Task_id} Название задачи: {task.Task_name}, Описание задачи: {task.Task_description}, Статус задачи: {_statusName}");
                }
            }
        }
    }
}
