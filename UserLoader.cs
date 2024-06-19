using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace ManagementSystem
{
    public class UserLoader
    {
        private string _filePath;
        public UserLoader(string filePath) 
        { 
            _filePath = filePath;
        }

        public string SaveUserToJson(List<User> users)
        {
            string _json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, _json);

            return "Пользователи сохранены в users.json";
        }

        public List<User> LoadUsers()
        {
            return JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_filePath));
        }
    }
}
