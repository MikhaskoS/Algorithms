using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        /* Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.*/
        private static void Task1()
        {
            string matrix =
                "0 1 0 0 1" + "\r\n" +
                "1 0 1 1 1" + "\r\n" +
                "0 1 0 1 0" + "\r\n" +
                "0 1 1 0 1" + "\r\n" +
                "1 1 0 1 0";

            Graph graph = new Graph(5);

            // Построение матрицы и списка смежностей
            graph.ReadAdjMatrix(matrix);

            graph.MatrixAdj.Print();

            // Список смежностей
            graph.PrintVertexAdj();
        }

        /* Написать рекурсивную функцию обхода графа в глубину.*/
        private static void Task2()
        {
         
        }

        /* Написать функцию обхода графа в ширину.*/
        private static void Task3()
        {
          
        }
    }
}
