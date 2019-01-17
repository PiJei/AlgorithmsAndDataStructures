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

using System;
using System.Collections.Generic;
using System.Linq;

/* Similar to MinBinaryHeap. Refer to that class for missing explanations. */

namespace CSFundamentalAlgorithms.BinaryHeaps
{
    /// <summary>
    /// Implements a Max Binary Heap, and its main operations.
    /// </summary>
    public class MaxBinaryHeap : BinaryHeapBase
    {
        public MaxBinaryHeap(List<int> array) : base(array)
        {

        }

        /// <summary>
        /// Builds an in-place max heap on the given array. 
        /// </summary>
        public override void BuildHeap_Recursively()
        {
            for (int i = HeapArray.Count / 2; i >= 0; i--)
            {
                BubbleDown_Recursively(i);
            }
        }

        /// <summary>
        /// Is the iterative version of BuildHeap_Recursively. Expect to see exact same results for these two methods. 
        /// </summary>
        public override void BuildHeap_Iteratively()
        {
            for (int i = HeapArray.Count / 2; i >= 0; i--)
            {
                BubbleDown_Iteratively(i);
            }
        }

        /// <summary>
        /// Inserts a new value into the Max Heap. 
        /// </summary>
        /// <param name="newValue">Specifies the new value to be inserted in the tree.</param>
        public override void Insert(int value)
        {
            HeapArray.Add(value);

            // Bubble up this element
            int nodeIndex = HeapArray.Count - 1;
            BubbleUp_Iteratively(nodeIndex);
        }

        public override void BubbleUp_Iteratively(int index)
        {
            int parentIndex = GetParentIndex(index);

            if (parentIndex < 0 || parentIndex >= HeapArray.Count) /* Checks for corner cases. */
            {
                return;
            }

            while (index != 0 && HeapArray[parentIndex] < HeapArray[index])
            {
                Swap(HeapArray, parentIndex, index);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        /// <summary>
        /// Removes the max element from the heap.
        /// </summary>
        /// <param name="rootValue">If the operation is successful, contains the maximum element in the array.</param>
        /// <returns>True in case of success, and false otherwise</returns>
        public override bool TryRemoveRoot(out int rootValue)
        {
            rootValue = Int32.MaxValue;

            if (!HeapArray.Any())
            {
                return false;
            }
            if (HeapArray.Count == 1)
            {
                rootValue = HeapArray[0];
                HeapArray.Clear();
                return true;
            }

            rootValue = HeapArray[0];
            HeapArray[0] = HeapArray[HeapArray.Count - 1];
            HeapArray.RemoveAt(HeapArray.Count - 1);
            BubbleDown_Recursively(0);

            return true;
        }

        public override bool TryFindRoot(out int rootValue)
        {
            if (HeapArray.Any())
            {
                rootValue = HeapArray[0];
                return true;
            }
            rootValue = int.MinValue;
            return false;
        }

        public override void BubbleDown_Recursively(int rootIndex)
        {
            int leftChildIndex = GetLeftChildIndexInHeapArray(rootIndex);
            int rightChildIndex = GetRightChildIndexInHeapArray(rootIndex);
            int maxElementIndex = rootIndex;

            if (TryFindMaxIndex(HeapArray, new List<int> { leftChildIndex, rightChildIndex }, HeapArray[maxElementIndex], out int maxIndex))
            {
                maxElementIndex = maxIndex;
            }

            if (maxElementIndex != rootIndex)
            {
                Swap(HeapArray, maxElementIndex, rootIndex);

                if (GetLeftChildIndexInHeapArray(maxElementIndex) < HeapArray.Count)
                {
                    BubbleDown_Recursively(maxElementIndex);
                }
            }
        }

        public override void BubbleDown_Iteratively(int rootIndex)
        {
            while (GetLeftChildIndexInHeapArray(rootIndex) < HeapArray.Count)
            {
                int leftChildIndex = GetLeftChildIndexInHeapArray(rootIndex);
                int rightChildIndex = GetRightChildIndexInHeapArray(rootIndex);
                int maxElementIndex = rootIndex;

                if (TryFindMaxIndex(HeapArray, new List<int> { leftChildIndex, rightChildIndex }, HeapArray[rootIndex], out int maxIndex))
                {
                    maxElementIndex = maxIndex;
                }

                if (maxElementIndex != rootIndex)
                {
                    Swap(HeapArray, maxElementIndex, rootIndex);
                    BubbleDown_Iteratively(maxElementIndex);
                }
                else
                {
                    if (TryFindMaxIndex(HeapArray, new List<int> { leftChildIndex, rightChildIndex }, Int32.MinValue, out int maxChildIndex))
                    {
                        BubbleDown_Iteratively(maxChildIndex);
                    }
                    else
                    {
                        break; // This branch of the code is not expected to be executed.
                    }
                }
            }
        }
    }
}
