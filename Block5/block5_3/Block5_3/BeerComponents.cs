using System;
using System.Collections.Generic;
using System.Text;

namespace Block5_3
{
    class BeerComponents
    {
        // Вода
        public class Water
        {
            // жесткость используемой воды
            public string Water_pH { get; set; }
        }

        // Солод
        public class Malt
        {
            // тип солода
            public string MaltType { get; set; }
        }

        // Хмель
        public class Hop 
        {
            public bool UseHop { get; set; }
        }

        // Дрожжи
        public class Yeast
        {
            public bool UseYeast { get; set; }
        }

        // Ячмень
        public class Barley
        {
            // Разновидность ячменя
            public string Species { get; set; }

        }

        // Различные добавки
        public class Additivies
        {
            public string Name { get; set; }
        }
    }
}
