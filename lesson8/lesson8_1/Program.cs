using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string greetings;

            if (string.IsNullOrEmpty(Properties.Settings.Default.Greetings))
            {
                greetings = "В настройках не сохранено приветствие!";
            } 
            else
            {
                greetings = Properties.Settings.Default.Greetings;
            }
            Console.WriteLine($"Приветствие, записанное в настройках приложения (application-scope): {greetings}");

            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                Console.WriteLine("Как Вас зовут?");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine($"Вас зовут: {Properties.Settings.Default.UserName}");
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.UserAge))
            {
                Console.WriteLine("Сколько Вам лет?");
                Properties.Settings.Default.UserAge = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine($"Ваш возраст: {Properties.Settings.Default.UserAge}");
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.UserProfession))
            {
                Console.WriteLine("Какой Ваш род деятельности?");
                Properties.Settings.Default.UserProfession = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine($"Вы занимаетесь: {Properties.Settings.Default.UserProfession}");
            }


        }
    }
}
