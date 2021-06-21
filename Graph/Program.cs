using Graphs.AdjancencyMatrix;
using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<int>();
            for (int i = 0; i < 5; i++)
            {
                graph.AddVertex(i);
            }
            graph.AddEdge(1, 0);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 4);
            Console.WriteLine($"Vertex Count : {graph.VerticesCount}");

            foreach (var vertex in graph)
            {
                Console.Write(vertex);
                Console.Write(" -> ");
                foreach (var edge in graph.Edges(vertex))
                {
                    Console.Write(edge+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("0 ve 1 arasında kenar {0}",graph.HasEdge(0,1)?"var":"yok");
            Console.WriteLine();
            Console.WriteLine("1 ve 3 arasında kenar {0}",graph.HasEdge(1,3)?"var":"yok");

            //graph.RemoveEdge(0, 1);
            Console.WriteLine("0 ve 1 arasında kenar {0}", graph.HasEdge(0, 1) ? "var" : "yok");

            graph.RemoveVertex(1);
            foreach (var vertex in graph)
            {
                Console.Write(vertex);
                Console.Write(" -> ");
                foreach (var edge in graph.Edges(vertex))
                {
                    Console.Write(edge + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
