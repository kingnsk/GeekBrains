using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less2_1
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

        public class MyLinkedList : ILinkedList
        {
            private int _count = 0;
            private Node _startNode;
            private Node _endNode;
            private Node _currentNode;
            private Node _newNode;

            public void AddNode(int value)
            {
                if (_startNode == null)
                {
                    _startNode = new Node { Value = value };
                    _endNode = _startNode;
                } 
                
                else if (_startNode == _endNode)
                {
                    _newNode = new Node { Value = value };
                    _endNode = _newNode;
                    _startNode.NextNode = _newNode;
                    _endNode.PrevNode = _startNode;
                }

                else
                {
                    _newNode = new Node { Value = value, PrevNode=_endNode };
                    _endNode.NextNode = _newNode;
                    _endNode = _newNode;
                }
                _count++;
            }

            public void AddNodeAfter(Node node, int value)
            {
                _newNode = new Node { Value = value, NextNode = _currentNode, PrevNode = node };
                _currentNode = node.NextNode;
                node.NextNode = _newNode;
                _currentNode.PrevNode = _newNode;
                _count++;
            }

            public Node FindNode(int searchValue)
            {
                _currentNode = _startNode;
                while (_currentNode!=null)
                {
                    if (_currentNode.Value == searchValue)
                        return _currentNode;
                    _currentNode = _currentNode.NextNode;
                }
                return null;
            }

            public int GetCount()
            {
                return _count;
            }

            public void RemoveNode(int index)
            {
                _currentNode = _startNode;
                for (int i = 0; i < index; i++)
                {
                    _currentNode = _currentNode.NextNode;
                }
                RemoveNode(_currentNode);
            }

            public void RemoveNode(Node node)
            {
                if (node.PrevNode != null)
                {
                    node.PrevNode.NextNode = node.NextNode;
                }

                if (node.NextNode != null)
                {
                    node.NextNode.PrevNode = node.PrevNode;
                }

                _count--;
            }
        }

        static void Main(string[] args)
        {
            //Создадим и заполним двусвязный список 
            var linkedList = new MyLinkedList();
            linkedList.AddNode(18);
            linkedList.AddNode(22);
            linkedList.AddNode(77);
            linkedList.AddNode(88);
            Console.WriteLine($"{linkedList.GetCount()}");
            
            // Добавим новую ноду со значением 11 после ноды со значением 77
            Node temp = linkedList.FindNode(77);
            if (temp!=null)
            {
                linkedList.AddNodeAfter(temp, 11);
            }
            Console.WriteLine($"{linkedList.GetCount()}");

            //удалинм ноду с индексом 0
            linkedList.RemoveNode(0);
            Console.WriteLine($"{linkedList.GetCount()}");

            //Удалим ноду со значением 22
            temp = linkedList.FindNode(22);
            if (temp != null)
            {
                linkedList.RemoveNode(temp);
            }
            Console.WriteLine($"{linkedList.GetCount()}");
            
        }
    }
}
