using System;
using System.Collections.Generic;
using System.Text;

namespace Samu.Queue
{
    public class ArrayQueue<T>
    {
        private T[] items;
        private int head;
        private int tail;
        private int count;
        private int capacity;

        public bool isEmpty => this.count == 0;
        public int Count => count;
        public int Capacity => capacity;
        public ArrayQueue(int _capacity)
        {
            this.capacity = _capacity;
            this.head = this.tail=0;
            this.count = 0;
            items = new T[capacity];
        }
       
        public void EnQueue(T item)
        {
            if (count<capacity)
            {
                tail %= capacity;
                items[tail] = item;
                tail++;
                count++;
            }
            else
            {
                throw new Exception("Overflow!");
            }
        }
        public T DeQueue()
        {
            if (isEmpty)
            {
                throw new Exception("Underflow!");
            }
            else
            {
                T item = items[head];
                items[head] = default(T);
                head = (head + 1) % capacity;
                count--;
                return item;
            }
        }
    }
}
