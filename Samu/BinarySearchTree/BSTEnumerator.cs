using System;
using System.Collections;
using System.Collections.Generic;

namespace Samu.BinarySearchTree
{
    public class BSTEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private List<Node<T>> list;
        private int indexer = -1;
        public BSTEnumerator(Node<T> root)
        {
            list = BST<T>.LevelOrderTraversal(root);
        }
        public T Current => list[indexer].Item;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            list = null;
        }

        public bool MoveNext()
        {
            indexer++;
            return indexer < list.Count ? true : false;
        }

        public void Reset()
        {
            indexer = -1;
        }
    }
}