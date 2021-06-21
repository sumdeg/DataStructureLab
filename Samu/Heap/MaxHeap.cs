using System;
using System.Collections.Generic;

namespace Samu.Heap
{
    public class MaxHeap<T> : BHeap<T>, IEnumerable<T> where T : IComparable
    {
        public MaxHeap() : base()
        {

        }
        public MaxHeap(int _size) : base(_size)
        {

        }
        public MaxHeap(IEnumerable<T> coll) : base(coll)
        {

        }

        public override void Heapify(int length, int index)
        {
            int left = GetLeftChildIndex(index);
            int right = GetRightChildIndex(index);
            int max = index;
            if (left < length && GetLeftChild(index).CompareTo(Array[max]) < 0)
            {
                max = left;
            }
            else
            {
                max = index;
            }
            if (right < length && GetRightChild(index).CompareTo(Array[max]) < 0)
            {
                max = right;
            }
            if (max != index)
            {
                Swap(index, max);
                Heapify(length, max);
            }
        }

        public override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) > 0)
                {
                    smallerIndex = GetRightChildIndex(index);
                }
                if (Array[smallerIndex].CompareTo(Array[index]) < 0)
                {
                    break;
                }
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        public override void HeapifyUp()
        {
            var index = position - 1;
            while (!IsRoot(index) && Array[index].CompareTo(GetParent(index)) > 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }


    }
}
