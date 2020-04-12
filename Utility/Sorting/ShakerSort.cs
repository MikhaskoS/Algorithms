using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Sorting
{
    public class ShakerSort
    {
        public static void Sort(int[] A)
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
    }
}
