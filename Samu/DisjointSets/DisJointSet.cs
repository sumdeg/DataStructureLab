using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Samu.DisjointSets
{
    public class DisJointSet<T> : IEnumerable<T>
    {
        private Dictionary<T, DisJointSetNode<T>> set = new Dictionary<T, DisJointSetNode<T>>();

        public int Count { get; private set; }
        public void MakeSet(T member)
        {
            if (set.ContainsKey(member))
                return;
            var newSet = new DisJointSetNode<T>()
            {
                Data = member,
                Rank = 0
            };
            newSet.Parent = newSet;
            set.Add(member, newSet);
            Count++;
        }
        private DisJointSetNode<T> FindSet(DisJointSetNode<T> node)
        {
            if (node != node.Parent)
            {
                return FindSet(node.Parent);
            }
            return node.Parent;
        }
        public T FindSet(T member)
        {
            if (!set.ContainsKey(member))
            {
                throw new Exception("No such set with given member.");
            }
            return FindSet(set[member]).Data;
        }

        public void Union(T member1, T member2)
        {
            var root1 = FindSet(member1);
            var root2 = FindSet(member2);
            if (root1.Equals(root2))
                return;

            var Node1 = set[root1];
            var Node2 = set[root2];

            if (Node1.Rank == Node2.Rank)
            {
                Node2.Parent = Node1;
                Node1.Rank++;
            }
            else
            {
                if (Node1.Rank < Node2.Rank)
                    Node1.Parent = Node2;
                else
                    Node2.Parent = Node1;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return set.Values.Select(x => x.Data).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
