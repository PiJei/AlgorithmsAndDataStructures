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
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using CSFundamentals.Algorithms.Sort;
using CSFundamentals.DataStructures.BinaryHeaps.API;
using CSFundamentals.Styling;

namespace CSFundamentals.DataStructures.BinaryHeaps
{
    /// <summary>
    /// Implements a Min Binary Heap, and its main operations.
    /// </summary>
    [DataStructure("MinBinaryHeap")]
    public class MinBinaryHeap<T> : BinaryHeapBase<T> where T : IComparable<T>
    {
        public MinBinaryHeap(List<T> array) : base(array)
        {

        }

        /// <summary>
        /// Builds an in-place min heap on the given array. 
        /// </summary>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        public override void BuildHeap_Recursively(int heapArrayLength)
        {
            for (int i = heapArrayLength / 2; i >= 0; i--) /* Why to start from half of the array? for bigger elements, left and right children will be out of range, due to the formula by which left and right children are found. */
            {
                BubbleDown_Recursively(i, heapArrayLength);
            }
        }

        /// <summary>
        /// Is the iterative version of BuildMinHeap_Recursive. Expect to see exact same results for these two methods. 
        /// </summary>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        public override void BuildHeap_Iteratively(int heapArrayLength)
        {
            for (int i = heapArrayLength / 2; i >= 0; i--)
            {
                BubbleDown_Iteratively(i, heapArrayLength);
            }
        }

        /// <summary>
        /// Inserts a new value into the Min Heap. 
        /// </summary>
        /// <param name="newValue">Specifies the new value to be inserted in the tree.</param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        public override void Insert(T newValue, int heapArrayLength)
        {
            /* Add the new value to the end of the array. List is a dynamic array and grows in size automatically. */
            HeapArray.Add(newValue);

            /* Bubble up the new value, and stop when the parent is no longer bigger than the new value, or when new value is bubbled up to the root's position. */
            int nodeIndex = heapArrayLength;
            BubbleUp_Iteratively(nodeIndex, heapArrayLength + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        public override void BubbleUp_Iteratively(int index, int heapArrayLength)
        {
            int parentIndex = GetParentIndex(index);

            if (parentIndex < 0 || parentIndex >= heapArrayLength) /* Checks for corner cases. */
            {
                return;
            }

            while (index != 0 && HeapArray[parentIndex].CompareTo(HeapArray[index]) > 0)
            {
                Utils.Swap(HeapArray, index, parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        /// <summary>
        /// Removes the min element from the heap.
        /// </summary>
        /// <param name="rootValue">If the operation is successful, contains the minimum element in the array.</param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        /// <returns>True in case of success, and false otherwise</returns>
        public override bool TryRemoveRoot(out T rootValue, int heapArrayLength)
        {
            rootValue = (T)typeof(T).GetField("MinValue").GetValue(null); // T.MinValue;

            /* If array is empty, returns false. */
            if (heapArrayLength == 0)
            {
                return false;
            }

            /* If array has only one element left, it is the minimum value, and clear the array after removing it.*/
            if (heapArrayLength == 1)
            {
                rootValue = HeapArray[0];
                HeapArray.Clear(); ;
                return true;
            }

            /* If array has more than 1 element, the next instructions are executed. */
            rootValue = HeapArray[0]; /* In a minHeap the minimum value is always in the root, which is at index 0.*/
            HeapArray[0] = HeapArray[heapArrayLength - 1]; /* Move the last element to the place of root, and then bubble down. */
            HeapArray.RemoveAt(heapArrayLength - 1); /* Removing the last element, as it is now placed in the root's position, and needs to be bubbled down.*/
            BubbleDown_Recursively(0, heapArrayLength - 1); /* Call this method to bubble down the (new) root.*/ /* Also notice that the array is shorter by one value now, thus the new array length is one smaller. */
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootValue"></param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        /// <returns></returns>
        public override bool TryFindRoot(out T rootValue, int heapArrayLength)
        {
            if (HeapArray.Any())
            {
                rootValue = HeapArray[0];
                return true;
            }
            rootValue = (T)typeof(T).GetField("MaxValue").GetValue(null);
            return false;
        }


        /// <summary>
        /// Recursively MinHeapifies (bubbles down/trickles down) the given rootIndex.
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the node for which bubble down starts. </param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        public override void BubbleDown_Recursively(int rootIndex, int heapArrayLength)
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
                Utils.Swap(HeapArray, minElementIndex, rootIndex);

                /* At this point, the value that was at rootIndex, is now at index minElementIndex, and the bubble/trickle down shall continue. */
                if (GetLeftChildIndexInHeapArray(minElementIndex) < heapArrayLength) /* To avoid unnecessary recursion : notice that there is no need to check for the right child's index, as if left child index already is out of range so is right child index, since right child index = left child index +1. */
                {
                    BubbleDown_Recursively(minElementIndex, heapArrayLength);
                }
            }
        }

        /// <summary>
        /// Is the iterative version of MinHeapify_Recursive method. 
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the node for which bubble down starts. </param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        public override void BubbleDown_Iteratively(int rootIndex, int heapArrayLength)
        {
            while (GetLeftChildIndexInHeapArray(rootIndex) < heapArrayLength)
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
                    Utils.Swap(HeapArray, minElementIndex, rootIndex);
                    rootIndex = minElementIndex;
                }
                else
                {
                    /* Continue with the index of the smallest child. */
                    if (TryFindMinIndex(HeapArray, new List<int> { leftChildIndex, rightChildIndex }, (T)typeof(T).GetField("MaxValue").GetValue(null), out int minChildIndex))
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
