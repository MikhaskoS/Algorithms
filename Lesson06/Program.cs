using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Lesson06
{
    class Program
    {
        static void Main()
        {
            Task1();
            Input.Clear();

            Task2();
            Input.Clear();
        }

        /* 1. Реализовать простейшую хэш-функцию. 
         * На вход функции подается строка, на выходе сумма кодов символов. */
        private static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Простейшая хэш-функция");

            string _s = "Hello World!";
            Console.WriteLine($"Строка [{_s}] Hash: {GetHashSimple(_s)}");
            _s = "Вася";
            Console.WriteLine($"Строка [{_s}] Hash: {GetHashSimple(_s)}");
        }

        public static int GetHashSimple(string s)
        {
            int sum = 0;
            foreach (char ch in s)
            {
                sum += (int)ch;
            }

            return sum;
        }

        /* Переписать программу, реализующее двоичное дерево поиска.  
         * а) Добавить в него обход дерева различными способами; 
         * б) Реализовать поиск в двоичном дереве поиска; 
         * */
        private static void Task2()
        {
            /*Результат:
            *             12
            *          /      \
            *        5          18
            *     /    \       /   \
            *     2     9    15     19
            *               /  \
            *              13  17
            * */

            BinaryTree tree = new BinaryTree(12);
            tree.Insert(5);
            tree.Insert(18);
            tree.Insert(2);
            tree.Insert(9);
            tree.Insert(15);
            tree.Insert(19);
            tree.Insert(13);
            tree.Insert(17);

            tree.Print();  //  12 (5 (2 9 )18 (15 (13 17 )19 ))

            Console.WriteLine("\nРекурсивный обход");
            RecursiveTraversal(tree.Root);

            Console.WriteLine("\nСимметричный обход");
            SymmetricalTraversal(tree.Root);

            Console.WriteLine("\nОбратный обход");
            ReverceTraversal(tree.Root);

            Console.WriteLine("\nПоиск узла");
            BinaryTree.Node<int> node = tree.Find(15);
            tree.Print(node);
        }

        #region

        // рекурсивный обход
        public static void RecursiveTraversal(BinaryTree.Node<int> root)
        {
            if (root == null) return;
            Console.Write($"{root.Data} ");
            RecursiveTraversal(root.Left);
            RecursiveTraversal(root.Right);
        }

        // симметричный обход
        public static void SymmetricalTraversal(BinaryTree.Node<int> root)
        {
            if (root == null) return;
            SymmetricalTraversal(root.Left);
            Console.Write($"{root.Data} ");
            SymmetricalTraversal(root.Right);
        }

        // обратный обход
        public static void ReverceTraversal(BinaryTree.Node<int> root)
        {
            if (root == null) return;
            ReverceTraversal(root.Left);
            ReverceTraversal(root.Right);
            Console.Write($"{root.Data} ");
        }

        #endregion

    }
}
