using System;

namespace StackApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* var stack = new ArrayStack<int>();
             stack.Push(1);
             stack.Push(2);
             stack.Push(3);
             stack.Push(4);       
             Console.WriteLine(stack.Pop());  */

            var stack = new LinkedListStack<int>();
            stack.Push(2);
            stack.Push(5);
            stack.Push(8);
            stack.Push(10);
            Console.WriteLine(stack.Pop());
            Console.ReadKey();
        }
    }
}
