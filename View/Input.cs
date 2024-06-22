using System;

namespace ManagementSystem
{
    public class Input
    {
        public static string GetLoginInput()
        {
            Console.WriteLine("Логин:");
            return Console.ReadLine();
        }

        public static int GetManagerOptionInput(int option)
        {
            Console.WriteLine("Меню:" + "" +
                                "\n 1-Просмотр БД" + "\n 2-Добавить задачу" + "\n 3-Добавить сотрудника \n 4-Просмотр логов \n 5-Выход");

            return option = Convert.ToInt32(Console.ReadLine());
        }

        public static int GetWorkerOptionInput(int option)
        {
            Console.WriteLine("Меню:" + "\n 1-Просмотр задач \n 2-Обновить статус задачи \n 3-Выход");
            return option = Convert.ToInt32(Console.ReadLine());
        }

        public static string GetPasswordInput()
        {
            Console.WriteLine("Пароль:");
            return Console.ReadLine();
        }

    }
}
