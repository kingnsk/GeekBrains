using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 25;
            Console.SetBufferSize(80, 25);

            HorizontalLine upLine = new HorizontalLine(0,78,0,'+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            Point p2 = new Point(4, 5, '*');
            p2.Draw();

            Console.ReadLine();
        }
    }
}
