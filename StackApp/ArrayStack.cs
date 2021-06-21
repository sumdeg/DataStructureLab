using System;
using System.Collections.Generic;
using System.Text;

namespace StackApp
{
    public class ArrayStack<T>
    {
        private T[] stack;
        private int index;
        public ArrayStack(int capacity=2)
        {
            this.stack = new T[capacity];
            this.index = 0;
        }
        public void Push(T data)
        {
            if (index == stack.Length)
            {
                ResizeCapacity(stack.Length * 2);
            }
            else
            {
                stack[index] = data;
                index++;
            }
        }
        public T Pop()
        {
            T node;
            if (index == 0)
            {
                Console.WriteLine("Stack is empty");
                throw new Exception();
            }
            else
            {
                node = stack[index-1];
                index--;
                return node;
            }         
        }
        private void ResizeCapacity(int newCapacity)
        {
            T[] newStack = new T[newCapacity];
            if (newCapacity>stack.Length)
            {
                for (int i = 0; i < stack.Length; i++)
                {
                    newStack[i] = stack[i];
                }
            }
            else
            {
                for (int i = 0; i < newCapacity; i++)
                {
                    newStack[i] = stack[i];
                }
            }
            stack = newStack;
        }
    }
}
