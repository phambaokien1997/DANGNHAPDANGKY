using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookCommonLibs
{
    public class BookValidationData
    {
        public static bool ContainersNumber(string input) // Check tat ca la so
        {
            if (input.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckContainSpecialChar(string input)
        {
            Regex regex = new Regex(@"[!@#$%^&*()_+{}\[\]:;<>,.?/~`\-|=\\\""']");
            if (regex.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckIsNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ContainersLetter(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckLenght(string input)
        {
            if (input.Length > 50)
            {
                return false;
            }
            return true;
        }
    }
}
