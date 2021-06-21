using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samu.Heap
{
    public abstract class BHeap<T> : IEnumerable<T> where T : IComparable
    {
        protected T[] Array;
        protected int position;
        public BHeap()
        {
            Count = 0;
            Array = new T[100];
            position = 0;
        }
        public BHeap(int _size)
        {
            Count = 0;
            Array = new T[_size];
            position = 0;
        }
        public BHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public int Count { get; private set; }
        protected int GetParentIndex(int i) => (i - 1) / 2;
        protected int GetLeftChildIndex(int i) => 2 * i + 1;
        protected int GetRightChildIndex(int i) => 2 * i + 2;

        protected T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        protected T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        protected T GetParent(int i) => Array[GetParentIndex(i)];

        protected bool IsRoot(int i) => i == 0;
        protected bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        protected bool HasRightChild(int i) => GetRightChildIndex(i) < position;
        public bool IsEmpty() => position == 0;
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new ArgumentNullException("Heap is empty...");
            }
            return Array[0];
        }
        protected void Swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            if (position == Array.Length)
            {
                throw new IndexOutOfRangeException("Overflow!");
            }
            Array[position] = item;
            position++;
            Count++;
            HeapifyUp();
        }

        public T DeleteMinMax()
        {
            if (position==0)
            {
                throw new IndexOutOfRangeException("The heap is empty");
            }
            var result = Array[0];
            Array[0] = Array[position - 1];
            position--;
            Count--;
            HeapifyDown();
            return result;
        }
        public abstract void HeapifyUp();
        public abstract void HeapifyDown();
        public abstract void Heapify(int length, int index);

        public void HeapSort()
        {
            int heapSize = Array.Length;
            for (int i = heapSize - 1 / 2; i >= 0; i--)
            {
                Heapify(heapSize, i);
            }

            for (int i = heapSize - 1; i >= 0; i--)
            {
                Swap(0, i);
                heapSize--;
                Heapify(i, 0);
            }
        }
    }
}
