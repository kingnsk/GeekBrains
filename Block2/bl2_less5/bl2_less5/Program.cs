using System;

namespace bl2_less5
{
    class Program
    {
        static void Main(string[] args)
        {
            int searchData = 88;
            var tree = new Tree<int>();
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
            //tree.PrintToConsoleOriginal();

            BTreePrinter<int>.Print(tree.Root);
            Console.WriteLine();

            Console.WriteLine($"Поиск в ширину (BFS) значения {searchData}");
            tree.BFS(searchData);
            Console.WriteLine($"\nПоиск в глубину (DFS) значения {searchData}");
            tree.DFS(searchData);
        }
    }
}
