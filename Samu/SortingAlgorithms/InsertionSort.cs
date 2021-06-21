using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.SortingAlgorithms
{
    public static class InsertionSort
    {
        public static void Sort<T>(T[] array) where T: IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j>0 && array[j].CompareTo(array[j-1])<0)
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }
        private static void Swap<T>(T[] array, int first, int second) where T : IComparable
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
