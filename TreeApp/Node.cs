using System;
using System.Collections.Generic;
using System.Text;

namespace TreeApp
{
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public void Display()
        {
            Console.Write($"{Item,5}");
        }
        public Node()
        {

        }
        public Node(T item)
        {
            Item = item;
        }
    }
}
