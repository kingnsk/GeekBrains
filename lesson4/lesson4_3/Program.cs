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

        const byte Jan = 1, Feb = 2, Mar = 3, Apr = 4, May = 5, Jun = 6, Jul = 7, Aug = 8, Sep = 9, Oct = 10, Nov = 11, Dec = 12;

        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите номер месяца:");
            byte month = Convert.ToByte(Console.ReadLine());
            if (month >= Jan && month <= Dec)
            {
                Console.WriteLine($"Введенный месяц принадлежит к сезону {MonthToSeason(month)}");
                Console.WriteLine($"Это время года {SeasonToRus(MonthToSeason(month))}");
            }
            else
            {
                Console.WriteLine("Ошибка: Введите число от 1 до 12");
                return;
            }

            Console.ReadLine();
        }

        static season MonthToSeason(byte month)
        {
            
            if (month == Dec || month == Jan || month == Feb) return season.Winter;
            if (month == Mar || month == Apr || month == May) return season.Spring;
            if (month == Jun || month == Jul || month == Aug) return season.Summer;
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
