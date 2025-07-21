using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeStar.Domain.Validators
{
    public static class ValidatorExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidIranianMobile(this string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                return false;

            return Regex.IsMatch(mobile, @"^09\d{9}$");
        }

        public static bool IsValidIranianNationalCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length != 10 || !code.All(char.IsDigit))
                return false;

            var check = int.Parse(code[9].ToString());
            var sum = code.Take(9)
                          .Select((x, i) => int.Parse(x.ToString()) * (10 - i))
                          .Sum() % 11;

            return (sum < 2 && check == sum) || (sum >= 2 && check + sum == 11);
        }
    }
}
