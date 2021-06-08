using System;
using System.Collections.Generic;
using System.Text;

namespace UnitPlay
{
    public class FizzBuzz
    {
        public static string Execute(int input)
        {
            string result = string.Empty;
            //if (input % 3 == 0 && input % 5 == 0)
            //{
            //    return "fizzbuzz";
            //}

            if (input % 3 == 0)
            {
                result += "fizz";
            }

            if (input % 5 == 0)
            {
                result += "buzz";
            }

            if (string.IsNullOrEmpty(result))
            {
                result += input.ToString();
            }
            //return input.ToString();
            return result;
        }
    }
}
