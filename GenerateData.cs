using ManagementSystem.Models;
using System.Collections.Generic;

namespace ManagementSystem
{
    public class GenerateData
    {
        public static List<User> WriteData(List<User> users)
        {
            Role adminRole = new Role { Role_id = 1, Role_name = "manager" };
            Role userRole = new Role { Role_id = 2, Role_name = "worker" };

            User user1 = new User { User_id = 2, User_name = "Manager", User_login = "Manager", User_password = "Manager", User_surname = "Manager" };
            user1.Roles.Add(adminRole);
            user1.Roles.Add(userRole);

            User user2 = new User { User_id = 1, User_name = "Worker", User_login = "Worker", User_password = "Worker", User_surname = "Worker" };
            user2.Roles.Add(userRole);

            users = new List<User> { user1, user2 };

            return users;
        }
    }
}
