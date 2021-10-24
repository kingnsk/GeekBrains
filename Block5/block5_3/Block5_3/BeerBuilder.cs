using System;
using System.Collections.Generic;
using System.Text;

namespace Block5_3
{
    abstract class BeerBuilder
    {
        public Beer Beer { get; private set; }
        public void CreateBeer()
        {
            Beer = new Beer();
        }
        public abstract void SetWater();
        public abstract void SetMalt();
        public abstract void SetHop();
        public abstract void SetYeast();
        public abstract void SetBarley();
        public abstract void SetAdditives();
    }
}
