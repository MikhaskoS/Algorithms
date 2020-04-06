using System;

namespace Lesson06
{
    // Бинарное дерево поиска на основе связанного списка
    class BinaryTree
    {
        #region Node
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Right { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Parent { get; set; }
        }
        #endregion

        private readonly Node<int> root; // корень 

        public BinaryTree(int value)
        {
            root = new Node<int>(value)
            {
                Left = null,
                Right = null,
                Parent = null
            };
        }

        public Node<int> Root { get => root; }

        public void Insert(int value)
        {
            Insert(value, root);
        }

        public void Insert(int value, BinaryTree.Node<int> node)
        {
            if (value > node.Data)
            {
                if (node.Right == null)
                {
                    Node<int> _n = new Node<int>(value)
                    {
                        Left = null,
                        Right = null,
                        Parent = node
                    };
                    node.Right = _n;
                }
                else
                    Insert(value, node.Right);
            }
            else
            {
                if (node.Left == null)
                {
                    Node<int> _n = new Node<int>(value)
                    {
                        Left = null,
                        Right = null,
                        Parent = node
                    };
                    node.Left = _n;
                }
                else
                    Insert(value, node.Left);
            }

        }

        public Node<int> Find(int value)
        {
            return Find(value, root);
        }

        private Node<int> Find(int value, BinaryTree.Node<int> node)
        {
            if (node == null) return null;
            if (value == node.Data) return node;

            if (value < node.Data)
                return Find(value, node.Left);
            else
                return Find(value, node.Right);
        }

        public void Print()
        {
            Print(root);
        }

        public void Print(BinaryTree.Node<int> node)
        {
            if (node == null)
            {
                Console.WriteLine("Дерева нет!");
                return;
            }

            Console.Write($"{node.Data} ");

            if (node.Left != null || node.Right != null)
            {
                Console.Write("(");
                if (node.Left != null)
                    Print(node.Left);
                else
                    Console.Write("NULL");

                if (node.Right != null)
                    Print(node.Right);
                else
                    Console.Write("NULL");

                Console.Write(")");
            }
        }
    }
}
