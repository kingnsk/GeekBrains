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
            int searchData = 71;
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
            tree.PrintToConsoleOriginal();

            Console.WriteLine("Prefix обход дерева:");
            foreach (var item in tree.preOrder())
            {
                Console.Write(item+", ");
            }

            Console.WriteLine("\nPostfix обход дерева:");
            foreach (var item in tree.postOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("\nInfix обход дерева:");
            foreach (var item in tree.inOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine($"\n\nИщем в дереве узел со значением {searchData}");

            var tmp = tree.search(tree.Root, searchData);
            if (tmp != null)
            {
                Console.WriteLine($"Узел:{tmp.Data} Левый потомок: {tmp.Left.Data} Правый потомок: {tmp.Right.Data} Родитель: {tmp.Parent.Data}");
            }
            else
            {
                Console.WriteLine($"Узел:{searchData} Не найден!");
            }

            Console.WriteLine($"\nУдаляем узел:{searchData}");
            Console.WriteLine($"{tree.remove(tree.Root, searchData)}");
            Console.WriteLine("Получилось дерево:");
            tree.PrintToConsoleOriginal();
        }
    }
}
