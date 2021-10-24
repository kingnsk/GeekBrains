using System;
using System.Collections.Generic;
using System.Text;

namespace Block5_3
{
    // Пивовар
    class Brewer
    {
        public Beer Brew(BeerBuilder beerBuilder)
        {
            beerBuilder.CreateBeer();
            beerBuilder.SetWater();
            beerBuilder.SetMalt();
            beerBuilder.SetHop();
            beerBuilder.SetYeast();
            beerBuilder.SetBarley();
            beerBuilder.SetAdditives();

            return beerBuilder.Beer;
        }
    }
}
