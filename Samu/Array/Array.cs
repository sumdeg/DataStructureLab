using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.Array
{
    public class Array
    {
        protected object[] InnerList { get; private set; }
        public int Count => InnerList.Length;
        public int Capacity => InnerList.Length;
        public void DisplayArray()
        {
            Console.WriteLine();
            foreach (var item in InnerList)
            {
                Console.WriteLine($"{item,5}");
            }
        }
        public Array(params object[] X)
        {
            InnerList = new object[X.Length];
            System.Array.Copy(X, InnerList, X.Length);
        }
       

    }
}
