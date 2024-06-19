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
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_surname { get; set; }
        public string User_login { get; set; }
        public string User_password { get; set;}

        public List<Role> Roles { get; set; } = new List<Role>();

    }
}
