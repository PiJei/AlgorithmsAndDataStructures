#region copyright
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
#endregion
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.DataStructures.BinaryHeaps.API
{
    /// <summary>
    /// Is a base class for Binary heap. 
    /// </summary>
    /// <typeparam name="TKey">The type of the keys stored in the heap. </typeparam>
    /// <typeparam name="TValue">The type of the values stored in the heap. </typeparam>
    public abstract class BinaryHeapBase<TKey, TValue> : IBinaryHeap<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Note that passing the array size is not a must, as the class itself contains the array and has access to its size. However some algorithms such as HeapSort which rely on a heap to perform sorting, are better implemented, if we have the length of the array passed to these methods. 
        /// </summary>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public abstract void BuildHeap_Iteratively(int heapArrayLength);

        /// <summary>
        /// Builds a heap using recursion, and does so in situ.
        /// </summary>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public abstract void BuildHeap_Recursively(int heapArrayLength);

        /// <summary>
        /// Inserts a new value into heap.
        /// </summary>
        /// <param name="keyValue">The key-value to be inserted into the heap.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public abstract void Insert(KeyValuePair<TKey, TValue> keyValue, int heapArrayLength);

        /// <summary>
        /// Removes the root of the heap. In a MinHeap and MinMaxHeap this is the min, and in a MaxHeap and MaxMinHeap this is the max. 
        /// </summary>
        /// <param name="keyValue">The key-value of the root.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        /// <returns>True in case of success, and false otherwise.</returns>
        public abstract bool TryRemoveRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength);

        /// <summary>
        /// Finds the root of the heap, without removing it. 
        /// </summary>
        /// <param name="keyValue">The key-value of the root.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        /// <returns>True in case of success, and false in case of failure.</returns>
        public abstract bool TryFindRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength);

        /// <summary>
        /// Implements the bubble down/trickle down operation using recursion.
        /// </summary>
        /// <param name="rootIndex">The index of the root element, the element for which the trickle down should be performed.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public abstract void BubbleDown_Recursively(int rootIndex, int heapArrayLength);

        /// <summary>
        /// Implements the bubble down/trickle down operation using iteration.
        /// </summary>
        /// <param name="rootIndex">The index of the root element, the element for which the trickle down should be performed.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public abstract void BubbleDown_Iteratively(int rootIndex, int heapArrayLength);

        /// <summary>
        /// Moves the value in the given index, up in the heap till its position is found. The position is defined such to respect heap ordering property.
        /// </summary>
        /// <param name="index">The index of the element that should be bubbled up.</param>
        /// <param name="heapArrayLength">The length/size of the heap array. </param>
        public abstract void BubbleUp_Iteratively(int index, int heapArrayLength);

        /// <summary>
        /// Is the array used to implement binary heap. 
        /// </summary>
        public List<KeyValuePair<TKey, TValue>> HeapArray;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">The array containing all the key-values to be converted to a heap. </param>
        public BinaryHeapBase(List<KeyValuePair<TKey, TValue>> array)
        {
            HeapArray = array;
        }

        /// <summary>
        /// Given a node index in the heapArray, returns the expected index of its left child. 
        /// </summary>
        /// <param name="index"> The index of the node for which, left child index shall be found. </param>
        /// <returns>The index of the left child. </returns>
        public int GetLeftChildIndexInHeapArray(int index)
        {
            return 2 * index + 1;
        }

        /// <summary>
        /// Given a node index in the heapArray, returns the expected index of its right child. 
        /// </summary>
        /// <param name="index"> The index of the node for which, right child index shall be found. </param>
        /// <returns>The index of the right child.</returns>
        public int GetRightChildIndexInHeapArray(int index)
        {
            return 2 * index + 2;
        }

        /// <summary>
        /// Given a node index in the heapArray, returns the expected index of its parent. 
        /// </summary>
        /// <param name="index">The index of the node, for which parent index shall be found. </param>
        /// <returns>The index of the parent. </returns>
        public int GetParentIndex(int index)
        {
            double parentIndex = (index - 1) / 2;
            return Convert.ToInt32(Math.Floor(parentIndex));
        }

        /// <summary>
        /// Returns the level of a node in the heap, given the node's index in the heap array.
        /// </summary>
        /// <param name="index">The index of a node in an array. </param>
        /// <returns>Returns the level of the node. </returns>
        public int GetNodeLevel(int index)
        {
            double level = Math.Floor(Math.Log(index + 1, 2));
            return Convert.ToInt32(level);
        }

        /// <summary>
        /// Finds the minimum element in the array, among the given indexes, with respect to minValueReference, and returns the index of the min value. 
        /// </summary>
        /// <param name="list">The list of values. </param>
        /// <param name="indexes">The list of indexes among which we want to find the minimum value. </param>
        /// <param name="minKeyReference">The reference for the minimum value.  </param>
        /// <param name="minKeyIndex">The index of the minimum value among the specifies indexes. </param>
        /// <returns>True in case of success, and false in case of failure. </returns>
        public bool TryFindIndexOfMinSmallerThanReference(List<KeyValuePair<TKey, TValue>> list, List<int> indexes, TKey minKeyReference, out int minKeyIndex)
        {
            minKeyIndex = int.MinValue;

            /* If all of the indexes exceed the range of the array, return false, and leave minValueReference as it was */
            if (indexes.All(index => index >= list.Count || index < 0))
            {
                return false;
            }

            /* Find the minimum value.*/
            foreach (int index in indexes.Where(index => index < list.Count && index >= 0 && list[index].Key.CompareTo(minKeyReference) < 0))
            {
                minKeyReference = list[index].Key;
                minKeyIndex = index;
            }

            /* In the case that minValueReference is smallest, nothing changes, and minValueIndex remains as initiated at the beginning of the method. */
            if (minKeyIndex == int.MinValue)
            {
                return false; /* meaning none of the elements in the given indexes, were smaller than the reference value. */
            }

            return true;
        }

        /// <summary>
        /// Finds the maximum element in the array, among the given indexes, with respect to maxValueReference, and returns the index of the max value. 
        /// </summary>
        /// <param name="list">The list of values. </param>
        /// <param name="listLength">The length of values array, which based on the usage, might be less than values.Count. For example when called via Heap-Sort. </param>
        /// <param name="indexes">The list of indexes among which we want to find the maximum value. </param>
        /// <param name="maxKeyReference">The reference for the maximum value.  </param>
        /// <param name="maxKeyIndex">The index of the maximum value among the specifies indexes. </param>
        /// <returns>True in case of success, and false in case of failure. </returns>
        public bool TryFindIndexOfMaxBiggerThanReference(List<KeyValuePair<TKey, TValue>> list, int listLength, List<int> indexes, TKey maxKeyReference, out int maxKeyIndex)
        {
            maxKeyIndex = int.MaxValue;

            /* If all of the indexes exceed the range of the array, return false, and leave maxValueReference as it was */
            if (indexes.All(index => index >= listLength))
            {
                return false;
            }

            /* Find the minimum value.*/
            foreach (int index in indexes.Where(index => index < listLength && list[index].Key.CompareTo(maxKeyReference) > 0))
            {
                maxKeyReference = list[index].Key;
                maxKeyIndex = index;
            }

            /* In the case that maxValueReference is biggest, nothing changes, and maxValueIndex remains as initiated at the beginning of the method. */
            if (maxKeyIndex == int.MaxValue)
            {
                return false; /* meaning none of the elements in the given indexes, were bigger than the reference value. */
            }

            return true;
        }

        /// <summary>
        /// Find the index of a key in the heap array. 
        /// </summary>
        /// <param name="key">A key for which the index in the array must be found. </param>
        /// <returns>The array index of the <paramref name="key"/> if it exists and -1 otherwise. </returns>
        public int FindIndex(TKey key)
        {
            for (int i = 0; i < HeapArray.Count; i++)
            {
                if (HeapArray[i].Key.Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
