using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4_3
{
    class Program
    {
        enum season
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }

        static void Main(string[] args)
        {
            int month = 0;
            const int Jan = 1, Dec = 12;

            Console.WriteLine("Введите номер месяца:");
            month = Convert.ToInt32(Console.ReadLine());
            if (month >= Jan && month <= Dec)
            {
                Console.WriteLine($"Введенный месяц принадлежит к сезону {monthToSeason(month)}");
                Console.WriteLine($"Это время года {SeasonToRus(monthToSeason(month))}");
            }
            else
            {
                Console.WriteLine("Ошибка: Введите число от 1 до 12");
                return;
            }

            Console.ReadLine();
        }

        static season monthToSeason(int month)
        {
            
            if (month == 12 || month == 1 || month == 2) return season.Winter;
            if (month == 3 || month == 4 || month == 5) return season.Spring;
            if (month == 6 || month == 7 || month == 8) return season.Summer;
            return season.Autumn;
            
        }

        static string SeasonToRus(season SeasonEng)
        {
            switch (SeasonEng)
            {
                case season.Winter: return "Зима";
                case season.Spring: return "Весна";
                case season.Summer: return "Лето";
                case season.Autumn: return "Осень";
                default: return "Непонятный сезон";
            }
                
        }

    }
}
