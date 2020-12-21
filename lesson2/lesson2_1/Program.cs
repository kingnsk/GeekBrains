using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            int minTemperature=0, maxTemperature=0, avgTemperature=0;
            
            Console.WriteLine("Введите минимальную суточную температуру (-72 С min):");
            do
            {
                minTemperature = Convert.ToInt32(Console.ReadLine());
            } while (minTemperature <= -72 && minTemperature >=72);

            Console.WriteLine("Введите максимальную суточную температуру (+72 С max):");
            do
            {
                maxTemperature = Convert.ToInt32(Console.ReadLine());
            } while (maxTemperature <= -72 && maxTemperature >= 72);

            avgTemperature = (minTemperature + maxTemperature) / 2;

            Console.WriteLine($"Среднесуточная температура за сутки: {avgTemperature}  C");
        }
    }
}
