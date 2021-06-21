using System;

namespace QueueApp
{
    class Program
    {
        static void Main(string[] args)
        {
        

            LinkedListQueue<int> queue = new LinkedListQueue<int>();
            queue.EnQueue(10);
            queue.EnQueue(20);
            queue.EnQueue(30);
            queue.EnQueue(40);
            queue.DeQueue();


            Console.ReadKey();
        }
    }
}
