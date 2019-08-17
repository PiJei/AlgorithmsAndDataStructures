#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps.API;

namespace AlgorithmsAndDataStructuresTests.DataStructures.BinaryHeaps.API
{
    /// <summary>
    /// Implements a mock heap to enable testing abstract class of <see cref="BinaryHeapBase{TKey, TValue}"/>.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MockBinaryHeap<TKey, TValue> : BinaryHeapBase<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">An array of key-value pairs to be converted to a heap. </param>
        public MockBinaryHeap(List<KeyValuePair<TKey, TValue>> array) : base(array)
        {
        }

        /// <summary>
        /// Implements the bubble down/trickle down operation using iteration.
        /// </summary>
        /// <param name="rootIndex">The index of the root element, the element for which the trickle down should be performed.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void BubbleDown_Iteratively(int rootIndex, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements the bubble down/trickle down operation using recursion.
        /// </summary>
        /// <param name="rootIndex">The index of the root element, the element for which the trickle down should be performed.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void BubbleDown_Recursively(int rootIndex, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the value in the given index, up in the heap till its position is found. The position is defined such to respect heap ordering property.
        /// </summary>
        /// <param name="index">The index of the element that should be bubbled up.</param>
        /// <param name="heapArrayLength">The length/size of the heap array. </param>
        public override void BubbleUp_Iteratively(int index, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Note that passing the array size is not a must, as the class itself contains the array and has access to its size. However some algorithms such as HeapSort which rely on a heap to perform sorting, are better implemented, if we have the length of the array passed to these methods. 
        /// </summary>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void BuildHeap_Iteratively(int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a heap using recursion, and does so in situ.
        /// </summary>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void BuildHeap_Recursively(int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a new value into heap.
        /// </summary>
        /// <param name="keyValue">The key-value to be inserted into the heap.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void Insert(KeyValuePair<TKey, TValue> keyValue, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the root of the heap, without removing it. 
        /// </summary>
        /// <param name="keyValue">The key-value of the root.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        /// <returns>True in case of success, and false in case of failure.</returns>
        public override bool TryFindRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the root of the heap. In a MinHeap and MinMaxHeap this is the min, and in a MaxHeap and MaxMinHeap this is the max. 
        /// </summary>
        /// <param name="keyValue">The key-value of the root.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        /// <returns>True in case of success, and false otherwise.</returns>
        public override bool TryRemoveRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength)
        {
            throw new NotImplementedException();
        }
    }
}
