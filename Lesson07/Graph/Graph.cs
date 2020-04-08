using System;
using System.Collections.Generic;

namespace myGraph
{
    class Graph
    {
        #region Fields 

        private int _vertCount;
        private bool _oriented;
        private Vertex[] _vertices;
        private int[,] _matrixAdj;

        #endregion


        #region Properties

        /// <summary> Количество вершин графа </summary>
        public int VertCount { get => _vertCount; set => _vertCount = value; }
        /// <summary> Ориентированность графа </summary>
        public bool Oriented { get => _oriented; set => _oriented = value; }
        /// <summary> Массив  вершин графа </summary>
        public Vertex[] Vertices { get => _vertices; set => _vertices = value; }
        /// <summary> Матрица смежностей </summary>
        public int[,] MatrixAdj { get => _matrixAdj; set => _matrixAdj = value; }

        #endregion


        public Graph(int vertex)
        {
            _vertCount = vertex;
            _oriented = false;
            _vertices = new Vertex[_vertCount];
        }

        // Построение матрицы и списка смежности из строки
        public void ReadAdjMatrix(string matrix)
        {
            string[] s = matrix.Split(new char[] {' ', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            _matrixAdj = new int[_vertCount, _vertCount];
            int k=0;
            for (int i = 0; i < _vertCount; i++)
            {
                for (int j = 0; j < _vertCount; j++)
                {
                    int r = int.Parse(s[k]);
                    _matrixAdj[i, j] = r;
                    k++;
                }
            }

            for (int i = 0; i < _vertCount; i++)
            {
                Vertex v = new Vertex(i);
                _vertices[i] = v;
                for (int j = 0; j < _vertCount; j++)
                {
                    if (_matrixAdj[i, j] != 0)
                        v.Adj.Add(new int[] { j, _matrixAdj[i, j] } );
                }
            }
        }

        // обход графа в ширину
        // простая модификация этой функции может служить для
        // - поиска кратчайшего расстояния у невзвешенных графов
        // - построения дерева поиска в ширину
        public void BFS(int start)
        {
            // маркировка вершин
            // -1 не посещали
            //  0 посетили, но не обработали
            //  1 обработана
            int[] markers = new int[_vertCount];
            for (int i = 0; i < markers.Length; i++)
                markers[i] = -1;

            // Очередь реализована в уроке 5, однако для большей универсальности
            // теперь воспользуемся библиотечной реализацией
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(_vertices[start]);
            while (queue.Count != 0)
            {
                Vertex v = queue.Dequeue();
                // обследуем смежные вершины
                foreach (int[] e in v.Adj)
                {
                    int id = _vertices[e[0]].Id; // индекс смежной вершины
                    if (markers[id] == -1) // видим впервые
                    {
                        //-----------------------------------
                        // Если мы работаем с невзвешенными графами (вес ребер = 1)
                        // то найденная вершина дает кратчайшее расстояние
                        //-----------------------------------
                        markers[id] = 0;
                        queue.Enqueue(_vertices[id]); // в очередь на изучение
                    }
                }
                markers[v.Id] = 1;
                Console.Write($"{v.Id} ");
            }
        }

        // поиск в глубину
        public void DFS(int start)
        {
            // маркировка вершин
            // -1 не посещали
            //  0 посетили, но не обработали
            //  1 обработана
            int[] markers = new int[_vertCount];
            for (int i = 0; i < markers.Length; i++)
                markers[i] = -1;

            for (int i = 0; i < _vertices.Length; i++)
                if (markers[i] == -1) dfs_visit(i, ref markers);
        }

        private void dfs_visit(int id_v, ref int[] markers)
        {
            markers[id_v] = 0;
            foreach (int[] e in _vertices[id_v].Adj)
            {
                int id = _vertices[e[0]].Id;
                if( markers[id] == -1)
                    dfs_visit(id, ref markers);
            }

            markers[id_v] = 1;
            Console.Write($"{id_v} ");
        }

        public void PrintVertexAdj()
        {
            for (int i = 0; i < _vertCount; i++)
            {
                Console.Write($"Vertex[{i}]: ID/VEIGHT ") ;
                foreach (int[] k in _vertices[i].Adj)
                {
                    Console.Write($"{k[0]}/{k[1]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
