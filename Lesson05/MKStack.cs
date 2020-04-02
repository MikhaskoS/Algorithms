using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson05
{
    // Стек (первый вошел, последний вышел)
    public class MKStack<T> : IEnumerable<T> where T : unmanaged
    {
        // верхушка стека
        Node<T> head;
        // количество элементов стека
        int count;

        public bool IsEmpty => count == 0;
        public int Count => count;

        /// <summary> Добавить элемент в стек </summary>
        public void Push(T item)
        {
            Node<T> node = new Node<T>(item)
            {
                Next = head // переустанавливаем верхушку стека на новый элемент
            };
            head = node;
            count++;
        }

        /// <summary> Извлечь элемент из стека </summary>
        public T Pop()
        {
            // если стек пуст, выбрасываем исключение
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            Node<T> temp = head;
            head = head.Next; // переустанавливаем верхушку стека на следующий элемент
            count--;
            return temp.Data;
        }
        public T Head()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            return head.Data;
        }

        public unsafe void DisplaySizeOf()
        {
            Console.WriteLine($"Size of stack is {count * sizeof(T)}");

            // демонстрация того, как можно генерировать исключение
            int maxSize = 20000; // максимальный размер памяти для типов
            if (count * sizeof(T) > maxSize)
                throw new OutOfMemoryException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public MKStack<T> Clone()
        {
            Node<T> _newHead = CloneNode(head);
            MKStack<T> _newStack = new MKStack<T>();
            _newStack.head = _newHead;
            _newStack.count = count;

            return _newStack;
        }

        // Клонирование узлов (предполагается, что тип T - значимый)
        private Node<T> CloneNode(Node<T> head)
        {
            Node<T> _h = new Node<T>(head.Data);
            if(head.Next != null) _h.Next = CloneNode(head.Next);
            return _h;
        }
    }
}
