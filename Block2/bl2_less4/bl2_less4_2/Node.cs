using System;


namespace bl2_less4_2
{
    class Node<T> : IComparable
        where T: IComparable
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

        public Node(T data, Node<T> left, Node<T> right, Node<T> parent)
        {
            Data = data;
            Left = left;
            Right = right;
            Parent = parent;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (node.Data.CompareTo(Data) == -1)
            {
                if(Left == null)
                {
                    Left = new Node<T>(data, this);
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if(Right==null)
                {
                    Right = new Node<T>(data, this);
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public int CompareTo(object obj)
        {
            if(obj is Node<T> item)
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
