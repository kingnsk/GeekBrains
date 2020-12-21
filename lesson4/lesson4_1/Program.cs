using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstN, lastN, patronymicN;

            for (int i = 0; i < 3; i++)
            {
                AskName(out firstN, out lastN, out patronymicN);
                Console.WriteLine($"ФИО: {GetFullName(firstN, lastN, patronymicN)}");
            }
            
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return firstName + " " + lastName + " " + patronymic;
        }

        static void AskName(out string firstName,out string lastName, out string patronymic)
        {
            Console.WriteLine("Введите Фамилилю:");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите Имя:");
            lastName = Console.ReadLine();
            Console.WriteLine("Введите Отество:");
            patronymic = Console.ReadLine();
        }
    }
}
