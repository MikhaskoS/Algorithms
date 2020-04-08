namespace myGraph
{
    public class Vertex
    {
        private int _id;

        // Идентификатор вершины
        public int Id { get => _id; set => _id = value; }
        // Список смежностей, состоящий из пар: [номер смежной вершины, вес ребра]
        public ListAdjacencies<int[]> Adj { get; set; }

        public Vertex(int id)
        {
            _id = id;
            Adj = new ListAdjacencies<int[]>();
        }
    }
}
