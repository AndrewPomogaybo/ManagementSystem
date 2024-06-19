using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class FileValidator
    {
        private static  bool FileExisting(string path)
        {
            if (!File.Exists(path))
                return false;
            return true;
        }

        public static void ShowValidation(string path)
        {
            if (!FileExisting(path))
                Console.WriteLine($"Файл {path} не используется");
        }
    }
}
