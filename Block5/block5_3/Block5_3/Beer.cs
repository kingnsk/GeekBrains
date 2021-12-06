using System;
using System.Collections.Generic;
using System.Text;

namespace Block5_3
{
    class Beer : BeerComponents
    {
        // Вода
        public Water Water { get; set; }
        // Солод
        public Malt Malt { get; set; }
        // Хмель
        public Hop Hop { get; set; }
        // Дрожжи
        public Yeast Yeast { get; set; }
        // Ячмень
        public Barley Barley { get; set; }
        // Добавки 
        public Additivies Additivies { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            if(Water != null)
            {
                sb.Append("Жесткость воды: "+Water.Water_pH + "\n");
            }

            if(Malt != null)
            {
                sb.Append("Тип Солода: "+Malt.MaltType + "\n");
            }

            if (Hop != null)
            {
                sb.Append("Хмель\n");
            }

            if (Yeast != null)
            {
                sb.Append("Дрожжи\n");
            }

            if (Barley != null)
            {
                sb.Append("Ячмень: " + Barley.Species + "\n");
            }

            if (Additivies != null)
            {
                sb.Append("Добавки: " + Additivies.Name + "\n");
            }

            return sb.ToString();
        }
    }
}
