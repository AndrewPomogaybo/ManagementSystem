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

            var _task = _tasks.FirstOrDefault(t => t.Task_id == id);

            if (_task != null)
            {
                _task.Task_status = newStatus;
                JsonFileHandler.SaveToJson("tasks.json", _tasks);
                Console.WriteLine($"Статус задачи  изменен");
            }
            else
                Console.WriteLine("Задача не найдена!");
        }

    }
}
