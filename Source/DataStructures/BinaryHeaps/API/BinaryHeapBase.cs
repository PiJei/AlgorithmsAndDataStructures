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
    public abstract class BinaryHeapBase<TKey, TValue> : IBinaryHeap<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Note that passing the array size is not a must, as the class itself contains the array and has access to its size. However some algorithms such as HeapSort which rely on a heap to perform sorting, are better implemented, if we have the length of the array passed to these methods. 
        /// </summary>
        /// <param name="heapArrayLength"></param>
        public abstract void BuildHeap_Iteratively(int heapArrayLength);

        public abstract void BuildHeap_Recursively(int heapArrayLength);

        public abstract void Insert(KeyValuePair<TKey, TValue> keyValue, int heapArrayLength);

        public abstract bool TryRemoveRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength);

        public abstract bool TryFindRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength);

        public abstract void BubbleDown_Recursively(int rootIndex, int heapArrayLength);

        public abstract void BubbleDown_Iteratively(int rootIndex, int heapArrayLength);

        public abstract void BubbleUp_Iteratively(int index, int heapArrayLength);

        public List<KeyValuePair<TKey, TValue>> HeapArray;

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

        public int GetNodeLevel(int index)
        {
            double level = Math.Floor(Math.Log(index + 1, 2));
            return Convert.ToInt32(level);
        }

        /// <summary>
        /// Finds the minimum element in the array, among the given indexes, with respect to minValueReference, and returns the index of the min value. 
        /// </summary>
        /// <param name="list">Specifies the list of values. </param>
        /// <param name="indexes">Specifies the list of indexes among which we want to find the minimum value. </param>
        /// <param name="minKeyReference">Specifies the reference for the minimum value.  </param>
        /// <param name="minKeyIndex">Specifies the index of the minimum value among the specifies indexes. </param>
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
        /// <param name="list">Specifies the list of values. </param>
        /// <param name="listLength">Specifies the length of values array, which based on the usage, might be less than values.Count. For example when called via Heap-Sort. </param>
        /// <param name="indexes">Specifies the list of indexes among which we want to find the maximum value. </param>
        /// <param name="maxKeyReference">Specifies the reference for the maximum value.  </param>
        /// <param name="maxKeyIndex">Specifies the index of the maximum value among the specifies indexes. </param>
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
