using System;
using System.Collections.Generic;
using System.Text;

namespace Samu.DisjointSets
{
    public class DisJointSetNode<T>
    {
        public T Data { get; set; }
        public int Rank { get; set; }
        public DisJointSetNode<T> Parent { get; set; }
        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
