using System;
using System.Collections.Generic;
using System.Text;

namespace QueueApp
{
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
        public Node(T item)
        {
            Item = item;
        }
    }
    public class LinkedListQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;
        public LinkedListQueue()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public void EnQueue(T data)
        {
            Node<T> temp = new Node<T>(data);
            if (head==null)
            {
                head = tail = temp;
                Console.WriteLine("{0} kuyruga eklendi",data);
            }
            else
            {
                tail.Next = temp;
                tail = temp;
                Console.WriteLine("{0} kuyruga eklendi",data);
            }
            count++;
        }

        public T DeQueue()
        {
            if (head==null)
            {
                return default(T);
            }

             Node<T> temp = head;
             head = head.Next;
             Console.WriteLine("{0} kuyruktan silindi",temp.Item);
             Console.WriteLine("Head item: {0} ", head.Item);
             Console.WriteLine("Tail item: {0} ", tail.Item);
             count--;
             return temp.Item;
        }
    }
}
