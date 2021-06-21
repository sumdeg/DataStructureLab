using System;
using System.Collections.Generic;
using System.Text;

namespace StackApp
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
}
