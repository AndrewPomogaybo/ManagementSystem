
using System;
using System.Security.Cryptography;
using System.Text;

namespace ManagementSystem
{
    public class User
    {
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_surname { get; set; }
        public string User_login { get; set; }
        public string User_password { get; set; }
        public int User_role { get; set; }

    }
}
