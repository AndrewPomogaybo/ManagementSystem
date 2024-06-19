using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class Authentification
    {
        public static bool AuthenticateUser(string login, string password, List<User> users, List<Role> roles)
        {
            var user = users.FirstOrDefault(u => u.User_login == login && u.User_password == password);
            if (user == null)
            {
                return false;
            }
            return true;
            
        }

        public static string GetRole(string login, string password, List<User> users, List<Role> roles)
        {
            var user = users.FirstOrDefault(u => u.User_login == login && u.User_password == password);
            var role = roles.FirstOrDefault(r => r.Role_id == user.User_role);
            return role != null ? $"{role.Role_name}" : "Роль не найдена";
        }
    }
}
