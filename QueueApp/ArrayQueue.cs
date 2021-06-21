using System;
using System.Collections.Generic;
using System.Text;

namespace QueueApp
{
    public class ArrayQueue<T>
    {
        private T[] items;
        private int head;
        private int tail;
        private int count;

        public ArrayQueue(int capacity=5)
        {
            this.items = new T[capacity];
            this.tail = -1;
            this.head = 0;
            this.count = 0;
        }
        public void EnQueue(T data)
        {
            if (tail==items.Length-1)
            {
                Console.WriteLine();
            }
            else
            {
                items[++tail] = data;
                Console.WriteLine("{0} kuyruğa eklendi",data);
                count++;
            }
        }
        public T DeQueue()
        {
            if (head==tail+1)
            {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            else
            {
                T data;
                data = items[head++];
                Console.WriteLine("{0} kuyruktan cekildi",data);
                Console.WriteLine("Head item: {0} ",items[head]);
                Console.WriteLine("Tail item: {0} ", items[tail]);
                return data;
            }
        }
    }
}
