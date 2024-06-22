using ManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.View
{
    public class AuthDisplay
    {
        private static User _currentUser;
        private static Role _currentRole;

        public static bool Login(List<User> users, List<Role> roles)
        {
            string _login = Input.GetLoginInput();
            string _password = Input.GetPasswordInput();

            var _user = JsonFileHandler.ReadFromJson<List<User>>("users.json");
            var _role = JsonFileHandler.ReadFromJson<List<Role>>("roles.json");

            _currentUser = _user.FirstOrDefault(u => u.User_login == _login && u.User_password == _password);

            if(_currentUser != null)
            {
                _currentRole = _role.FirstOrDefault(r => r.Role_id == _currentUser.User_role);
                return true;
            }

            return false;
        }

        public static string GetRole()
        {
            return _currentRole.Role_name;
        }

        public static int GetId()
        {
            return _currentUser.User_id;
        }
    }
}
