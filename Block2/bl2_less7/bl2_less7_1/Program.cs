using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less7_1
{
    class Program
    {
        const int N = 5;
        const int M = 5;

        static int[,] map = new int[20, 20];

        static void Print2(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(a[i, j]+" ");
                }
                Console.Write("\r\n");
            }
        }

        static int GetCombinations(int k, int n)
        {
            int result = 0;
            if (k == 0 && n == 0)
                return 0;
            if (k == 0)
                return 1;
            if (n == 0)
                return 1;

            if (map[n, k] >= 0)
            {
                result = GetCombinations(k, n - 1) + GetCombinations(k - 1, n);
            }
            else
            {
                result = 0;
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[,] A = new int[N, M];
            int i, j, k;

            Console.WriteLine("Количество маршрутов (реализация массив + цикл)");
            for (k = 0; k < M; k++)
            {
                A[0, k] = 1;
                for (i = 1; i < N; i++)
                {
                    A[i, 0] = 1;
                    for (j = 1; j < M; j++)
                    {
                        A[i, j] = A[i, j - 1] + A[i - 1, j];
                    }
                }
            }
            A[0, 0] = 0;
            Print2(N, M, A);
            Console.WriteLine();

            Console.WriteLine("Количество маршрутов (реализация рекурсией)");
            for (i = 0; i <= N-1; i++)
            {
                for (j = 0; j <= M-1; j++)
                {
                    Console.Write(GetCombinations(i, j) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //заполнение запрещенных для посещения ячеек
            map[1, 1] = -1;
            map[3, 2] = -1;
            map[1, 3] = -1;


            Console.WriteLine("Количество маршрутов с запретом посещения ячеек");
            for (i = 0; i <= N - 1; i++)
            {
                for (j = 0; j <= M - 1; j++)
                {
                    Console.Write(GetCombinations(i, j) + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
