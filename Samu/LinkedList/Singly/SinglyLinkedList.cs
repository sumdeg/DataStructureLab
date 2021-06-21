using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.LinkedList.Singly
{
    public class SinglyLinkedList<T>
    {
        private int count;

        public Node<T> head;
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
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException("index", "Index out of range");

            }
            Node<T> tempNode = head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }

        public SinglyLinkedList()
        {
            count = 0;
            head = null;
        }
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (head==null)
            {
                head = newNode;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(count - 1);
                prevNode.Next = newNode;

            }
            count++;
        }
        public void Insert(int index, T value)
        {
            Node<T> tempNode = null;
            tempNode = new Node<T>(value);
            if (index<0 || index>this.count)
            {
                throw new ArgumentOutOfRangeException("Index","Index out of range.");
            }
            else if (index==0)
            {
                if (this.head==null)
                {                
                    this.head = tempNode;
                }
                else
                {
                    tempNode.Next = this.head;
                    this.head = tempNode;
                }
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                tempNode.Next = prevNode.Next;
                prevNode.Next = tempNode;
            }
            this.count++;
        }

        public void RemoveAt(int index)
        {
            if (index==0)
            {
                this.head = this.head.Next;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                if (prevNode.Next==null)
                {
                    throw new ArgumentOutOfRangeException("Index", "Index out of range.");

                }
                Node<T> deleteNode = prevNode.Next;
                prevNode.Next = deleteNode.Next;
                deleteNode = null;
            }
            this.count--;
        }
        public void DisplayItems()
        {
            Node<T> currentNode = head;
            Console.WriteLine();
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Item);
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }

     
    }
}
