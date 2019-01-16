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
using System.Linq;
using System.Collections.Generic;

namespace CSFundamentalAlgorithms.BinaryHeaps
{
    /// <summary>
    /// Implements the main operations on a Min Binary Heap
    /// </summary>
    public class MinBinaryHeap
    {
        /// <summary>
        /// Removes the min element from the heap
        /// </summary>
        /// <param name="min">If the operation is successful, contains the minimum element in the array.</param>
        /// <returns>True in case of success, and false otherwise</returns>
        public static bool TryRemoveMin(List<int> heapArray, out int min)
        {
            min = Int32.MinValue;

            /* If array is empty, returns false. */
            if (!heapArray.Any())
            {
                return false;
            }

            /* If array has only one element left, it is the minimum value, and clear the array after removing it.*/
            if (heapArray.Count == 1)
            {
                min = heapArray[0];
                heapArray.Clear(); ;
                return true;
            }

            /* If array has more than 1 element, the next instructions are exeuted. */
            min = heapArray[0]; /* In a minHeap the minimum value is always in the root, which is at index 0.*/
            heapArray[0] = heapArray[heapArray.Count - 1]; /* Move the last element to the place of root, and then bubble down. */
            heapArray.RemoveAt(heapArray.Count - 1); /* Removing the last element, as it is now placed in the root's position, and needs to be bubbled down.*/
            MinHeapify_Recursive(0, heapArray); /* Call this method to bubble down the (new) root.*/
            return true;
        }

        /// <summary>
        /// Inserts a new value into the heap. 
        /// </summary>
        /// <param name="newValue">Specifies the new value to be inserted in the tree.</param>
        /// <param name="heapArray">Specifies the heap represented in an array. </param>
        public static void Insert(int newValue, List<int> heapArray)
        {
            /* Add the new value to the end of the array. List is a dynamic array and grows in size automatically. */
            heapArray.Add(newValue);

            /* Bubble up the new value, and stop when the parent is no longer bigger than the new value, or when new value is bubbled up to the root's position. */
            int nodeIndex = heapArray.Count - 1;
            int parentIndex = GetParentIndex(nodeIndex);
            while (nodeIndex != 0 && heapArray[parentIndex] > heapArray[nodeIndex])
            {
                Swap(heapArray, nodeIndex, parentIndex);
                nodeIndex = parentIndex;
                parentIndex = GetParentIndex(nodeIndex);
            }
        }

        /// <summary>
        /// Recursively MinHeapifies (bubbles down/trickles down) the given rootIndex.
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the node for which bubble down starts. </param>
        /// <param name="heapArray">Specifies the heap represented in an array.</param>
        private static void MinHeapify_Recursive(int rootIndex, List<int> heapArray)
        {
            int leftChildIndex = GetLeftChildIndexInHeapArray(rootIndex);
            int rightChildIndex = GetRightChildIndexInHeapArray(rootIndex);
            int minElementIndex = rootIndex;

            /* Find the minimum value's index (among 3 values: root, and its left and right children). */
            if (TryFindMinIndex(heapArray, leftChildIndex, rightChildIndex, heapArray[minElementIndex], out int minIndex))
            {
                minElementIndex = minIndex;
            }

            /* If root is not the minimum value, then bubble down the root via the smallest child. */
            if (minElementIndex != rootIndex)
            {
                Swap(heapArray, minElementIndex, rootIndex);
                /* At this point, the value that was at rootIndex, is now at index: minElementIndex, and the bubble down shall continue. */
                if (GetLeftChildIndexInHeapArray(minElementIndex) < heapArray.Count) /* To avoid unnecessary recursion : notice that there is no need to check for the right child's index, as if left child index already is out of range so is right child index, since right child index = left child index +1. */
                {
                    MinHeapify_Recursive(minElementIndex, heapArray);
                }
            }
        }

