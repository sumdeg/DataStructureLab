using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samu.SortingAlgorithms
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] array) where T:IComparable
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                int minIndex = i;
                T minValue = array[minIndex];
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue)<0)
                    {
                        minIndex = j;
                        minValue = array[minIndex];
                    }
                }
                Swap(array, i, minIndex);
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
