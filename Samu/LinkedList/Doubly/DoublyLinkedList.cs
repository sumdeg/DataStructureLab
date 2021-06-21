using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.LinkedList.Doubly
{
    public class DoublyLinkedList<T>
    {
        private int count;
        private DbNode<T> head;
        public int Count => count;
        public T this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Item;
            }
            set
            {
                GetNodeByIndex(index).Item = value;
            }
        }
        private DbNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException("index", "Index out of range");

            }
            DbNode<T> tempNode = head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }
        public DoublyLinkedList()
        {
            count = 0;
            head = null;
        }
        public void AddAfter(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                DbNode<T> lastNode = GetNodeByIndex(count - 1);
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }
            count++;
        }
        public void AddBefore(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                DbNode<T> lastNode = GetNodeByIndex(count - 1);
                DbNode<T> prevNode = lastNode.Prev;

                prevNode.Next = newNode;
                newNode.Prev = prevNode;

                lastNode.Prev = newNode;
                newNode.Next = lastNode;

            }
            count++;
        }
        public void DisplayItems()
        {
            var currentNode = head;
            Console.WriteLine();
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Item);
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                DbNode<T> prevNode = GetNodeByIndex(index - 1);
                if (prevNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException("index", "Index out of range");
                }
                DbNode<T> deleteNode = prevNode.Next;
                DbNode<T> nextNode = deleteNode.Next;
                prevNode.Next = nextNode;
                if (nextNode != null)
                {
                    nextNode.Prev = prevNode;
                }
                deleteNode = null;
            }
            count--;
        }
        public void RemoveLast()
        {
            DbNode<T> tempNode = new DbNode<T>();
            DbNode<T> lastNode = GetNodeByIndex(count - 1);
            tempNode = lastNode;
            lastNode = lastNode.Prev;
            if (lastNode == null)
            {
                head = null;
            }
            else
            {
                lastNode.Next = null;
            }
            count--;
        }

    }
}
