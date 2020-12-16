using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte dimensions; //размерность квадратной матрицы

            Console.WriteLine("Введите размерность двумерного целочисленного массива:");
            dimensions = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"Заполним элементы массива [{dimensions}x{dimensions}]");
            int[,] matrix = new int[dimensions, dimensions];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"Введите значение элемента массива [{i}x{j}]:");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            
            Console.Clear();
            Console.WriteLine("Получилась матрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Элементы диагонали массива:");
            for (int i = 0; i < dimensions; i++)
            {
                Console.Write($"{matrix[i, i]} ");
            }
            Console.WriteLine("");
        }
    }
}
