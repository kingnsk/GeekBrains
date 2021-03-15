using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WindowsWidth = 80;
            const int WindowsHeight = 25;

            Console.WindowWidth = WindowsWidth;
            Console.WindowHeight = WindowsHeight;
            Console.SetBufferSize(WindowsWidth, WindowsHeight);
            Console.CursorVisible = false;

            Walls walls = new Walls(WindowsWidth, WindowsHeight);
            walls.Draw();
            //HorizontalLine upLine = new HorizontalLine(0,78,0,'+');
            //HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            //VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            //VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            //upLine.Drow();
            //downLine.Drow();
            //leftLine.Drow();
            //rightLine.Drow();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(WindowsWidth,WindowsHeight,'$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while(true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                } 
                else
                {
                    snake.Move();
                }
                Thread.Sleep(300);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            
            }


            Console.SetCursorPosition(WindowsWidth / 2, WindowsHeight / 2);
            Console.WriteLine("GAME OVER!");
            Console.ReadLine();
        }
    }
}
