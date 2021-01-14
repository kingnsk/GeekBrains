using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_ENTRY = 100;
            byte[] input = new byte[MAX_ENTRY];
            string filenamePath = "output_data.bin";
            Console.WriteLine($"Введите числа [0-255] (макисимум {MAX_ENTRY} зачений) для записи в бинарный файл. Окончание ввода - число за пределами диапазона.");

            int inp = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (inp>=byte.MinValue && inp<=byte.MaxValue)
            {
                input[i] = (byte)inp;
                i++;
                inp = Convert.ToInt32(Console.ReadLine());
            }
            File.WriteAllBytes(filenamePath, input);
        }
    }
}
