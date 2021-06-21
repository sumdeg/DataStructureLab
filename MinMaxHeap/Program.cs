using System;

namespace MinMaxHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 10, 15, 4, 3, 6 };
            var heap = new MinHeap<int>(arr);
            foreach (var item in heap)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            heap.HeapSort();
            foreach (var item in heap)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
