using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class MenuDisplay
    {
        public static void ManagerMenu(int option, List<Role> roles)
        {
            
            Console.WriteLine("Вы вошли как управляющий");
            while (true)
            {
                option = Input.GetOptionInput(option);

                switch (option)
                {
                    case 1:
                        DataDisplay.Display();
                        break;
                    case 3:
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        Console.WriteLine("Введите имя:");
                        string _userName = Console.ReadLine();
                        Console.WriteLine("Введите фамилию:");
                        string _userSurname = Console.ReadLine();
                        Console.WriteLine("Введите логин:");
                        string _userLogin = Console.ReadLine();
                        Console.WriteLine("Введите пароль:");
                        string _userPassword = Console.ReadLine();
                        Console.WriteLine("Выберите роль (1-Управляющий, 2-Работник)");
                        int _userRole = Convert.ToInt32(Console.ReadLine());

                        AddData.AddUser("users.json", roles, _userName, _userSurname, _userLogin, _userPassword, _userRole);
                        Console.WriteLine("Успешно");
                        break;
                    case 2:
                        Console.WriteLine("Назовите задачи");
                        string _taskName = Console.ReadLine();
                        Console.WriteLine("Опишите задачу");
                        string _taskDescription = Console.ReadLine();
                        Console.WriteLine("Назначьте пользователя (Введите идентификатор)");
                        DataDisplay.DisplayUsers();
                        int _taskUser = Convert.ToInt32(Console.ReadLine());

                        AddData.AddTask("tasks.json", _taskName, _taskDescription, _taskUser);
                        Console.WriteLine("Успешно");
                        break;
                    case 4:
                        continue;
                }
            }
        } 
    }
}
