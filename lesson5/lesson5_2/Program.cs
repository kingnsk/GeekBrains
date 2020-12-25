using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "startup.txt";
            string output = DateTime.Now.ToString("T")+Environment.NewLine;
            File.AppendAllText(filename, output);
            Console.WriteLine("Текущее время записано в startup.txt");
        }
    }
}
