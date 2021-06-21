using Samu.DisjointSets;
using Samu.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samu.SortingAlgorithms;

namespace Samu.Graphs.MinimumSpanningTree
{
    public class Kruskals<T, W> where W : IComparable
    {
        public List<MSTEdge<T, W>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, W>>();

            // unique tüm kenarları al. 
            dfs(graph.ReferenceVertex, new HashSet<T>(),
                new Dictionary<T, HashSet<T>>(),
                edges);

            var sortArray = new MSTEdge<T, W>[edges.Count];
            for (int i = 0; i < edges.Count; i++)
            {
                sortArray[i] = edges[i];
            }

            //var sortedEdges = BubbleSort.Sort<MSTEdge<T, W>>(sortarray);
            var result = new List<MSTEdge<T, W>>();
            var disJointSet = new DisJointSet<T>();

            // set küme oluşturma
            foreach (var vertex in graph.VerticesAsEnumberable)
            {
                disJointSet.MakeSet(vertex.Key);
            }

            for (int i = 0; i < edges.Count; i++)
            {
                //var currentEdge = sortedEdges[i];

                //var setA = disJointSet.FindSet(currentEdge.Source);
                //var setB = disJointSet.FindSet(currentEdge.Destination);

                //if (setA.Equals(setB))
                //    continue;

                //result.Add(currentEdge);
                //disJointSet.Union(setA, setB);
            }

            return result;
        }
    
        private void dfs(IGraphVertex<T> currentVertex,
            HashSet<T> visitedVertices,
            Dictionary<T, HashSet<T>> visitedEdges,
            List<MSTEdge<T, W>> edges)
        {
            if (!visitedVertices.Contains(currentVertex.Key))
            {
                visitedVertices.Add(currentVertex.Key);
                foreach (var edge in currentVertex.Edges)
                {
                    if (!visitedEdges.ContainsKey(currentVertex.Key)
                        || !visitedEdges[currentVertex.Key].Contains(edge.TargetVertexKey))
                    {
                        edges.Add(new MSTEdge<T, W>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<W>()));

                        // güncelleme : visited edge
                        if (!visitedEdges.ContainsKey(currentVertex.Key))
                        {
                            visitedEdges.Add(currentVertex.Key, new HashSet<T>());
                        }

                        visitedEdges[currentVertex.Key].Add(edge.TargetVertexKey);

                        // güncelleme : visited back edge
                        if (!visitedEdges.ContainsKey(edge.TargetVertexKey))
                        {
                            visitedEdges.Add(edge.TargetVertexKey, new HashSet<T>());
                        }

                        visitedEdges[edge.TargetVertexKey].Add(currentVertex.Key);

                        dfs(edge.TargetVertex, visitedVertices, visitedEdges, edges);
                    }
                }
            }
        }
    }
}
