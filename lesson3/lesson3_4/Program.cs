using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Хардкордим ячейки поля боя:
            // можно было бы использовать тип данных матрицы boolean (экономим паямять), 
            // но тогда не сможем расширить функционал в будущем не переписывая весь код
            //      O - свободная клетка
            //      X - элемент корабля
            //      * - мина (в перспективе)
            //      # - клад (в перспективе)

            const byte dimensionsBattleFieldX = 10,dimensionsBattleFieldY=10;
            
            char[,] battleField = new char[dimensionsBattleFieldX, dimensionsBattleFieldY] { 
                { 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'O' } ,
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' } ,
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' } ,
                { 'O', 'X', 'O', 'O', 'O', 'X', 'X', 'O', 'X', 'X' } ,
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' } ,
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'O' } ,
                { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'X' } ,
                { 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' } ,
                { 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' } ,
                { 'X', 'X', 'X', 'X', 'O', 'X', 'O', 'X', 'X', 'X' } ,
            };
            Console.WriteLine("    A B C D E F G H I J\n");

            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                if (i+1 < battleField.GetLength(0)) Console.Write($"{i+1}   ");
                    else Console.Write($"{i + 1}  ");

                for (int j = 0; j < battleField.GetLength(1); j++)
                {
                    Console.Write($"{battleField[i, j]} ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
