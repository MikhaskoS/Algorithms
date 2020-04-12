using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Sorting
{
    public class QuickSort
    {
        public static void Sort<T>(T[] A) where T : IComparable<T>
        {
            Sort(A, 0, A.Length - 1);
        }


        private static void Sort<T>(T[] A, int p, int r) where T : IComparable<T>
        {
            if (p < r)
            {
                int q = Partition(A, p, r);

                Sort(A, p, q - 1);
                Sort(A, q + 1, r);
            }
        }

        private static int Partition<T>(T[] A, int p, int r)where T : IComparable<T>
        {
            T x = A[r];
            int i = p - 1;
            for (int j = p; j <= r - 1; j++)
            {
                if (A[j].CompareTo(x) <= 0)
                {
                    i += 1;
                    T t = A[i];
                    A[i] = A[j];
                    A[j] = t;
                }
            }
            T t1 = A[i + 1];
            A[i + 1] = A[r];
            A[r] = t1;

            return i + 1;
        }

    }
}
