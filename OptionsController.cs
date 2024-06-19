using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class OptionsController
    {
        public static void ShowOption(int option, List<User> users)
        {
            switch(option)
            {
                case 1:
                    Printer _print = new Printer();
                    _print.PrintUsers(users);
                    _
                    break;
            }
        }
    }
}
