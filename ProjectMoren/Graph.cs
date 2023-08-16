namespace ProjectMoren;

public class Graph
{
    public int TotalNumber { get; set; }
    private List<int>[] Nodes { get; set; }

    public Graph(int number)
    { 
        TotalNumber = number;
        Nodes = new List<int>[TotalNumber];
        for(int i = 0; i < TotalNumber; i++)
        {
            Nodes[i] = new List<int>();
        }
    }
    public void AddEdges(int v, int w)
    {
        Nodes[v].Add(w);
        Nodes[w].Add(v);
    }
    public void PrintGraph()
    {
        for(int i = 0; i<TotalNumber; i++)
        {
            Console.WriteLine($"Vertex {i}:");
            for (int j = 0; j < Nodes[i].Count; j++)
            {
                Console.Write(Nodes[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public List<int> getVertexIndex(int number)
    {
        return Nodes[number];
    }
}
