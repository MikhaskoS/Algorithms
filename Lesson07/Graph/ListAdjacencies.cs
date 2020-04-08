using System.Collections;
using System.Collections.Generic;

namespace myGraph
{
    // список смежностей
    public class ListAdjacencies<T> : IEnumerable<T>
    {
        int count;
        Node<T> first; // первый элемент списка
        Node<T> last;  // последний элемент списка

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if (count == 0)
                first = node;
            else
                last.Next = node;

            last = node;
            count++;
        }

        #region Properties

        public bool IsEmpty => count == 0;
        public int Count { get => count; set => count = value; }
        public Node<T> First { get => first; set => first = value; }
        public Node<T> Last { get => last; set => last = value; }

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        #endregion
    }
}
