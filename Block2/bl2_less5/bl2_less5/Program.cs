using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int searchData = 88;
            var tree = new Tree<int>();
            Tree<int> test;
            tree.Add(50);
            tree.Add(33);
            tree.Add(71);
            tree.Add(12);
            tree.Add(28);
            tree.Add(88);
            tree.Add(67);
            tree.Add(90);
            tree.Add(44);

            Console.WriteLine("Бинарное дерево поиска (BST):");
            tree.PrintToConsoleOriginal();

            Console.WriteLine($"Поиск в ширину (BFS) значения {searchData}");
            test = tree.BFS(searchData);
            Console.WriteLine($"\nПоиск в глубину (DFS) значения {searchData}");
            test = tree.DFS(searchData);

        }
    }
}
