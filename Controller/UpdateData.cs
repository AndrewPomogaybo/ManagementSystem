using System;
using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Models;

namespace ManagementSystem
{
    public class UpdateData
    {
        public static void UpdateTask(int id, int newStatus)
        {
            List<Task> _tasks = JsonFileHandler.ReadFromJson<List<Task>>("tasks.json");
            List<User> _userName = JsonFileHandler.ReadFromJson<List<User>>("users.json");
            List<Status> _statusName = JsonFileHandler.ReadFromJson<List<Status>>("statuses.json");

            var _task = _tasks.FirstOrDefault(t => t.Task_id == id);
            string _status = _statusName.FirstOrDefault(s => s.Status_id == newStatus)?.Status_name??"Не найдено";

            if (_task != null)
            {
                _task.Task_status = newStatus;
                JsonFileHandler.SaveToJson("tasks.json", _tasks);
                AddData.AddLog($"ID задачи:{_task.Task_id}, Статус изменен на {_status} ", id);
                Console.WriteLine($"Статус задачи  изменен");
            }
            else
                Console.WriteLine("Задача не найдена!");
        }

    }
}
