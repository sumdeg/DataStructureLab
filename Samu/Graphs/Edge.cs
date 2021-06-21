using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.Graphs
{
    public class Edge<T, C> : IEdge<T>
        where C : IComparable
    {
        private object weight;

        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public Edge(IGraphVertex<T> target, C weight)
        {
            this.TargetVertex = target;
            this.weight = weight;
        }

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }
    public class DiEdge<T, C> : IDiEdge<T>
        where C : IComparable
    {
        private object weight;
        public IDiGraphVertex<T> TargetVertex { get; private set; }

        public T TargetVertexKey => TargetVertex.Key;

        public DiEdge(IDiGraphVertex<T> target, C weight)
        {
            this.TargetVertex = target;
            this.weight = weight;
        }

        IGraphVertex<T> IEdge<T>.TargetVertex => TargetVertex as IGraphVertex<T>;

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }
}
