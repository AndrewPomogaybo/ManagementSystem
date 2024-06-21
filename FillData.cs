using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class FillData
    {
        public static List<User> FillUsers()
        {
            List<User> _users = new List<User>
            {
                new User { User_id = 1, User_name = "Manager", User_surname = "Manager", User_login = "Manager", User_password = "Manager", User_role = 1 },
                new User { User_id = 2, User_name = "Worker", User_surname = "Worker", User_login = "Worker", User_password = "Worker", User_role = 2 }
            };

            return _users;
        }

        public static List<Role> FillRoles()
        {
            List<Role> _roles = new List<Role>
            {
                new Role { Role_id = 1, Role_name = "Manager" },
                new Role { Role_id = 2, Role_name = "Worker" }
            };

            return _roles;
        }

        public static List<Status> FillStatus()
        {
            List<Status> _statuses = new List<Status>
            {
                new Status {Status_id = 1, Status_name = "To do"},
                new Status {Status_id = 2, Status_name = "In Progress"},
                new Status {Status_id = 3, Status_name = "Done"}
            };

            return _statuses;
        }
    }
}
