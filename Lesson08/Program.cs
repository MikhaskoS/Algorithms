using System;
using Utility;
using Utility.Sorting;

namespace Lesson08
{
    class Program
    {
        static void Main()
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

        /*Реализовать сортировку подсчетом.*/
        private static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сортировка подсчетом");
            int max = 50;
            int[] A = ArraysUtility.GenerateArray(10, 0, max);
            A.PrintArray();
            Console.WriteLine("Сортируем:");
            CountingSort(A, max);
            A.PrintArray();
        }

        public static void CountingSort(int[] A, int max)
        {
            int k = max; // макс число

            int[] C = new int[k];
            for (int i = 0; i < k; i++)
                C[i] = 0;

            for (int i = 0; i < A.Length; i++)
                C[A[i]]++;

            int b = 0;
            for (int i = 0; i < C.Length; i++)
            {
                if (C[i] != 0)
                {
                    for (int j = 0; j < C[i]; j++)
                    {
                        A[b] = i;
                        b++;
                    }
                }
            }
        }

        /*Реализовать быструю сортировку.*/
        private static void Task2()
        {
            Console.WriteLine("Быстрая сортировка");
            int[] A = ArraysUtility.GenerateIntArray(50);
            A.PrintArray();
            Console.WriteLine("Сортируем:");
            QuickSort.Sort(A);
            A.PrintArray();
        }

        /*Реализовать сортировку слиянием.*/
        private static void Task3()
        {
            Console.WriteLine("Cортировка слиянием");
            int[] A = ArraysUtility.GenerateIntArray(50);
            A.PrintArray();
            Console.WriteLine("Сортируем:");
            MergeSort.Sort(A);
            A.PrintArray();
        }

        /*Время работы сортировок.*/
        private static void Task4()
        {
            #region Генерируем массивы
            Console.WriteLine(new string('+', 50));
            Console.WriteLine("Генерируем массивы");
            int[] I10 = ArraysUtility.GenerateIntArray(10);
            int[] I100 = ArraysUtility.GenerateIntArray(100);
            int[] I1000 = ArraysUtility.GenerateIntArray(1000);
            int[] I10000 = ArraysUtility.GenerateIntArray(10000);
            int[] I100000 = ArraysUtility.GenerateIntArray(100000);
            int[] I1000000 = ArraysUtility.GenerateIntArray(1000000);
            int[] I10000000 = ArraysUtility.GenerateIntArray(10000000);

            double[] D10 = ArraysUtility.GenerateArray(10);
            double[] D100 = ArraysUtility.GenerateArray(100);
            double[] D1000 = ArraysUtility.GenerateArray(1000);
            double[] D10000 = ArraysUtility.GenerateArray(10000);
            double[] D100000 = ArraysUtility.GenerateArray(100000);
            double[] D1000000 = ArraysUtility.GenerateArray(1000000);
            double[] D10000000 = ArraysUtility.GenerateArray(10000000);
            #endregion

            Console.WriteLine(new string('+', 50));
            Console.WriteLine("\n------ !!! Пузырьковая сортировка (int) !!! -------");
            Testing.TestedSort("I1_000 -", I1000.CopyArrray(), BubbleSort.Sort);
            Testing.TestedSort("I10_000 -", I10000.CopyArrray(), BubbleSort.Sort);
            Console.WriteLine("I100_000 - долго...");

            Console.WriteLine("\n------ !!! Пузырьковая  оптимизированная сортировка (int) !!! -------");
            Testing.TestedSort("I1_000 -", I1000.CopyArrray(), BubbleSort.SortOptimize);
            Testing.TestedSort("I10_000 -", I10000.CopyArrray(), BubbleSort.SortOptimize);
            Console.WriteLine("I100_000 - долго...");

            Console.WriteLine("\n------ !!! Cортировка вставкой (int) !!! -------");
            Testing.TestedSort("I1_000 -", I1000.CopyArrray(), InsertionSort.Sort);
            Testing.TestedSort("I10_000 -", I10000.CopyArrray(), InsertionSort.Sort);
            Testing.TestedSort("I100_000 -", I100000.CopyArrray(), InsertionSort.Sort);
            Console.WriteLine("I1_000_000 - долго...");

            Console.WriteLine("\n------ !!! Шейкерная сортировка (int) !!! -------");
            Testing.TestedSort("I1_000 -", I1000.CopyArrray(), ShakerSort.Sort);
            Testing.TestedSort("I10_000 -", I10000.CopyArrray(), ShakerSort.Sort);
            Console.WriteLine("I100_000 - долго...");

            Console.WriteLine("\n------ !!! Пирамидальная сортировка (int) !!! -------");
            Testing.TestedSort("I1_000 -", I1000.CopyArrray(), HeapSort.Sort);
            Testing.TestedSort("I10_000 -", I10000.CopyArrray(), HeapSort.Sort);
            Testing.TestedSort("I100_000 -", I100000.CopyArrray(), HeapSort.Sort);
            Testing.TestedSort("I1_000_000 -", I1000000.CopyArrray(), HeapSort.Sort);

            Console.WriteLine("\n------ !!! Сортировка слиянием (int)  !!! -------");
            Testing.TestedSort("I1000 -", I1000.CopyArrray(), MergeSort.Sort);
            Testing.TestedSort("I10_000 -", I10000.CopyArrray(), MergeSort.Sort);
            Testing.TestedSort("I100_000 -", I100000.CopyArrray(), MergeSort.Sort);
            Testing.TestedSort("I1_000_000 -", I1000000.CopyArrray(), MergeSort.Sort);
            Testing.TestedSort("I10_000_000 -", I10000000.CopyArrray(), MergeSort.Sort);

            Console.WriteLine("\n------ !!! Быстрая сортировка (int)  !!! -------");
            Testing.TestedSort("I1_000 -", I1000.CopyArrray(), QuickSort.Sort);
            Testing.TestedSort("I10_000 -", I10000.CopyArrray(), QuickSort.Sort);
            Testing.TestedSort("I100_000 -", I100000.CopyArrray(), QuickSort.Sort);
            Testing.TestedSort("I1_000_000 -", I1000000.CopyArrray(), QuickSort.Sort);
            Console.WriteLine("I10_000_000 - долго...");

            Console.WriteLine("\n------ !!! Быстрая сортировка (double)  !!! -------");
            Testing.TestedSort("D1_000 -", D1000.CopyArrray(), QuickSort.Sort);
            Testing.TestedSort("D10_000 -", D10000.CopyArrray(), QuickSort.Sort);
            Testing.TestedSort("D100_000 -", D100000.CopyArrray(), QuickSort.Sort);
            Testing.TestedSort("D1_000_000 -", D1000000.CopyArrray(), QuickSort.Sort);
            Testing.TestedSort("D10_000_000 -", D10000000.CopyArrray(), QuickSort.Sort);

            Console.WriteLine("\n Всё!!! Парам пам пам. ");
        }
    }
}
