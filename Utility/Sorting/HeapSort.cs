using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.StructData;

namespace Utility.Sorting
{
    public class HeapSort
    {
        public static void Sort<T>(T[] A) where T : IComparable<T>
        {
            BinaryHeap<T> heap = new BinaryHeap<T>(A, true);

            heap.HeapMaxSort();
        }
    }
}
