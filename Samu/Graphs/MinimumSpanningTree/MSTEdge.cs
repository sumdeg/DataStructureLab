using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.Graphs.MinimumSpanningTree
{
    public class MSTEdge<T, W> : IComparable
            where W : IComparable
        
    {
        public MSTEdge(T source, T destination, W weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public T Source { get; }
        public T Destination { get; }
        public W Weight { get; }

        public int CompareTo(object obj)
        {
            return Weight.CompareTo(((MSTEdge<T, W>)obj).Weight);
        }

        public override string ToString()
        {
            return $"{Source} - {Destination} W:{Weight}";
        }
    }
}
