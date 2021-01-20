using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            int n = Convert.ToInt32(Console.ReadLine());
            if (simple_number(n)) Console.WriteLine($"Число {n} простое"); else Console.WriteLine($"Число {n} НЕ простое");
        }

        static bool simple_number(int number)
        {
            int d = 0, i = 2;
            while (i<number)
            {
                if (number % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            if (d==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
