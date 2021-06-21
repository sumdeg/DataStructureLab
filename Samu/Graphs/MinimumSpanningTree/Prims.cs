using Samu.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.Graphs.MinimumSpanningTree
{
    public class Prims<T, W>
         where W : IComparable
    {
        public List<MSTEdge<T, W>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, W>>();
            // tüm benzersiz kenarlar 
            dfs(graph,
                graph.ReferenceVertex,
                new MinHeap<MSTEdge<T, W>>(),
                new HashSet<T>(),
                edges);

            return edges;
        }

        private void dfs(IGraph<T> graph,
            IGraphVertex<T> currentVertex,
            MinHeap<MSTEdge<T, W>> spannTreeNeighbours,
            HashSet<T> spanTreeVertices,
            List<MSTEdge<T, W>> spanTreeEdges)
        {
            while (true)
            {
                // Kenarları heap ekle
                foreach (var edge in currentVertex.Edges)
                {
                    spannTreeNeighbours.Add(new
                        MSTEdge<T, W>(currentVertex.Key,
                        edge.TargetVertexKey,
                        edge.Weight<W>()));
                }

                // en küçük kenarı al 
                var minNeighboursEdge = spannTreeNeighbours.DeleteMinMax();

                // var olan kenarı atla. 
                while (spanTreeVertices.Contains(minNeighboursEdge.Source) &&
                    spanTreeVertices.Contains(minNeighboursEdge.Destination))
                {
                    minNeighboursEdge = spannTreeNeighbours.DeleteMinMax();

                    
                    // keşfedilecek eleman kalmaz ise. 
                    if (spannTreeNeighbours.Count==0)
                        return;
                }

                // eklenen vertex takip et. 
                if (!spanTreeVertices.Contains(minNeighboursEdge.Source))
                {
                    spanTreeVertices.Add(minNeighboursEdge.Source);
                }

                // destination tekrar edemez!
                spanTreeVertices.Add(minNeighboursEdge.Destination);

                spanTreeEdges.Add(minNeighboursEdge);

                // destination vertex keşfet.
                var graph1 = graph;
                currentVertex = graph1.GetVertex(minNeighboursEdge.Destination);
            }
        }
    }
}
