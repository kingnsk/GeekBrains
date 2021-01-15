using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число [0-255]");
            byte inputNumber = Convert.ToByte(Console.ReadLine());
            if(inputNumber%2==0)
            {
                Console.WriteLine($"Число {inputNumber} четное");
            } 
            else
            {
                Console.WriteLine($"Число {inputNumber} нечетное");
            }

        }
    }
}
