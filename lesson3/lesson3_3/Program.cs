using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = "";

            Console.WriteLine("Введите строку:");
            inputString = Console.ReadLine();

            Console.WriteLine("Переворачиваю введенную строку:");
            for (int i = inputString.Length; i > 0; i--)
            {
                Console.Write(inputString[i-1]);
            }
            Console.WriteLine();
        }
    }
}
