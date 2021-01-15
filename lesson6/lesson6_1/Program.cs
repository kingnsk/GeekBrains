using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lesson6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbolOfSplit = ' ';
            Process[] procList = Process.GetProcesses();

            if (args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "--help":
                        Console.WriteLine("Параметры командной строки:");
                        Console.WriteLine("--help - этот текст");
                        Console.WriteLine("--list - получить список процессов");
                        Console.WriteLine("--find <process name> - найти подходящие процессы");
                        Console.WriteLine("--id <process ID> - завершить процесс ID");
                        Console.WriteLine("--name <process name> - завершить процесс name");
                        return;

                    case "--id":
                        Process.GetProcessById(Convert.ToInt32(args[1])).Kill();
                        return;

                    case "--name":
                        Process.GetProcessesByName(args[1])[0].Kill();
                        return;

                    case "--list":
                        foreach (Process p in procList)
                            Console.WriteLine($"{p.Id: ######}         {p.ProcessName}");
                        return;
                    case "--find":
                        foreach (Process p in procList)
                            if (p.ProcessName.Contains(args[1].ToLower())) Console.WriteLine($"{p.Id: ######}         {p.ProcessName}");
                        return;
                }
            }
            else
            {


                foreach (Process p in procList)
                    Console.WriteLine($"{p.Id: ######}         {p.ProcessName}");

                Console.WriteLine("Для завершения процесса по ID введите:i <ID процесса> ");
                Console.WriteLine("Для завершения процесса по имени введите:n <Имя процесса> ");
                string inputString = Console.ReadLine();
                string[] words = inputString.Split(symbolOfSplit);
                switch (words[0])
                {
                    case "i":
                        Process.GetProcessById(Convert.ToInt32(words[1])).Kill();
                        return;

                    case "n":
                        Process.GetProcessesByName(words[1])[0].Kill();
                        return;

                    default:
                        Console.WriteLine("Ошибка ввода!");
                        break;
                }
            }
        }
    }
}
