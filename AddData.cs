using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;


namespace ManagementSystem
{
    public class AddData
    {
        public static void AddUser(string userPath, List<Role> roles, string name, string surname, string login, string pwd, int role)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            User _newUser = new User();
            List<User> _users = JsonFileHandler.ReadFromJson<List<User>>(userPath);
            _newUser.User_id = Generate.GenerateId(_users, "User_id");
            _newUser.User_surname = surname;
            _newUser.User_name = name;
            _newUser.User_login = login;
            _newUser.User_password = pwd;
            _newUser.User_role = role;

            AddToJson(userPath, _newUser);
            
        }

        public static void AddTask(string taskPath, string name, string description, int user)
        {
            Task _newTask = new Task();
            List<Task> _tasks = JsonFileHandler.ReadFromJson<List<Task>>(taskPath);

            _newTask.Task_id = Generate.GenerateId(_tasks, "Task_id");
            _newTask.Task_name = name;
            _newTask.Task_description = description;
            _newTask.Task_user = user;
            _newTask.Task_status = 1;

            AddToJson(taskPath, _newTask);
        }

        public static void AddToJson<T>(string path, T newData)
        {
            List<T> dataList;

            if (File.Exists(path))
                dataList = JsonFileHandler.ReadFromJson<List<T>>(path);
            else
                dataList = new List<T>();

            dataList.Add(newData);
            JsonFileHandler.SaveToJson(path, dataList);
        }

    }
}
