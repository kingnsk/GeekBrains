using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less2_2
{
    class Program
    {
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }



        static void Main(string[] args)
        {
            int [] testArray = { 33, 22, 11, 98, 5, 7, 32, 77, 99, 1, 0, 19, 28, 33 };
            Array.Sort(testArray);
            
            Console.WriteLine("Введите число для поиска в массиве:");
            int search = Convert.ToInt32(Console.ReadLine());
            int index = BinarySearch(testArray, search);

            Console.WriteLine("Ищем в массиве:");
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine($"{testArray[i]}");
            }

            if (index != -1)
            {
                Console.WriteLine($"Искомый элемент находится в позиции {index}");
            } else
            {
                Console.WriteLine("Искомый элемент не найден.");
            }
            // Алгоритм имеет логарифмическую сложность O(log n) т.к. на каждой итерации входные данные уменьшаются в 2 раза
        }
    }
}
