using System;
using System.Collections;
using System.Collections.Generic;

namespace TreeApp
{
    public class BST<T> where T:IComparable
    {
        public Node<T> Root { get; set; }
        public BST()
        {

        }
        public BST(Node<T> root)
        {
            Root = root;
        }
        public void Add(T item)
        {
            var newNode = new Node<T>(item);
            if (Root==null)
            {
                Root = newNode;                
            }
            else
            {
                var current = Root;
                var parent = new Node<T>();
                
                while (true)
                {
                    parent = current;
                    //Sol alt
                    if (item.CompareTo(current.Item)<0)
                    {
                        current = current.Left;
                        if (current==null)
                        {
                            parent.Left = newNode;
                            break;
                        }

                    }
                    //Sağ alt
                    else
                    {
                        current = current.Right;
                        if (current==null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }
        public static void InOrder(Node<T> root)
        {
            if (root!=null)
            {
                InOrder(root.Left);
                root.Display();
                InOrder(root.Right);
            }
        }
        public static void PreOrder(Node<T> root)
        {
            if (root!=null)
            {
                root.Display();
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }
        public static void PostOrder(Node<T> root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                root.Display();
            }
        }

        public T FindMin(Node<T> root)
        {
            var current = root;
            while (current.Left!=null)
            {
                current = current.Left;

            }
            return current.Item;
        }
        public T FindMax()
        {
            Node<T> current = Root;
            while (current.Right!=null)
            {
                current = current.Right;
            }
            return current.Item;
        }
        public T FindMax(Node<T> root)
        {
            if (root == null)
                return default(T);
            T max = default(T);

            var q = new Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                var temp = q.Dequeue();
                if (temp.Item.CompareTo(max) > 0)
                    max = temp.Item;

                if (temp.Item!=null)
                {
                    if (temp.Left!=null)
                    {
                        q.Enqueue(temp.Left);
                    }
                    if (temp.Right!=null)
                    {
                        q.Enqueue(temp.Right);
                    }
                }
            }
            return max;
        }
        public Node<T> DeepestNodeinTree(Node<T> root)
        {
            Node<T> temp = null;
            if (root == null)
                return null;

            var q = new Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                temp = q.Dequeue();
                if (temp.Left!=null)
                {
                    q.Enqueue(temp.Left);
                }
                if (temp.Right!=null)
                {
                    q.Enqueue(temp.Right);
                }
            }
            return temp;
        }
        public Node<T> Remove(Node<T> root,T item)
        {
            if (root==null)
            {
                return null;
            }
            //Recursive ilerleme
            if (item.CompareTo(root.Item)<0)
            {
                root.Left = Remove(root.Left, item);
            }
            else if (item.CompareTo(root.Item) > 0)
            {
                root.Right = Remove(root.Right, item);
            }
            else
            {
                //Tek çocuklu ya da çocuksuz
                if (root.Left==null)
                {
                    return root.Right;
                }
                else if (root.Right==null)
                {
                    return root.Left;
                }
                //İki çocuğu var ise
                root.Item = FindMin(root.Right);
                //InOrder dolaşma
                root.Right = Remove(root.Right, root.Item);
            }
            return root;
        }
        public static List<T> LevelOrder(Node<T> root)
        {
               var list = new List<T>();
               var queue = new Queue<Node<T>>();
               queue.Enqueue(root);
               while (queue.Count>0)
               {
                   var node = queue.Dequeue();
                   list.Add(node.Item);
                   if (node.Left!=null)
                   {
                       queue.Enqueue(node.Left);                  
                   }
                   if (node.Right!=null)
                   {
                       queue.Enqueue(node.Right);         
                   }
                   
               }
              return list;
        }      
        public static int MaxDepth(Node<T> root)
        {
            if (root==null)
            {
                return 0;
            }
            int leftDepth = MaxDepth(root.Left);
            int rigthDepth = MaxDepth(root.Right);
            return (leftDepth > rigthDepth) ? leftDepth + 1 : rigthDepth + 1;
        }
        public int NumberOfLeavesinBST(Node<T> root)
        {
            int count = 0;
            if (root == null)
                return 0;

            var q = new Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                Node<T> temp = q.Dequeue();
                if (temp.Left == null && temp.Right == null)
                    count++;
                if (temp.Left!=null)
                {
                    q.Enqueue(temp.Left);
                }
                if (temp.Right!=null)
                {
                    q.Enqueue(temp.Right);
                }
            }
            return count;
        } 
        public int NumberOfFullNodes(Node<T> root)
        {
            int count = 0;
            if (root == null)
                return count;

            var q = new Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                Node<T> temp = q.Dequeue();
                if (temp.Left != null && temp.Right != null)
                    count++;
                if (temp.Left!=null)
                {
                    q.Enqueue(temp.Left);
                }
                if (temp.Right!=null)
                {
                    q.Enqueue(temp.Right);
                }
            }
            return count;
        }
        public int NumberOfHalfNodes(Node<T> root)
        {
            int count = 0;
            if (root == null)
                return count;
            var q = new Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                Node<T> temp = q.Dequeue();
                if ((temp.Left != null && temp.Right == null) || (temp.Left == null && temp.Right != null))
                    count++;
                if (temp.Left!=null)
                    q.Enqueue(temp.Left);                
                if (temp.Right!=null)
                    q.Enqueue(temp.Right);
            }
            return count;
        }
        public int WidthofTree(Node<T> root)
        {
            int max = 0;
            int height = MaxDepth(root);
            for (int k = 0; k <= height; k++)
            {
                int temp = WidthofTree(root, k);
                if (temp > max)
                    max=temp;
            }
            return max;
        }
        private int WidthofTree(Node<T> root, int depth)
        {
            if (root == null)
                return 0;
            else
                if (depth == 0)
                return 1;
            else
                return WidthofTree(root.Left, depth - 1) + WidthofTree(root.Right, depth - 1);

        }

        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }
        private void PrintPaths(Node<T> root,T[] path,int pathLen)
        {
            if (root == null) return;
            path[pathLen] = root.Item;
            pathLen++;
            if (root.Left==null && root.Right==null)
            {
                PrintArray(path, pathLen);
            }
            else
            {
                PrintPaths(root.Left, path, pathLen);
                PrintPaths(root.Right, path, pathLen);
            }

        }
        private void PrintArray(T[] path,int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{path[i]} ");
            }
            Console.WriteLine();
        }

        public static void FindAncestors(Node<T> root,T item)
        {
            var stack = new Stack<Node<T>>();
            while (true)
            {
                while (root!=null && root.Item.CompareTo(item)!=0)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                if (root != null && root.Item.CompareTo(item) == 0)
                {
                    break;
                }
                if (stack.Peek().Right==null)
                {
                    root = stack.Peek();
                    stack.Pop();
                }
                while (stack.Count>0 && stack.Peek().Right==root)
                {
                    root = stack.Peek();
                    stack.Pop();
                }
                root = stack.Count == 0 ? null : stack.Peek().Right;
                    
            }
            while (stack.Count>0)
            {
                stack.Peek().Display();
                stack.Pop();
            }
           
        }

    }
}
