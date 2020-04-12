using System;
using System.Collections.Generic;

namespace Utility
{
    public static class ArraysUtility
    {
        #region PrintArrays

        public static void PrintArray(this int[] ar)
        {
            foreach (int i in ar)
                Console.Write(i + " ");

            Console.WriteLine();
        }

        public static void PrintArray(this int[,] ar)
        {
            int N = ar.GetLength(0);
            int M = ar.GetLength(1);

            Console.Write("\t");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"[{i}]" + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < N; i++)
            {
                Console.Write($"[{i}]" + "\t");
                for (int j = 0; j < M; j++)
                    Console.Write(ar[i, j] + "\t");

                Console.WriteLine("\n");
            }
        }

        // Обобщенный вывод всевозможных массивов
        public static void PrintArray<T>(this IEnumerable<T> A) where T : IFormattable
        {
            foreach (T k in A)
            {
                Console.Write(k.ToString("F02", null) + " ");
            }
            Console.WriteLine();
        }

        #endregion


        #region GenerateArrays

        public static T[] CopyArrray<T>(this T[] ar)
        {
            T[] res = new T[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                res[i] = ar[i];
            }
            return res;
        }

        public static int[] GenerateArray(int num, int min, int max)
        {
            int[] ar = new int[num];
            Random rnd = new Random();
            for (int i = 0; i < ar.Length; i++)
                ar[i] = rnd.Next(min, max);

            return ar;
        }

        public static double[] GenerateArray(int lenght)
        {
            double[] D = new double[lenght];
            Random ran = new Random();
            for (int i = 0; i < lenght; i++)
            {
                D[i] = 1000 * ran.NextDouble();
            }
            return D;
        }

        public static int[] GenerateIntArray(int lenght)
        {
            int[] I = new int[lenght];
            Random ran = new Random();
            for (int i = 0; i < lenght; i++)
            {
                I[i] = ran.Next(0, 1000);
            }
            return I;
        }
        public static int[,] GetZerroArray(int N, int M)
        {
            int[,] ar = new int[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    ar[i, j] = 0;
            return ar;

        }

        #endregion
    }
}
