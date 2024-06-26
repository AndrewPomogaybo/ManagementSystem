﻿using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;


namespace ManagementSystem
{
    public class AddData
    {
        public static void AddUser(string userPath, List<Role> roles, string name, string surname, string login, string pwd, int role)
        {
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
            List<T> _dataList;

            if (File.Exists(path))
                _dataList = JsonFileHandler.ReadFromJson<List<T>>(path);
            else
                _dataList = new List<T>();

            _dataList.Add(newData);
            JsonFileHandler.SaveToJson(path, _dataList);
        }


        public static void AddLog(string action, int userId)
        {
            Log _newLog = new Log();
            List<Log> _log = JsonFileHandler.ReadFromJson<List<Log>>("logs.json");

            _newLog.Log_id = Generate.GenerateId(_log, "Log_id");
            _newLog.Log_name = action;
            _newLog.Log_user = userId;
            _newLog.Log_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            AddToJson("logs.json", _newLog);
        }
    }
}
