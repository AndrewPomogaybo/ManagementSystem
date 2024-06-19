using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class JsonFileHandler
    {
        public static void SaveToJson<T>(string path, T model)
        {
            string _json = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(path, _json);
        }

        public static T ReadFromJson<T>(string path)
        {
            FileValidator.ShowValidation(path);
            string _json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(_json);
        }
    }
}
