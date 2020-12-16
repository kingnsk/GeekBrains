using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] phoneBook = new string[5, 2];

            //Заполним телефонный справочник

            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.WriteLine($"Введите данные контакта №{i}");
                Console.WriteLine("Имя:");
                phoneBook[i, 0] = Console.ReadLine();
                Console.WriteLine("Телефон/e-mail:");
                phoneBook[i, 1] = Console.ReadLine();

            }

            //Напечатаем справочник

            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.WriteLine($"{i}      Имя: {phoneBook[i,0]}             Телефон/e-mail: {phoneBook[i,1]} ");
            }
        }
    }
}
