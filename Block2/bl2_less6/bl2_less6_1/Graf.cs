using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less6_1
{
    public class Graf
    {
        public Node Root { get; set; }
        public int Data { get; set; }
        public int Count { get; set; }

        public Node AddNode(int data,Node parentNode,int weight) 
        {
            var newNode = new Node(data);

            if (Root == null)
            {
                Root = newNode;
                Count = 1;
                return Root;
            }

            var newEdge = new Edge(newNode, weight);
            parentNode.Edges.Add(newEdge);
            Count++;
            return newNode;
        }

        public void AddEdge(Node firstNode,Node secondNode, int weight) 
        {
            var newEdge = new Edge(secondNode, weight);
            firstNode.Edges.Add(newEdge);
        }

        public Node BFS(int elementSearch)
        {
            var q = new Queue<Node>();
            int _count = 0;
            q.Enqueue(Root);

            while (q.Count != 0)
            {
                Node tmp = q.Dequeue();
                tmp.visited = true;

                Console.WriteLine($"Шаг: {_count}. Сравниваем: {elementSearch.ToString()} с элементом узла графа {tmp.Data}");
                _count++;

                if (tmp.Data.CompareTo(elementSearch) == 0)
                {
                    return tmp;
                }

                int i = tmp.Edges.Count - 1;
                while (i >= 0)
                {
                    if (!tmp.Edges[i].Node.visited)
                    {
                        q.Enqueue(tmp.Edges[i].Node);
                    }
                    i--;
                }
            }
            return null;
        }

        public void resetVisitData(Node root)
        {
            var q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                Node tmp = q.Dequeue();
                tmp.visited = false;
                int i = tmp.Edges.Count - 1;
                while (i >= 0)
                {
                    if (tmp.Edges[i].Node.visited)
                    {
                        q.Enqueue(tmp.Edges[i].Node);
                    }
                    i--;
                }
            }
        }



        public Node DFS(int elementSearch)
        {
            var st = new Stack<Node>();
            int _count = 0;

            st.Push(Root);

            while (st.Count != 0)
            {
                Node tmp = st.Pop();
                tmp.visited = true;

                Console.WriteLine($"Шаг: {_count}. Сравниваем: {elementSearch.ToString()} с элементом узла графа {tmp.Data}");
                _count++;

                if (tmp.Data.CompareTo(elementSearch) == 0)
                {
                    return tmp;
                }
                int i = tmp.Edges.Count-1;
                while (i >= 0)
                {
                    if (!tmp.Edges[i].Node.visited) 
                    { 
                        st.Push(tmp.Edges[i].Node);
                    }
                    i--;
                }
            }
            return null;
        }

        public int CompareTo(object obj)
        {
            if (obj is Graf item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new ArgumentException("Типы не совпадают!");
            }
        }
    }
}
