using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int testNumber = 0;

            Console.WriteLine("Введите целое число:");
            testNumber = Convert.ToInt32(Console.ReadLine());
            if(testNumber%2==0)                                 // у четного числа остаток от деления на 2 будет равен 0
                {
                Console.WriteLine($"Число {testNumber} четное");
                }
            else
                {
                Console.WriteLine($"Число {testNumber} нечетное");
            }
        }
    }
}
