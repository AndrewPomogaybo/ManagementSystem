using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class ValidateInput
    {
        public static string GetFilteredInput(string option)
        {
            StringBuilder _input = new StringBuilder();

            while (true)
            {
                var _keyInfo = Console.ReadKey(intercept: true);

                char _keyChar = _keyInfo.KeyChar;

                if(_keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (!IsRussianChar(_keyChar) && !char.IsControl(_keyChar))
                {
                    _input.Append(_keyChar);
                }
            }

            return _input.ToString();
        }

        private static bool IsRussianChar(char c)
        {
            return Regex.IsMatch(c.ToString(),"[А-Яа-яЁё]");
        }
    }
}
