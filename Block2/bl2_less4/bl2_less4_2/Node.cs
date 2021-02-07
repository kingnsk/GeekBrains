using System;

namespace bl2_less4_2
{
    public class Node<T> : IComparable
        where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> parent)
        {
            Data = data;
            Parent = parent;
        }

        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new ArgumentException("Типы не совпадают!");
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
