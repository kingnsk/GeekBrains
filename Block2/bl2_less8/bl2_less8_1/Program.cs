using System;
using System.Collections.Generic;


namespace bl2_less8_1
{
    class Program
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        private static void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] array = new int[] { 92, 11, 18, 91, 30, 16, 9, 1, 77, 22, 4, 19, 29, 78, 0, 96, 88 };

            Console.WriteLine("Source Array:");
            printArray(array);

            Console.WriteLine("Bucket Sort:");
            List<int> sorted = BucketSort.Sort(array);
            printArray(sorted.ToArray());
        }
    }
}