using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less6_1
{
    public class Node
    {
        public int Data { get; set; }
        public List<Edge> Edges {get; set;}
        public bool visited { get; set; }
        public Node Parent { get; set; }

        public Node()
        {
            Edges = new List<Edge>();
            visited = false;
        }

        public Node(int data)
        {
            Data = data;
            Edges = new List<Edge>();
            visited = false;
        }

        public void AddEdge(Node node, int weight)
        {
            Edge edge = new Edge(node, weight);
            Edges.Add(edge);
            visited = false;
        }

    }
}
