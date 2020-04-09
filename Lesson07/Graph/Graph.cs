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
            _oriented = false;  // можно проверить матрицу на симметрию
            _vertices = new Vertex[_vertCount];
        }

        #region Чтение графа
        // Построение матрицы и списка смежности из строки
        public void ReadAdjMatrix(string matrix)
        {
            string[] s = matrix.Split(new char[] {' ', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
           
            // матрица смежностей
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

            // список смежностей
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
        #endregion


        #region поиск в ширину
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
        #endregion


        #region поиск в глубину

        public void DFS()
        {
            // маркировка вершин
            // -1 не посещали
            //  0 посетили, но не обработали
            //  1 обработана
            int[] markers = new int[_vertCount];
            for (int i = 0; i < markers.Length; i++)
                markers[i] = -1;

            for (int i = 0; i < _vertices.Length; i++)
                if (markers[i] == -1) Dfs_visit(i, ref markers);
        }

        private void Dfs_visit(int id_v, ref int[] markers)
        {
            markers[id_v] = 0;
            foreach (int[] e in _vertices[id_v].Adj)
            {
                int id = _vertices[e[0]].Id;
                if( markers[id] == -1)
                    Dfs_visit(id, ref markers);
            }

            markers[id_v] = 1;
            Console.Write($"{id_v} ");
        }
        #endregion


        #region Минимальное остовное дерево

        // Построение минимального остовного дерева (алгоритм Прима)
        // На выходе - граф с вершинами, у которых уазаны только
        // смежности минимального остовного дерева
        public Vertex[] MinimalTree()
        {
            int[] markers = new int[_vertCount];
            for (int i = 0; i < markers.Length; i++)
                markers[i] = -1;

            // начинаем формировать остовное дерево
            // вершины остовного дерева со своим списком смежностей
            Vertex[] mst_vertex = new Vertex[_vertCount];
            mst_vertex[0] = new Vertex(0);
            markers[0] = 1;

            int k = _vertCount;
            while (k > 1)
            {
                int[] v_min = ExtractMin(mst_vertex, markers, out int smV);

                if (v_min[0] != -1) // нашли
                {
                    // новая вершина
                    Vertex nV = new Vertex(smV);
                    nV.Adj.Add(v_min);
                    mst_vertex[smV] = nV;
                    markers[nV.Id] = 1;

                    // добавим информацию о новой вершине
                    mst_vertex[v_min[0]].Adj.Add(new int[] { smV, v_min[1] });

                    //Console.WriteLine(smV);

                    k--;
                }
            }

            return mst_vertex;
        }


        // получить вершину с минимальным весом ребра, смежную
        // к строящемуся остовному дереву
        private int[] ExtractMin(Vertex[] mst, int[] markers, out int smV)
        {
            int[] minV = new int[] { -1, int.MaxValue};
            int _min = int.MaxValue;
            smV = -1;

            // ищем вершину с минимальным весом
            foreach (Vertex v in _vertices) // проходим вершины
            {
                if (markers[v.Id] == 1) continue;
                if (v.Adj.Count == 0) continue;
                foreach (int[] adj in v.Adj) // проходим ребра
                {
                    if (adj[1] < _min)
                    {
                        // есть ли смежность
                        int sm_v = IsMst(adj[0], mst);
                        if (sm_v != -1)
                        {
                            _min = adj[1];
                            minV = adj;
                            smV = v.Id;
                        }
                    }
                }
            }
            return minV;
        }

        // проверка на смежность, возвращаем индекс смежной вершины
        // -1  - нет смжностей
        private int IsMst(int n, Vertex[] mst)
        {
            for (int i = 0; i < mst.Length; i++)
                if (mst[i] != null && n == mst[i].Id) return mst[i].Id;

            return -1;
        }

        #endregion


        #region Print

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

        public void PrintVertexAdj(Vertex[] vertex)
        {
            for (int i = 0; i < vertex.Length; i++)
            {
                Console.Write($"Vertex[{i}]: ID/VEIGHT ");
                foreach (int[] k in vertex[i].Adj)
                {
                    Console.Write($"{k[0]}/{k[1]} ");
                }
                Console.WriteLine();
            }
        }

        #endregion
    }
}
