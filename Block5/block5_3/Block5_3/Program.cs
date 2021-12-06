using System;

namespace Block5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пивовар
            Brewer brewer = new Brewer();

            // создаем строителя для светлого пива
            BeerBuilder builder = new LigthBeerBuilder();
            // варим светлое пиво
            Console.WriteLine("Варим светлое пиво. Состав:");
            Beer lightBeer = brewer.Brew(builder);
            Console.WriteLine(lightBeer.ToString());

            // варим темное пиво
            Console.WriteLine("Варим темное пиво. Состав:");
            builder = new DarkBeerBuilder();
            Beer darkBeer = brewer.Brew(builder);
            Console.WriteLine(darkBeer.ToString());

            //варим вишневое пиво
            Console.WriteLine("Варим вишневое пиво. Состав:");
            builder = new CherryBeerBuilder();
            Beer cherryBeer = brewer.Brew(builder);
            Console.WriteLine(cherryBeer.ToString());

            Console.ReadLine();
        }
    }
}
