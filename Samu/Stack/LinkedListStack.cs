using System;
using System.Collections.Generic;
using System.Text;

namespace Samu.Stack
{
    public class LinkedListStack<T>
    {
        private Node<T> head;
        private int index;
        public LinkedListStack()
        {
            head = null;
            index = 0;
        }
        public void Push(T item)
        {
            Node<T> oldNode = head;
            head = new Node<T>(item);
            head.Next = oldNode;
            index++;
        }
        public T Pop()
        {
            T item = head.Item;
            head = head.Next;
            index--;
            return item;
        }
    }
}
