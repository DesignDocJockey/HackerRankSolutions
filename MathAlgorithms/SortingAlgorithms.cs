using System;
using System.Collections.Generic;
using System.Text;

namespace MathAlgorithms
{
    public class SortingAlgorithms
    {
        public IEnumerable<int> BubbleSort(int[] array)
        {
            bool swapOccurred = false;
            do
            {
                swapOccurred = false;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i+1);
                        swapOccurred = true;
                    }
                }
            } while (swapOccurred);

            return array;
        }

        private static void Swap(int[] array, int swapToIndex, int swapFromIndex)
        {
            var temp = array[swapToIndex];
            array[swapToIndex] = array[swapFromIndex];
            array[swapFromIndex + 1] = temp;
        }
    }
}
