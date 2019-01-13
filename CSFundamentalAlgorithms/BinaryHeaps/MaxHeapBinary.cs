/* 
 * Copyright (c) 2019 (PiJei)
 * 
 * This file is part of CSFundamentalAlgorithms project.
 *
 * CSFundamentalAlgorithms is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * CSFundamentalAlgorithms is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System;
using System.Linq;

/* Similar to MinHeapBinary. Refer to that class for explanations. */

namespace CSFundamentalAlgorithms.BinaryHeaps
{
    public class MaxHeapBinary
    {
        public static void Insert(int value, List<int> heapArray)
        {
            heapArray.Add(value);

            // Bubble up this element
            int nodeIndex = heapArray.Count - 1;
            int parentIndex = GetParentIndex(nodeIndex);
            while (nodeIndex != 0 && heapArray[parentIndex] < heapArray[nodeIndex])
            {
                Swap(heapArray, parentIndex, nodeIndex);
                nodeIndex = parentIndex;
            }
        }

        public static bool TryRemoveMax(List<int> heapArray, out int maxValue)
        {
            maxValue = Int32.MaxValue;

            if (!heapArray.Any())
            {
                return false;
            }
            if (heapArray.Count == 1)
            {
                maxValue = heapArray[0];
                heapArray.Clear();
                return true;
            }

            maxValue = heapArray[0];
            heapArray[0] = heapArray[heapArray.Count - 1];
            heapArray.RemoveAt(heapArray.Count - 1);
            MaxHeapify_Recursive(0, heapArray);

            return true;

        }

        public static void MaxHeapify_Recursive(int rootIndex, List<int> heapArray)
        {
            int leftChildIndex = GetLeftChildIndex(rootIndex);
            int rightChildIndex = GetRightChildIndex(rootIndex);
            int maxElementIndex = rootIndex;

            if (leftChildIndex < heapArray.Count && heapArray[leftChildIndex] > heapArray[maxElementIndex])
            {
                maxElementIndex = leftChildIndex;
            }
            if (rightChildIndex < heapArray.Count && heapArray[rightChildIndex] > heapArray[maxElementIndex])
            {
                maxElementIndex = rightChildIndex;
            }

            if (maxElementIndex != rootIndex)
            {
                Swap(heapArray, maxElementIndex, rootIndex);
                MaxHeapify_Recursive(maxElementIndex, heapArray);
            }
        }

        public static void BuildMaxHeap_Recursive(List<int> heapArray)
        {
            for (int i = heapArray.Count / 2 + 1; i >= 0; i--)
            {
                MaxHeapify_Recursive(i, heapArray);
            }
        }

        public static int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        public static int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        public static int GetParentIndex(int index)
        {
            double parentindex = (index - 1) / 2;
            return Convert.ToInt32(Math.Floor(parentindex));
        }

        public static void Swap(List<int> array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
