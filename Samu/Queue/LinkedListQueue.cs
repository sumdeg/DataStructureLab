using System;
using System.Collections.Generic;
using System.Text;

namespace Samu.Queue
{
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
        public Node()
        {

        }
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
        public bool isEmpty => count == 0;
        public LinkedListQueue()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public void EnQueue(T item)
        {          
            Node<T> oldLastNode = tail;
            tail = new Node<T>(item);          
            if (isEmpty)
            {
                head = tail;
            }
            else
            {
                oldLastNode.Next = tail;
            }
            count++;
        }

        public T DeQueue()
        {
            T result = head.Item;
            head = head.Next;
            count--;
            if (count==0)
            {
                tail = null;
            }
            return result;

        }
    }
}
