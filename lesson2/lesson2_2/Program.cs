using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte currentMonth = 1;

            Console.WriteLine("Введите порядковый номер текущего месяца [1 - 12]");

            do
            {
                currentMonth = Convert.ToByte(Console.ReadLine());
            } while (!(currentMonth >= 1 && currentMonth <= 12));

            DateTime month = new DateTime(2020, currentMonth,1);
            Console.WriteLine($"Месяц номер {currentMonth} называется {month.ToString("MMMMM")}");

        }
    }
}
