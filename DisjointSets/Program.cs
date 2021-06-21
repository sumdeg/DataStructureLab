using System;

namespace DisjointSets
{
    class Program
    {
        static void Main(string[] args)
        {
            var ds = new DisJointSet<int>();
            for (int i = 1; i <=6; i++)
            {
                ds.MakeSet(i);
            }

            ds.Union(1, 2);
            ds.Union(2, 3);
            ds.Union(3, 4);
            ds.Union(1, 5);
            ds.Union(5, 6);

            

            Console.ReadKey();
        }
    }
}
