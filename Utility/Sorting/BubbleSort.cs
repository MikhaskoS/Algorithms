using System;

namespace Utility.Sorting
{
    public class BubbleSort
    {
        /// <summary>
        /// Пузырьковая сортировка
        /// </summary>
        //public static void Sort(int[] A)
        //{
        //    for (int i = 0; i < A.Length; i++)
        //    {
        //        for (int j = A.Length - 1; j > i; j--)
        //        {
        //            if (A[j] < A[j - 1])
        //            {
        //                //меняем местами (без дополнительной переменной)
        //                A[j] = A[j - 1] + A[j];
        //                A[j - 1] = A[j] - A[j - 1];
        //                A[j] = A[j] - A[j - 1];
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Пузырьковая сортировка (оптимизированная)
        /// </summary>
        //public static void SortOptimize(int[] A)
        //{
        //    for (int i = 0; i < A.Length; i++)
        //    {
        //        int permutation = 0;
        //        for (int j = A.Length - 1; j > i; j--)
        //        {
        //            if (A[j] < A[j - 1])
        //            {
        //                //меняем местами (без дополнительной переменной)
        //                A[j] = A[j - 1] + A[j];
        //                A[j - 1] = A[j] - A[j - 1];
        //                A[j] = A[j] - A[j - 1];

        //                permutation++;
        //            }
        //        }
        //        // если перестановки прекратились - на выход
        //        if (permutation <= 1) break;
        //    }
        //}

        public static void Sort<T>(T[] A) where T : IComparable<T>
        {
            for (int i = 0; i < A.Length; i++)
            {
                int permutation = 0;
                for (int j = A.Length - 1; j > i; j--)
                {
                    if (A[j].CompareTo(A[j-1]) < 0)  // в порядке возрастания
                    {
                        //меняем местами (без дополнительной переменной)
                        T temp = A[j];
                        A[j] = A[j - 1];
                        A[j - 1] = temp;

                        permutation++;
                    }
                }
                // если перестановки прекратились - на выход
                if (permutation <= 1) break;
            }
        }
    }
}
