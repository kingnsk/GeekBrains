using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less1_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите номер члена последовательности Фибоначчи:");
            int n = Convert.ToInt32(Console.ReadLine());
            int n1=0, n2=1;
            int result = 0;
            if (n == 0) result = n1;
            else
                if (n == 1) result = n2;
            for (int i = 1; i< n; i++)
            {
                result = n1 + n2;
                n1 = n2;
                n2 = result;
            }
            Console.WriteLine($"Число последовательности: {result}");
                
            

        }
    }
}
