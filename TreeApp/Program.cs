using System;
using System.Collections.Generic;

namespace TreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BST<int>();
            var list = new List<int>() { 1,2,7,3,5,8,9,4,6,10 };
            list.ForEach(a => bst.Add(a));
            BST<int>.FindAncestors(bst.Root, 6);
            
            Console.ReadKey();


        }

        private static void Bst()
        {
            var bst = new BST<int>();
            bst.Add(23);
            bst.Add(12);
            bst.Add(44);
            bst.Add(6);
            bst.Add(16);
            bst.Add(32);
            bst.Add(55);
            //Console.Write("In Order Traversal:");
            //BST<int>.InOrder(bst.Root);
            //Console.WriteLine("\nMax item:{0}",bst.FindMax(bst.Root));
            //Console.WriteLine("Deepest node in tree:{0}", bst.DeepestNodeinTree(bst.Root).Item);
            //Console.WriteLine("Number of leaves in tree:{0}",bst.NumberOfLeavesinBST(bst.Root));
            //Console.WriteLine("Number of full nodes in tree:{0}",bst.NumberOfFullNodes(bst.Root));
            //Console.WriteLine("Number of half nodes in tree:{0}",bst.NumberOfHalfNodes(bst.Root));
            //Console.WriteLine("The width of tree:{0}",bst.WidthofTree(bst.Root));
            bst.PrintPaths(bst.Root);
        }
    }
}
