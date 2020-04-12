using System;
using myGraph;
using Utility;

namespace Lesson07
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Input.Clear();

            Task2();
            Input.Clear();

            Task3();
            Input.Clear();

            Task4();
            Input.Clear();
        }

        /* Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.*/
        private static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Извлечение графа");

            string matrix =
                "0 1 0 0 1" + "\r\n" +
                "1 0 1 1 1" + "\r\n" +
                "0 1 0 1 0" + "\r\n" +
                "0 1 1 0 1" + "\r\n" +
                "1 1 0 1 0";

            Graph graph = new Graph(5);

            // Построение матрицы и списка смежностей
            graph.ReadAdjMatrix(matrix);

            graph.MatrixAdj.PrintArray();

            // Список смежностей
            graph.PrintVertexAdj();
        }

        /* Написать рекурсивную функцию обхода графа в глубину.*/
        private static void Task2()
        {
            //   Пример ориентированного графа
            //   0---->----1       2
            //   |      /  |     / |
            //  \|/   /\  \|/ |/  \|/
            //   | /       | /     |    
            //   3--<------4      (5) 
            //
            string matrix =
                "0 1 0 1 0 0" + "\r\n" +
                "0 0 0 0 1 0" + "\r\n" +
                "0 0 0 0 1 1" + "\r\n" +
                "0 1 0 0 0 0" + "\r\n" +
                "0 0 0 1 0 0" + "\r\n" +
                "0 0 0 0 0 1";

            Graph graph = new Graph(6);
            // Построение матрицы и списка смежностей
            graph.ReadAdjMatrix(matrix);
            graph.MatrixAdj.PrintArray();
            // Список смежностей
            graph.PrintVertexAdj();

            Console.WriteLine("\nПоиск в глубину:");
            graph.DFS();   // 3 4 1 0 5 2 
        }

        /* Написать функцию обхода графа в ширину.*/
        private static void Task3()
        {
            //   Пример неориентированного графа
            //   0---1   2---3
            //   |   | / | / |
            //   4   5---6---7
            //
            string matrix =
                "0 1 0 0 1 0 0 0" + "\r\n" +
                "1 0 0 0 0 1 0 0" + "\r\n" +
                "0 0 0 0 0 1 1 0" + "\r\n" +
                "0 0 1 0 0 0 1 1" + "\r\n" +
                "1 0 0 0 0 0 0 0" + "\r\n" +
                "0 1 1 0 0 0 1 0" + "\r\n" +
                "0 0 1 1 0 0 0 1" + "\r\n" +
                "0 0 0 1 0 0 6 0";

            Graph graph = new Graph(8);
            // Построение матрицы и списка смежностей
            graph.ReadAdjMatrix(matrix);
            graph.MatrixAdj.PrintArray();
            // Список смежностей
            graph.PrintVertexAdj();

            Console.WriteLine("\nПоиск в ширину:");
            graph.BFS(1);   // 1 0 5 4 2 6 3 7

            Console.WriteLine("\nПоиск в глубину:");
            graph.DFS();   // 1 0 5 4 2 6 3 7
        }

        // Минимальное остовное дерево
        private static void Task4()
        {
            //   Пример неориентированного графа
            //          (8)       (7)   
            //       0------   1 --------- 2
            // (4) / |(11)  /(2) \         |    \  (9)
            //    3  |    4         \ (4)  |(14)  5
            //  (8)\ |  /(7)             \  \    / (10)
            //       6 -----------  7 -------   8
            //            (1)             (2)
            string matrix =
              // 0  1  2  3  4  5   6  7  8
                "0  8  0  4  0  0  11 0  0 " + "\r\n" +  //0
                "8  0  7  0  2  0  0  0  4 " + "\r\n" +  //1
                "0  7  0  0  0  9  0  0  14" + "\r\n" +  //2
                "4  0  0  0  0  0  8  0  0 " + "\r\n" +  //3
                "0  2  0  0  0  0  7  0  0 " + "\r\n" +  //4
                "0  0  9  0  0  0  0  0  10" + "\r\n" +  //5
                "11 0  0  8  7  0  0  1  0 " + "\r\n" +  //6
                "0  0  0  0  0  0  1  0  2 " + "\r\n" +  //7
                "0  4  14 0  0  10 0  2  0 ";            //8

            Graph graph = new Graph(9);
            // Построение матрицы и списка смежностей
            graph.ReadAdjMatrix(matrix);
            graph.MatrixAdj.PrintArray();
            // Список смежностей
            graph.PrintVertexAdj();

            Console.WriteLine("\nМинимальное остовное дерево:\n");
            Vertex[] ost = graph.MinimalTree();
            graph.PrintVertexAdj(ost);

            //   Результат:
            //          (8)       (7)   
            //       0------   1 --------- 2
            // (4) /        /(2) \             \  (9)
            //    3       4         \ (4)         5
            //                             \        
            //       6 -----------  7 -------   8
            //            (1)             (2)
        }
    }
}
