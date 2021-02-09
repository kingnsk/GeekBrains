using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int searchData = 7;

            var graf = new Graf();
            var currNode = new Node();
            Node node1, node2, node3, node4, node5, node6, node7 = new Node();


            // Заполняем граф
            node1 = graf.AddNode(1, null, 100);
            node2 = graf.AddNode(2, node1, 10);
            node3 = graf.AddNode(3, node1, 5);
            graf.AddEdge(node2, node3, 7);
            node4 = graf.AddNode(4, node3, 9);
            node5 = graf.AddNode(5, node4, 11);
            graf.AddEdge(node1, node5, 25);
            node6 = graf.AddNode(6, node4, 3);
            node7 = graf.AddNode(7, node6, 1);
            graf.AddEdge(node6, node2, 2);

            Console.WriteLine("Обход графа в ширину (BFS)");
            graf.BFS(searchData);
            graf.resetVisitData(node1);
            Console.WriteLine("Обход графа в глубину (DFS)");
            graf.DFS(searchData);
            graf.resetVisitData(node1);
        }



    }



}
