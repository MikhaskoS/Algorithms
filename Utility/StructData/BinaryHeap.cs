using System;

namespace Utility.StructData
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        //нумерация элементов пирамиды начинается с 1.
        //                      (1)
        //              /                \
        //            (2)                (3)
        //         /       \          /       \
        //       (4)      (5)        (6)      (7)
        //       / \      / \        / \      / \
        //      (8)(9)  (10)(11)  (12)(13)  (14)(15)

        // базовый массив
        public T[] a;
        private static int heap_size = 0;
        private bool MaxHeap = true;

        // для строительства пирамиды используется простой одномерный массив
        // по умолчаню, пирамида строится НЕУБЫВАЮЩЕЙ
        public BinaryHeap(T[] A)
        {
            a = new T[A.Length + 1];
            // элемент с нулевым индексом полагается
            // равным нулю (для соответствия по индексам).
            a[0] = default(T);

            for (int i = 0; i < A.Length; i++)
            {
                a[i + 1] = (T)A[i];
            }

            // строим невозрастающую пирамиду.
            BUILD_MAX_HEAP(a);
        }

        /// <summary>
        /// Реализация пирамиды
        /// </summary>
        /// <param name="A"></param>
        /// <param name="maxHeap">true - невозрастающая, false - неубывающая</param>
        public BinaryHeap(T[] A, bool maxHeap)
        {
            MaxHeap = maxHeap;
            a = new T[A.Length + 1];
            // элемент с нулевым индексом полагается
            // равным нулю.
            a[0] = default(T);
            for (int i = 0; i < A.Length; i++)
            {
                a[i + 1] = (T)A[i];
            }
            if (maxHeap)
            {
                // строим невозрастающую пирамиду.
                BUILD_MAX_HEAP(a);
            }
            else
            {
                BUILD_MIN_HEAP(a);
            }
        }

        public int HeapSize
        { get { return heap_size; } }


        // родительский узел (пример: i = 7, PARENT = (int)7/2 = 3)
        private int PARENT(int i)
        { return i / 2; }
        // левый дочерний узел (пример: i = 7, LEFT = 14)
        private int LEFT(int i)
        { return 2 * i; }
        // правый дочерний узел (пример: i = 7, RIGHT = 15)
        private int RIGHT(int i)
        { return 2 * i + 1; }

        /// <summary>
        /// Строим невозрастающую пирамиду.
        /// </summary>
        /// <param name="A">Массив A[]. Полагаем A[0] = 0.</param>
        private void BUILD_MAX_HEAP(T[] A)
        {
            heap_size = A.Length - 1;
            for (int i = heap_size / 2; i >= 1; i--)
            {
                MAX_HEAPIFY(A, i);
            }
        }

        private void BUILD_MIN_HEAP(T[] A)
        {
            heap_size = A.Length - 1;
            for (int i = heap_size / 2; i >= 1; i--)
            {
                MIN_HEAPIFY(A, i);
            }
        }

        //эта функция опускает элемент A[i] до тех пор, пока не встретится элемент
        //меньше него
        public void MAX_HEAPIFY(T[] A, int i)
        {
            //дочерние узлы
            int l = LEFT(i);
            int r = RIGHT(i);
            int largest;
            //ищем индекс максимального элемента
            if ((l <= heap_size) && (A[l].CompareTo(A[i])) > 0) { largest = l; }
            else { largest = i; }
            if ((r <= heap_size) && (A[r].CompareTo(A[largest])) > 0) { largest = r; }
            //если индекс максимального элемента не i, произведем обмен числами
            if (largest != i)
            {
                T t = (T)A[i];
                A[i] = A[largest];
                A[largest] = t;
                MAX_HEAPIFY(A, largest);
            }
        }

        //эта функция опускает элемент A[i] до тех пор, пока не встретится элемент
        //больше него
        public void MIN_HEAPIFY(T[] A, int i)
        {
            //дочерние узлы
            int l = LEFT(i);
            int r = RIGHT(i);
            int largest;
            //ищем индекс максимального элемента
            if ((l <= heap_size) && (A[l].CompareTo(A[i])) < 0) { largest = l; }
            else { largest = i; }
            if ((r <= heap_size) && (A[r].CompareTo(A[largest])) < 0) { largest = r; }
            //если индекс максимального элемента не i, произведем обмен числами
            if (largest != i)
            {
                T t = (T)A[i];
                A[i] = A[largest];
                A[largest] = t;
                MIN_HEAPIFY(A, largest);
            }
        }

        public void HeapMaxSort()
        {
            if (!MaxHeap)
            {
                BUILD_MAX_HEAP(a);
            }
            for (int i = a.Length - 1; i >= 2; i--)
            {
                T t = a[1];
                a[1] = a[i];
                a[i] = t;
                heap_size = heap_size - 1;
                MAX_HEAPIFY(a, 1);
            }
        }

        public void HeapMinSort()
        {
            if (MaxHeap)
            {
                // переделаем пирамиду в невозрастающую
                BUILD_MIN_HEAP(a);
            }
            for (int i = a.Length - 1; i >= 2; i--)
            {
                T t = a[1];
                a[1] = a[i];
                a[i] = t;
                heap_size = heap_size - 1;
                MIN_HEAPIFY(a, 1);
            }
        }
    }
}
