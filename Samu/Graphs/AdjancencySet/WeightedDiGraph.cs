using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.Graphs.AdjancencySet
{
    public class WeightedDiGraph<T, TW> : IDiGraph<T>
       where TW : IComparable
    {
        private Dictionary<T, WeightedDiGraphVertex<T, TW>> vertices;

        public IDiGraphVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumberable =>
            vertices.Select(x => x.Value);

        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferenceVertex =>
            vertices[this.First()] as IGraphVertex<T>;

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumberable =>
            vertices.Select(x => x.Value);

        public WeightedDiGraph()
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, TW>>();
        }

        public void AddVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException();
            var newVertex = new WeightedDiGraphVertex<T, TW>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public WeightedDiGraph<T, TW> Clone()
        {
            var graph = new WeightedDiGraph<T, TW>();
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);

            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.OutEdges)
                {
                    graph.AddEdge(vertex.Value.Key, edge.Key.Key, edge.Value);
                }
            }
            return graph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if (key == null)
                throw new ArgumentNullException();
            return vertices[key].Edges.Select(x => x.TargetVertexKey);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (!vertices.ContainsKey(source) ||
               !vertices.ContainsKey(dest))
                throw new ArgumentNullException();

            return vertices[source].OutEdges.ContainsKey(vertices[dest])
                && vertices[dest].InEdges.ContainsKey(vertices[source]);
        }

        public void AddEdge(T source, T dest, TW weight)
        {
            if (source == null | dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) ||
                !vertices.ContainsKey(dest))
                throw new ArgumentException("Source or destination vertex is not in this graph.");

            if (vertices[source].OutEdges.ContainsKey(vertices[dest]) ||
                vertices[dest].InEdges.ContainsKey(vertices[source]))
                throw new Exception("The edge has been already defined.");

            vertices[source].OutEdges.Add(vertices[dest], weight);
            vertices[dest].InEdges.Add(vertices[source], weight);
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null | dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) ||
                !vertices.ContainsKey(dest))
                throw new ArgumentException("Source or destination vertex is not in this graph.");

            if (!vertices[source].OutEdges.ContainsKey(vertices[dest])
                || !vertices[dest].InEdges.ContainsKey(vertices[source]))
                throw new Exception("The edge doesn't exists.");

            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException();
            if (!vertices.ContainsKey(key))
                throw new ArgumentException("The vertex is not in this graph.");

            foreach (var edge in vertices[key].OutEdges)
            {
                edge.Key.OutEdges.Remove(vertices[key]);
            }

            foreach (var edge in vertices[key].InEdges)
            {
                edge.Key.InEdges.Remove(vertices[key]);
            }

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class WeightedDiGraphVertex<T, TW> : IDiGraphVertex<T>
            where TW : IComparable
        {
            public Dictionary<WeightedDiGraphVertex<T, TW>, TW> OutEdges { get; }
            public Dictionary<WeightedDiGraphVertex<T, TW>, TW> InEdges { get; }

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.OutEdges =>
                 OutEdges.Select(x => new DiEdge<T, TW>(x.Key, x.Value));

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.InEdges =>
                InEdges.Select(x => new DiEdge<T, TW>(x.Key, x.Value));

            public int OutEdgesCount => OutEdges.Count;

            public int InEdgesCount => InEdges.Count;

            public T Key { get; set; }

            public WeightedDiGraphVertex(T key)
            {
                Key = key;
                OutEdges = new Dictionary<WeightedDiGraphVertex<T, TW>, TW>();
                InEdges = new Dictionary<WeightedDiGraphVertex<T, TW>, TW>();
            }

            public IEnumerable<IEdge<T>> Edges =>
                OutEdges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                var key = targetVertex as WeightedDiGraphVertex<T, TW>;
                return new Edge<T, TW>(targetVertex, OutEdges[key]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x => x.Key.Key).GetEnumerator();
            }

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex)
            {
                var key = targetVertex as WeightedDiGraphVertex<T, TW>;
                return new DiEdge<T, TW>(targetVertex, OutEdges[key]);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
