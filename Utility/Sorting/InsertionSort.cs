using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Sorting
{
    public class InsertionSort
    {
        public static void Sort(int[] A)
        {
            // Сортировка вставкой  O(n^2)
            for (int j = 1; j < A.Length; j++)
            {
                int key = A[j];
                int i = j - 1;

                while (i >= 0 && A[i] > key)
                {
                    A[i + 1] = A[i];
                    i -= 1;
                }

                A[i + 1] = key;
            }
        }

        // обобщенная функция
        public static void Sort<T>(T[] A) where T : IComparable<T>
        {

            for (int j = 1; j < A.Length; j++)
            {
                T key = A[j];
                int i = j - 1;

                while (i >= 0 && A[i].CompareTo(key) > 0)
                {
                    A[i + 1] = A[i];
                    i -= 1;
                }

                A[i + 1] = key;
            }
        }
    }
}