        /// <summary>
        /// Is the iterative version of MinHeapify_Recursive method. 
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the node for which bubble down starts. </param>
        /// <param name="heapArray">Specifies the heap represented in an array.</param>
        public static void MinHeapify_Iterative(int rootIndex, List<int> heapArray)
        {
            while (GetLeftChildIndexInHeapArray(rootIndex) < heapArray.Count)
            {
                int leftChildIndex = GetLeftChildIndexInHeapArray(rootIndex);
                int rightChildIndex = GetRightChildIndexInHeapArray(rootIndex);
                int minElementIndex = rootIndex;

                if (TryFindMinIndex(heapArray, leftChildIndex, rightChildIndex, heapArray[minElementIndex], out int minIndex))
                {
                    minElementIndex = minIndex;
                }

                if (rootIndex != minElementIndex)
                {
                    Swap(heapArray, minElementIndex, rootIndex);
                    rootIndex = minElementIndex;
                }
                else
                {
                    /* Continue with the index of the smallest child. */
                    if (TryFindMinIndex(heapArray, leftChildIndex, rightChildIndex, Int32.MaxValue, out int minChildIndex))
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


        /// <summary>
        /// Builds an in-place min heap on the given array. 
        /// </summary>
        /// <param name="heapArray">Specifies the array that we be shuffled to be a min heap. </param>
        public static void BuildMinHeap_Recursive(List<int> heapArray)
        {
            for (int i = heapArray.Count / 2; i >= 0; i--) /* Why to start from half of the array? for bigger elements, left and right children will be out of range, due to the formula by which left and right children are found. */
            {
                MinHeapify_Recursive(i, heapArray);
            }
        }

        /// <summary>
        /// Is the iterative version of BuildMinHeap_Recursive. Expect to see exact same results for these two methods. 
        /// </summary>
        /// <param name="heapArray">Specifies the array that we be shuffled to be a min heap. </param>
        public static void BuildMinHeap_Iterative(List<int> heapArray)
        {
            for (int i = heapArray.Count / 2; i >= 0; i--)
            {
                MinHeapify_Iterative(i, heapArray);
            }
        }
        /// <summary>
        /// Given a node index in the heapArray, returns the expected index of its left child. 
        /// </summary>
        /// <param name="index"> The index of the node for which, left child index shall be found. </param>
        /// <returns>The index of the left child. </returns>
        public static int GetLeftChildIndexInHeapArray(int index)
        {
            return 2 * index + 1;
        }

        /// <summary>
        /// Given a node index in the heapArray, returns the expected index of its right child. 
        /// </summary>
        /// <param name="index"> The index of the node for which, right child index shall be found. </param>
        /// <returns>The index of the right child.</returns>
        public static int GetRightChildIndexInHeapArray(int index)
        {
            return 2 * index + 2;
        }

        /// <summary>
        /// Given a node index in the heapArray, returns the expected index of its parent. 
        /// </summary>
        /// <param name="index">The index of the node, for which parent index shall be found. </param>
        /// <returns>The index of the parent. </returns>
        public static int GetParentIndex(int index)
        {
            double parentIndex = (index - 1) / 2;
            return Convert.ToInt32(Math.Floor(parentIndex));
        }

        /// <summary>
        /// Swaps the values at the two given indexes. 
        /// </summary>
        /// <param name="heapArray">Specifies the heap represented in an array.</param>
        /// <param name="index1">Speficies the index of the first element. </param>
        /// <param name="index2">Specifies the index of the second element. </param>
        public static void Swap(List<int> heapArray, int index1, int index2)
        {
            int temp = heapArray[index1];
            heapArray[index1] = heapArray[index2];
            heapArray[index2] = temp;
        }

        /// <summary>
        /// Finds the minimum element in the array, among the given indexes, with respect to minValueReference, and returns the index of the min value. 
        /// </summary>
        /// <returns></returns>
        public static bool TryFindMinIndex(List<int> array, int index1, int index2, int minValueReference, out int minValueIndex)
        {
            minValueIndex = Int32.MinValue;

            /* Expects the given minValueReference value to be an item in the array.  */
            if (!array.Contains(minValueReference))
            {
                return false;
            }

            /* If both of the indexes exceed the range of the array, return false, and leave minValueReference as it was */
            if (index1 > array.Count && index2 > array.Count)
            {
                return false;
            }

            /* If the value at index1 is smaller than the minValueReference, update. */
            if (index1 < array.Count && array[index1] < minValueReference)
            {
                minValueReference = array[index1];
                minValueIndex = index1;
            }

            /* If the value at index2 is smaller than the minValueReference, update. */
            if (index2 < array.Count && array[index2] < minValueReference)
            {
                minValueReference = array[index2];
                minValueIndex = index2;
            }

            /* If the minValueReference is smallest, nothing changes. */
            if (minValueIndex == Int32.MinValue)
            {
                return false; /* meaning none of the elements in the index1 and index2, were smaller than the reference value. */
            }

            return true;
        }
    }
}
