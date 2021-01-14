using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "output.txt";
            Console.WriteLine("Введите строку для записи в файл:");
            string inputString = Console.ReadLine();
            File.WriteAllText(filename, inputString);
            Console.WriteLine("Данные записаны!");
        }
    }
}
