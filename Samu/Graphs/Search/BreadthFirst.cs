using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.Graphs.Search
{
    public class BreadthFirst<T>
    {
        public bool Find(IGraph<T> graph,T vertexKey)
        {
            return bfs(graph.ReferenceVertex,new HashSet<T>() ,vertexKey);
        }
        private bool bfs(IGraphVertex<T> referenceVertex, HashSet<T> visited, T searchVertex)
        {
            var bfsQueue = new Queue<IGraphVertex<T>>();
            bfsQueue.Enqueue(referenceVertex);
            visited.Add(referenceVertex.Key);
            Console.WriteLine(referenceVertex.Key);
            while (bfsQueue.Count>0)
            {
                var current = bfsQueue.Dequeue();
                if (current.Key.Equals(searchVertex))
                    return true;
                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.TargetVertexKey))
                        continue;
                    visited.Add(edge.TargetVertexKey);
                    Console.WriteLine(edge.TargetVertexKey);

                    bfsQueue.Enqueue(edge.TargetVertex);
                }
            }

            return false;
        }
    }
}
