using System;
using System.Collections.Generic;
using System.Text;

namespace Block5_3
{
    class DarkBeerBuilder : BeerBuilder
    {
        public override void SetAdditives()
        {
            // без вкусовых добавок
        }

        public override void SetBarley()
        {
            this.Beer.Barley = new BeerComponents.Barley { Species = "средней обжарки" };
        }

        public override void SetHop()
        {
            this.Beer.Hop = new BeerComponents.Hop { UseHop = true };
        }

        public override void SetMalt()
        {
            this.Beer.Malt = new BeerComponents.Malt { MaltType = "темный солод (карамельный)" };
        }

        public override void SetWater()
        {
            this.Beer.Water = new BeerComponents.Water { Water_pH = "9,2 dGH" };
        }

        public override void SetYeast()
        {
            this.Beer.Yeast = new BeerComponents.Yeast { UseYeast = true };
        }
    }
}
