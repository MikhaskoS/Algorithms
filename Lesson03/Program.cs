using System;
using Utility;
//------------------------------------------------
// Михасько С.В.
//------------------------------------------------
namespace Lesson03
{
    class Program
    {
        static void Main()
        {
            Task01();
            Input.Clear();

            Task02();
            Input.Clear();

            Task03();
            Input.Clear();
        }

        /* Попробовать оптимизировать пузырьковую сортировку. 
         * Сравнить количество операций сравнения оптимизированной и 
         * не оптимизированной программы. Написать функции сортировки, которые  
         * возвращают количество операций. */
        public static void Task01()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int[] ar1 = ArraysUtility.GenerateArray(10, 1, 50);  // тестовый массив
            int[] ar2 = ar1.CopyArrray();
            ar1.PrintArray();

            int c1 = BubbleSort(ar1);
            int c2 = BubbleSortOptimize(ar2);
            ar1.PrintArray();

            Console.WriteLine($"Итераций (обычная сортировка): {c1}");
            Console.WriteLine($"Итераций (оптимизированная сортировка): {c2}");
        }

        #region
        /// <summary>
        /// Пузырьковая сортировка
        /// </summary>
        public static int BubbleSort(int[] A)
        {
            int counter = 0;

            for (int i = 0; i < A.Length; i++)
            {
                counter++;
                for (int j = A.Length - 1; j > i; j--)
                {
                    counter++;
                    if (A[j] < A[j - 1])
                    {
                        //меняем местами (без дополнительной переменной)
                        A[j] = A[j - 1] + A[j];
                        A[j - 1] = A[j] - A[j - 1];
                        A[j] = A[j] - A[j - 1];
                    }
                }
            }
            return counter;
        }
        /// <summary>
        /// Пузырьковая сортировка (оптимизированная)
        /// </summary>
        public static int BubbleSortOptimize(int[] A)
        {
            int counter = 0;

            for (int i = 0; i < A.Length; i++)
            {
                counter++;
                int permutation = 0;
                for (int j = A.Length - 1; j > i; j--)
                {
                    counter++;
                    if (A[j] < A[j - 1])
                    {
                        //меняем местами (без дополнительной переменной)
                        A[j] = A[j - 1] + A[j];
                        A[j - 1] = A[j] - A[j - 1];
                        A[j] = A[j] - A[j - 1];

                        permutation++;
                    }
                }
                // если перестановки прекратились - на выход
                if (permutation <= 1) break;
            }

            return counter;
        }
        #endregion

        /* Реализовать шейкерную сортировку. */
        public static void Task02()
        {
            Console.WriteLine("Шейкерная сортировка.");
            int[] ar =ArraysUtility.GenerateArray(10, 1, 50);
            ar.PrintArray();


            ShakerSort(ar);
            ar.PrintArray();
        }

        #region
        public static void ShakerSort(int[] A)
        {
            int l = 0;
            int r = A.Length - 1;
            while (l <= r)
            {
                for (int i = r; i > l; i--)
                {
                    if (A[i - 1] > A[i])
                    {
                        int t = A[i - 1];
                        A[i - 1] = A[i];
                        A[i] = t;
                    }
                }
                l++;
                for (int i = l; i < r; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        int t = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = t;
                    }
                }
                r--;
            }
        }
        #endregion

        /* Реализовать бинарный алгоритм поиска в виде функции, 
         * которой передается отсортированный массив. Функция возвращает 
         * индекс найденного элемента или -1, если элемент не найден*/
        public static void Task03()
        {
            int[] ar = ArraysUtility.GenerateArray(10, 1, 20);
            BubbleSort(ar);
            ar.PrintArray();

            int findelement = 5;
            Console.WriteLine($"find:{findelement} index = [{ BinarySearch(ar, findelement)}]");
            findelement = 7;
            Console.WriteLine($"find:{findelement} index = [{ BinarySearch(ar, findelement)}]");
            findelement = 10;
            Console.WriteLine($"find:{findelement} index = [{ BinarySearch(ar, findelement)}]");
        }

        #region
        public static int BinarySearch(int[] ar, int value)
        {
            if (value < ar[0] || value > ar[ar.Length - 1]) return -1;

            int l = 0;
            int r = ar.Length - 1;
            int m = l + (r - l) / 2;

            while (l <= r && ar[m] != value)
            {
                if (ar[m] < value)
                    l = m + 1;
                else
                    r = m - 1;
                m = l + (r - l) / 2;
            }

            if (ar[m] == value) return m;
            else return -1;
        }
        #endregion
    }
}
