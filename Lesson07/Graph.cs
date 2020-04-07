using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Lesson07
{
    class Graph
    {
        private int _vertCount;
        private int _edgeCount;
        private bool _oriented;
        private Vertex[] _vertices;
        private int[,] _matrixAdj;

        public int VertCount { get => _vertCount; set => _vertCount = value; }
        public int EdgeCount { get => _edgeCount; set => _edgeCount = value; }
        public bool Oriented { get => _oriented; set => _oriented = value; }
        public Vertex[] Vertices { get => _vertices; set => _vertices = value; }
        public int[,] MatrixAdj { get => _matrixAdj; set => _matrixAdj = value; }

        public Graph(int vertex)
        {
            _vertCount = vertex;
            _oriented = false;
            _vertices = new Vertex[_vertCount];
        }

        // если матрица задана в виде строки
        public void ReadAdjMatrix(string matrix)
        {
            string[] s = matrix.Split(new char[] {' ', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            _matrixAdj = new int[_vertCount, _vertCount];

            for (int i = 0; i < _vertCount; i++)
            {
                for (int j = 0; j < _vertCount; j++)
                {
                    int r = int.Parse(s[i + j]);
                    _matrixAdj[i, j] = r;
                }
            }

            for (int i = 0; i < _vertCount; i++)
            {
                Vertex v = new Vertex(i);
                _vertices[i] = v;
                for (int j = 0; j < _vertCount; j++)
                {
                    if (_matrixAdj[i, j] != 0)
                        v.Adj.Add(j);
                }
            }
        }

        public void PrintVertexAdj()
        {
            for (int i = 0; i < _vertCount; i++)
            {
                Console.Write($"Vertex[{i}]: ") ;
                foreach (int k in _vertices[i].Adj)
                {
                    Console.Write($"{k} ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Vertex
    {
        private int _id;

        public int Id { get => _id; set => _id = value; }
        public ListAdjacencies<int> Adj { get; set; }

        public Vertex(int id)
        {
            _id = id;
            Adj = new ListAdjacencies<int>();
        }
    }

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

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}
