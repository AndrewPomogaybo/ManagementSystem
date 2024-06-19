using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class User
    {
        public int User_id { get; set; } = 1;
        public string User_name { get; set; } = "Manager";
        public string User_surname { get; set; } = "Manager";
        public string User_login { get; set; } = "Manager";
        public string User_password { get; set; } = "Manager";
        public int User_role { get; set; } = 1;

    }
}
