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
using System.Linq;
using System.Collections.Generic;

namespace CSFundamentals.DataStructures.BinaryHeaps.API
{
    public abstract class BinaryHeapBase<T> : IBinaryHeap<T> where T : IComparable<T>
    {
        /// <summary>
        /// Note that passing the array size is not a must, as the class itself contains the array and has access to its size. However some algorithms such as HeapSort which rely on a heap to perform sorting, are better implemented, if we have the length of the array passed to these methods. 
        /// </summary>
        /// <param name="heapArrayLength"></param>
        public abstract void BuildHeap_Iteratively(int heapArrayLength);

        public abstract void BuildHeap_Recursively(int heapArrayLength);

        public abstract void Insert(T value, int heapArrayLength);

        public abstract bool TryRemoveRoot(out T rootValue, int heapArrayLength);

        public abstract bool TryFindRoot(out T rootValue, int heapArrayLength);

        public abstract void BubbleDown_Recursively(int rootIndex, int heapArrayLength);

        public abstract void BubbleDown_Iteratively(int rootIndex, int heapArrayLength);

        public abstract void BubbleUp_Iteratively(int index, int heapArrayLength);

        public List<T> HeapArray;

        public BinaryHeapBase(List<T> array)
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
        /// <param name="values">Specifies the list of values. </param>
        /// <param name="indexes">Specifies the list of indexes among which we want to find the minimum value. </param>
        /// <param name="minValueReference">Specifies the reference for the minimum value.  </param>
        /// <param name="minValueIndex">Specifies the index of the minimum value among the specifies indexes. </param>
        /// <returns>True in case of success, and false in case of failure. </returns>
        public bool TryFindIndexOfMinSmallerThanReference(List<T> values, List<int> indexes, T minValueReference, out int minValueIndex)
        {
            minValueIndex = Int32.MinValue;

            /* If all of the indexes exceed the range of the array, return false, and leave minValueReference as it was */
            if (indexes.All(index => index >= values.Count || index < 0))
            {
                return false;
            }

            /* Find the minimum value.*/
            foreach (int index in indexes.Where(index => index < values.Count && index >= 0 && values[index].CompareTo(minValueReference) < 0))
            {
                minValueReference = values[index];
                minValueIndex = index;
            }

            /* In the case that minValueReference is smallest, nothing changes, and minValueIndex remains as initiated at the beginning of the method. */
            if (minValueIndex == Int32.MinValue)
            {
                return false; /* meaning none of the elements in the given indexes, were smaller than the reference value. */
            }

            return true;
        }

        /// <summary>
        /// Finds the maximum element in the array, among the given indexes, with respect to maxValueReference, and returns the index of the max value. 
        /// </summary>
        /// <param name="values">Specifies the list of values. </param>
        /// <param name="valuesCount">Specifies the length of values array, which based on the usage, might be less than values.Count. For example when called via Heap-Sort. </param>
        /// <param name="indexes">Specifies the list of indexes among which we want to find the maximum value. </param>
        /// <param name="maxValueReference">Specifies the reference for the maximum value.  </param>
        /// <param name="maxValueIndex">Specifies the index of the maximum value among the specifies indexes. </param>
        /// <returns>True in case of success, and false in case of failure. </returns>
        public bool TryFindIndexOfMaxBiggerThanReference(List<T> values, int valuesCount, List<int> indexes, T maxValueReference, out int maxValueIndex)
        {
            maxValueIndex = Int32.MaxValue;

            /* If all of the indexes exceed the range of the array, return false, and leave maxValueReference as it was */
            if (indexes.All(index => index >= valuesCount))
            {
                return false;
            }

            /* Find the minimum value.*/
            foreach (int index in indexes.Where(index => index < valuesCount && values[index].CompareTo(maxValueReference) > 0))
            {
                maxValueReference = values[index];
                maxValueIndex = index;
            }

            /* In the case that maxValueReference is biggest, nothing changes, and maxValueIndex remains as initiated at the beginning of the method. */
            if (maxValueIndex == Int32.MaxValue)
            {
                return false; /* meaning none of the elements in the given indexes, were bigger than the reference value. */
            }

            return true;
        }

        public int FindIndex(T value)
        {
            for (int i = 0; i < HeapArray.Count; i++)
            {
                if (HeapArray[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
