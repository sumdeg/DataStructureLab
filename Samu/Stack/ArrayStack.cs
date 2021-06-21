using System;
using System.Collections.Generic;
using System.Text;

namespace Samu.Stack
{
    public class ArrayStack<T>
    {
        private T[] stack;
        private int index;
        public ArrayStack(int capacity = 2)
        {
            stack = new T[capacity];
            index = 0;
        }
        public void Push(T data)
        {
            if (stack.Length==index)
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
            if (index==0)
            {
                return default(T);
            }
            else
            {
                node = stack[index - 1];
                index--;
                return node;
            }
        }
        private void ResizeCapacity(int newCapacity)
        {
            T[] newStack = new T[newCapacity];
            if (newCapacity > stack.Length)
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
