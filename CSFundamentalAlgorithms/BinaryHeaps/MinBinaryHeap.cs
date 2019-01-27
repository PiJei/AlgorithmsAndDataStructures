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

namespace CSFundamentalAlgorithms.BinaryHeaps
{
    /// <summary>
    /// Implements a Min Binary Heap, and its main operations.
    /// </summary>
    public class MinBinaryHeap : BinaryHeapBase
    {
        public MinBinaryHeap(List<int> array) : base(array)
        {

        }

        /// <summary>
        /// Builds an in-place min heap on the given array. 
        /// </summary>
        public override void BuildHeap_Recursively()
        {
            for (int i = HeapArray.Count / 2; i >= 0; i--) /* Why to start from half of the array? for bigger elements, left and right children will be out of range, due to the formula by which left and right children are found. */
            {
                BubbleDown_Recursively(i);
            }
        }

        /// <summary>
        /// Is the iterative version of BuildMinHeap_Recursive. Expect to see exact same results for these two methods. 
        /// </summary>
        public override void BuildHeap_Iteratively()
        {
            for (int i = HeapArray.Count / 2; i >= 0; i--)
            {
                BubbleDown_Iteratively(i);
            }
        }

        /// <summary>
        /// Inserts a new value into the Min Heap. 
        /// </summary>
        /// <param name="newValue">Specifies the new value to be inserted in the tree.</param>
        public override void Insert(int newValue)
        {
            /* Add the new value to the end of the array. List is a dynamic array and grows in size automatically. */
            HeapArray.Add(newValue);

            /* Bubble up the new value, and stop when the parent is no longer bigger than the new value, or when new value is bubbled up to the root's position. */
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

            while (index != 0 && HeapArray[parentIndex] > HeapArray[index])
            {
                Swap(HeapArray, index, parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        /// <summary>
        /// Removes the min element from the heap.
        /// </summary>
        /// <param name="rootValue">If the operation is successful, contains the minimum element in the array.</param>
        /// <returns>True in case of success, and false otherwise</returns>
        public override bool TryRemoveRoot(out int rootValue)
        {
            rootValue = Int32.MinValue;

            /* If array is empty, returns false. */
            if (!HeapArray.Any())
            {
                return false;
            }

            /* If array has only one element left, it is the minimum value, and clear the array after removing it.*/
            if (HeapArray.Count == 1)
            {
                rootValue = HeapArray[0];
                HeapArray.Clear(); ;
                return true;
            }

            /* If array has more than 1 element, the next instructions are exeuted. */
            rootValue = HeapArray[0]; /* In a minHeap the minimum value is always in the root, which is at index 0.*/
            HeapArray[0] = HeapArray[HeapArray.Count - 1]; /* Move the last element to the place of root, and then bubble down. */
            HeapArray.RemoveAt(HeapArray.Count - 1); /* Removing the last element, as it is now placed in the root's position, and needs to be bubbled down.*/
            BubbleDown_Recursively(0); /* Call this method to bubble down the (new) root.*/
            return true;
        }

        public override bool TryFindRoot(out int rootValue)
        {
            if (HeapArray.Any())
            {
                rootValue = HeapArray[0];
                return true;
            }
            rootValue = int.MaxValue;
            return false;
        }


        /// <summary>
        /// Recursively MinHeapifies (bubbles down/trickles down) the given rootIndex.
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the node for which bubble down starts. </param>
        /// <param name="HeapArray">Specifies the heap represented in an array.</param>
        public override void BubbleDown_Recursively(int rootIndex)
        {
            int leftChildIndex = GetLeftChildIndexInHeapArray(rootIndex);
            int rightChildIndex = GetRightChildIndexInHeapArray(rootIndex);
            int minElementIndex = rootIndex;

            /* Find the minimum value's index (among 3 values: root, and its left and right children). */
            if (TryFindMinIndex(HeapArray, new List<int> { leftChildIndex, rightChildIndex }, HeapArray[minElementIndex], out int minIndex))
            {
                minElementIndex = minIndex;
            }

            /* If root is not the minimum value, then bubble/trickle down the root via the smallest child. */
            if (minElementIndex != rootIndex)
            {
                Swap(HeapArray, minElementIndex, rootIndex);

                /* At this point, the value that was at rootIndex, is now at index minElementIndex, and the bubble/trickle down shall continue. */
                if (GetLeftChildIndexInHeapArray(minElementIndex) < HeapArray.Count) /* To avoid unnecessary recursion : notice that there is no need to check for the right child's index, as if left child index already is out of range so is right child index, since right child index = left child index +1. */
                {
                    BubbleDown_Recursively(minElementIndex);
                }
            }
        }

        /// <summary>
        /// Is the iterative version of MinHeapify_Recursive method. 
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the node for which bubble down starts. </param>
        /// <param name="HeapArray">Specifies the heap represented in an array.</param>
        public override void BubbleDown_Iteratively(int rootIndex)
        {
            while (GetLeftChildIndexInHeapArray(rootIndex) < HeapArray.Count)
            {
                int leftChildIndex = GetLeftChildIndexInHeapArray(rootIndex);
                int rightChildIndex = GetRightChildIndexInHeapArray(rootIndex);
                int minElementIndex = rootIndex;

                if (TryFindMinIndex(HeapArray, new List<int> { leftChildIndex, rightChildIndex }, HeapArray[minElementIndex], out int minIndex))
                {
                    minElementIndex = minIndex;
                }

                if (rootIndex != minElementIndex)
                {
                    Swap(HeapArray, minElementIndex, rootIndex);
                    rootIndex = minElementIndex;
                }
                else
                {
                    /* Continue with the index of the smallest child. */
                    if (TryFindMinIndex(HeapArray, new List<int> { leftChildIndex, rightChildIndex }, Int32.MaxValue, out int minChildIndex))
                    {
                        rootIndex = minChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
