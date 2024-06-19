
using ManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;


namespace ManagementSystem
{
    public class Auntification
    {
        public static User IsCorrectAuth(string login, string password, List<User> users)
        {
            foreach (var user in users)
            {
                if(user.User_login == login && user.User_password == password)
                    return user;
            }
            return null;
        }

        public static List<Role> GetRole(int userId, List<User> users)
        {

            foreach (var user in users)
            {
                if (user.User_id == userId)
                {
                    return user.Roles;
                }
            }
            return new List<Role>();
        }
    }
}
