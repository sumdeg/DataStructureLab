using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.Graphs.Search
{
    public class DepthFirst<T>
    {
        public bool Find(IGraph<T> graph,T vertex)
        {
            return dfs(graph.ReferenceVertex,new HashSet<T>(),vertex);
        }
        private bool dfs(IGraphVertex<T> current,HashSet<T> visited,T searchVertex)
        {
            visited.Add(current.Key);
            Console.WriteLine(current.Key);
            if (current.Key.Equals(searchVertex))
            {
                return true;
            }
            foreach (var edge in current.Edges)
            {
                if (visited.Contains(edge.TargetVertexKey))
                    continue;
                if (dfs(edge.TargetVertex,visited,searchVertex))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
