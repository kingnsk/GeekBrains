using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less6_1
{
    public class Edge
    {
        public int Weight { get; set; } // Вес связи
        public Node Node { get; set; } // Узел, на который связь ссылается

        public Edge(Node node, int weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}
