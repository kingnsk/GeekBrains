using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер члена последовательности Фибоначчи:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{n}-й член Фибоначчи равен {fibonachi(n).ToString()}");
        }

        static int fibonachi(int n)
        {
            if (n == 0)
            {
                return 0; // 0-й член последовательности Фиббоначчи = 0
            }
            else if (n == 1)
            {
                return 1; // 1-й член последовательности Фиббоначчи = 1
            }
            else
            {
                return fibonachi(n - 1) + fibonachi(n - 2);
            }
        }
    }
}
