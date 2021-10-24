using System;
using System.Collections.Generic;
using System.Text;

namespace Block5_3
{
    class CherryBeerBuilder : BeerBuilder
    {
        public override void SetAdditives()
        {
            this.Beer.Additivies = new BeerComponents.Additivies { Name = "Вишневый концентрат"};
        }

        public override void SetBarley()
        {
            // не добавляется
        }

        public override void SetHop()
        {
            this.Beer.Hop = new BeerComponents.Hop { UseHop = true };
        }

        public override void SetMalt()
        {
            this.Beer.Malt = new BeerComponents.Malt { MaltType = "светлый солод" };
        }

        public override void SetWater()
        {
            this.Beer.Water = new BeerComponents.Water { Water_pH = "5,9 dGH" };
        }

        public override void SetYeast()
        {
            this.Beer.Yeast = new BeerComponents.Yeast { UseYeast = true };
        }
    }
}
