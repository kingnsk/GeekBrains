using System;


namespace bl2_less4_2
{
    class Node<T> : IComparable
        where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }

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
