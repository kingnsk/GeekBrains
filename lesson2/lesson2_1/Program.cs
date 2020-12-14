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
            
            Console.WriteLine("Введите минимальную суточную температуру (-50 С min):");
            do
            {
                minTemperature = Convert.ToInt32(Console.ReadLine());
            } while (minTemperature <= -50 && minTemperature >=50);

            Console.WriteLine("Введите максимальную суточную температуру (+50 С max):");
            do
            {
                maxTemperature = Convert.ToInt32(Console.ReadLine());
            } while (maxTemperature <= -50 && maxTemperature >= 50);

            avgTemperature = (minTemperature + maxTemperature) / 2;

            Console.WriteLine($"Среднесуточная температура за сутки: {avgTemperature}  C");
        }
    }
}
