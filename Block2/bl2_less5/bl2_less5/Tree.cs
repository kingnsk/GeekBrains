using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less4_2
{
    class Tree<T> : IComparable
        where T : IComparable
    {
        public Tree<T> Root { get; set; }
        public int Count { get; set; }
        const int SPACE = 1;
        int MaxWidth { get; set; }
        int MaxLengthWord;
        int HeightTree;

        public T Data { get; set; }
        public Tree<T> Left { get; set; }
        public Tree<T> Right { get; set; }
        public Tree<T> Parent { get; set; }

        public Tree()
        {

        }

        public Tree(T data)
        {
            Data = data;
        }

        public Tree(T data, Tree<T> parent)
        {
            Data = data;
            Parent = parent;
        }


        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Tree<T>(data);
                Count = 1;
                return;
            }
            Root.AddNode(data);
            Count++;
        }

        public void AddNode(T data)
        {
            var node = new Tree<T>(data);
            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = new Tree<T>(data, this);
                }
                else
                {
                    Left.AddNode(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Tree<T>(data, this);
                }
                else
                {
                    Right.AddNode(data);
                }
            }
        }


        public List<T> preOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return preOrder(Root);
        }

        public List<T> postOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return postOrder(Root);
        }

        public List<T> inOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return inOrder(Root);
        }

        public Tree<T> search(Tree<T> tree, T data)
        {
            return _search(tree, data);
        }

        private List<T> preOrder(Tree<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(preOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(preOrder(node.Right));
                }
            }

            return list;
        }


        private List<T> postOrder(Tree<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(postOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(postOrder(node.Right));
                }

                list.Add(node.Data);
            }
            return list;
        }

        private List<T> inOrder(Tree<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(inOrder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(inOrder(node.Right));
                }
            }
            return list;
        }

        private Tree<T> _search(Tree<T> tree, T data)
        {
            if (tree == null)
            {
                return null;
            }

            switch (data.CompareTo(tree.Data))
            {
                case 1: return _search(tree.Right, data);
                case -1: return _search(tree.Left, data);
                case 0: return tree;
                default: return null;
            }

        }

        public bool remove(Tree<T> _tree, T val)
        {
            Tree<T> tree = search(_tree, val);
            if (tree == null)
            {
                return false;
            }
            Tree<T> curTree;

            //Если удаляем корень
            if (tree == Root)
            {
                if (tree.Right != null)
                {
                    curTree = tree.Right;
                }
                else curTree = tree.Left;

                while (curTree.Left != null)
                {
                    curTree = curTree.Left;
                }
                T temp = curTree.Data;
                this.remove(tree, temp);
                tree.Data = temp;

                return true;
            }

            //Удаление листьев
            if (tree.Left == null && tree.Right == null && tree.Parent != null)
            {
                if (tree == tree.Parent.Left)
                    tree.Parent.Left = null;
                else
                {
                    tree.Parent.Right = null;
                }
                return true;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (tree.Left != null && tree.Right == null)
            {
                //Меняем родителя
                tree.Left.Parent = tree.Parent;
                if (tree == tree.Parent.Left)
                {
                    tree.Parent.Left = tree.Left;
                }
                else if (tree == tree.Parent.Right)
                {
                    tree.Parent.Right = tree.Left;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.Left == null && tree.Right != null)
            {
                //Меняем родителя
                tree.Right.Parent = tree.Parent;
                if (tree == tree.Parent.Left)
                {
                    tree.Parent.Left = tree.Right;
                }
                else if (tree == tree.Parent.Right)
                {
                    tree.Parent.Right = tree.Right;
                }
                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (tree.Right != null && tree.Left != null)
            {
                curTree = tree.Right;

                while (curTree.Left != null)
                {
                    curTree = curTree.Left;
                }

                //Если самый левый элемент является первым потомком
                if (curTree.Parent == tree)
                {
                    curTree.Left = tree.Left;
                    tree.Left.Parent = curTree;
                    curTree.Parent = tree.Parent;
                    if (tree == tree.Parent.Left)
                    {
                        tree.Parent.Left = curTree;
                    }
                    else if (tree == tree.Parent.Right)
                    {
                        tree.Parent.Right = curTree;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curTree.Right != null)
                    {
                        curTree.Right.Parent = curTree.Parent;
                    }
                    curTree.Parent.Left = curTree.Right;
                    curTree.Right = tree.Right;
                    curTree.Left = tree.Left;
                    tree.Left.Parent = curTree;
                    tree.Right.Parent = curTree;
                    curTree.Parent = tree.Parent;
                    if (tree == tree.Parent.Left)
                    {
                        tree.Parent.Left = curTree;
                    }
                    else if (tree == tree.Parent.Right)
                    {
                        tree.Parent.Right = curTree;
                    }

                    return true;
                }
            }
            return false;
        }

        int GetMaxLengthWord()
        {
            int max = 0;
            Foo(Root);
            return max;

            void Foo(Tree<T> node)
            {
                if (node.Data.ToString().Length > max)
                    max = node.Data.ToString().Length;
                if (node.Left != null)
                    Foo(node.Left);
                if (node.Right != null)
                    Foo(node.Right);
            }
        }

        int GetHeightTree()
        {
            int max = 0;
            Foo(Root, 1);
            return max;

            void Foo(Tree<T> node, int height)
            {
                if (height > max)
                    max = height;
                if (node.Left != null)
                    Foo(node.Left, height + 1);
                if (node.Right != null)
                    Foo(node.Right, height + 1);
            }
        }

        void PrintRowOriginal(List<Tree<T>> currenLst)
        {
            // Отступ слева и справа между словами в текущей строке / высоте
            int space = (MaxWidth - currenLst.Count * MaxLengthWord) / (currenLst.Count * 2);
            Console.CursorLeft = 1;

            // Прорисовка узлов
            for (int i = 0; i < currenLst.Count; i++)
            {
                Console.CursorLeft += space;
                // Если данного узла нет, сдвигаем позицию
                if (currenLst[i] == null)
                {
                    Console.CursorLeft += MaxLengthWord + space;
                    continue;
                }

                string value = currenLst[i].Data.ToString();

                // Если слово в левой половине - смещается левее, если в правой - правее
                // Приведение к double - только для первой строки / высоты / корня
                int half = i < (double)currenLst.Count / 2 ? 0 : 1;
                // Позиция слова слева
                int positionLeftValue = Console.CursorLeft + ((MaxLengthWord - value.Length + half) / 2);

                for (int j = 0, k = 0; j < MaxLengthWord; j++)
                {
                    if (Console.CursorLeft >= positionLeftValue && k < value.Length)
                        Console.Write(value[k++]);
                    else
                        Console.Write(' ');
                }
                Console.CursorLeft += space;
            }
            Console.WriteLine();
            // Если все дерево прорисовано - выходим из рекурсии
            if (Math.Pow(2, HeightTree - 1) == currenLst.Count)
                return;

            // Прорисовка 'веток', то есть знаков  /  и  \
            // Теперь space отвечает за отступы между данными символами (ветками)
            space = MaxWidth / (currenLst.Count * 8);
            // Выбор слеша (ветки)
            // true /
            // false \
            bool slashLeft = true;
            for (int i = space * 3, j = -1; i < MaxWidth - space * 3 + 1; i += space * (slashLeft ? 6 : 2))
            {
                if (slashLeft)
                {
                    j++;
                    if (j == currenLst.Count)
                    {
                        j = currenLst.Count - 1;
                    }

                }

                Console.CursorLeft = i + (slashLeft ? 1 : 0);

                if (currenLst[j] != null)
                {
                    if (slashLeft && currenLst[j].Left != null)
                        Console.Write('/');
                    else if (!slashLeft && currenLst[j].Right != null)
                        Console.Write('\\');
                }
                slashLeft = !slashLeft;
            }
            Console.WriteLine();

            // Создание списка с узлами, которые идут ниже
            // Задаем Capacity в 2 раза больше, чем у текущего списка
            List<Tree<T>> newLst = new List<Tree<T>>(currenLst.Count * 2);
            foreach (var node in currenLst)
            {
                newLst.Add(node == null ? null : (node.Left ?? null));
                newLst.Add(node == null ? null : (node.Right ?? null));
            }
            PrintRowOriginal(newLst);
        }


        public void PrintToConsoleOriginal()
        {
            // Если узлов нет
            if (Root == null)
                return;

            // Если размер консоли меньше, чем ширина нижнего ряда
            if (Console.WindowWidth < MaxWidth + 1)
                Console.WindowWidth = MaxWidth + 1;

            MaxLengthWord = GetMaxLengthWord();
            HeightTree = GetHeightTree();
            MaxWidth = (int)Math.Pow(2, HeightTree - 1) * // кол-во слов
                           (MaxLengthWord + SPACE * 2); // умножить на их длину и пробелы срава и слева

            // Рисуем само дерево (рекурсивный метод, рисующий строку и символы / и \)
            // Передаем 'корень' дерева, дальше будет размножение
            PrintRowOriginal(new List<Tree<T>>() { Root });

            Console.WriteLine();
        }

        public Tree<T> BFS(int elementSearch)
        {
            var q = new Queue<Tree<T>>();
            int _count=0;
            q.Enqueue(Root);

            while (q != null)
            {
                Tree<T> tmp = q.Dequeue();
                
                Console.WriteLine($"Шаг: {_count}. Сравниваем: {elementSearch.ToString()} с элементом узла дерева {tmp.Data}");
                _count++;
                
                if (tmp.Data.CompareTo(elementSearch) == 0)
                {
                    return tmp;
                }
                if (tmp.Left != null)
                {
                    q.Enqueue(tmp.Left);
                }

                if (tmp.Right != null)
                {
                    q.Enqueue(tmp.Right);
                }


            }
            return null;
        }

        public Tree<T> DFS (int elementSearch)
        {
            var st = new Stack<Tree<T>>();
            int _count = 0;

            st.Push(Root);

            while(st!=null)
            {
                Tree<T> tmp = st.Pop();

                Console.WriteLine($"Шаг: {_count}. Сравниваем: {elementSearch.ToString()} с элементом узла дерева {tmp.Data}");
                _count++;

                if (tmp.Data.CompareTo(elementSearch) == 0)
                {
                    return tmp;
                }

                if (tmp.Right != null)
                {
                    st.Push(tmp.Right);
                }

                if (tmp.Left != null)
                {
                    st.Push(tmp.Left);
                }

                
            }
            return null;
        }

        public int CompareTo(object obj)
        {
            if (obj is Tree<T> item)
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
