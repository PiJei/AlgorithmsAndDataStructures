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

namespace CSFundamentals.DataStructures.BinaryHeaps.API
{
    public interface IBinaryHeap<T> where T:IComparable<T>
    {
        /// <summary>
        /// Builds a heap using recursion, and does so in situ.
        /// </summary>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        void BuildHeap_Recursively(int heapArrayLength);

        /// <summary>
        /// Builds a heap iteratively, and does so in situ.
        /// </summary>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        void BuildHeap_Iteratively(int heapArrayLength);

        /// <summary>
        /// This method is for inserting a new value into heap.
        /// </summary>
        /// <param name="value">Specifies the value to be inserted into the heap.</param>
        void Insert(T value, int heapArrayLength);

        /// <summary>
        /// This method is for removing the root of the heap. In a MinHeap and MinMaxHeap this is the min, and in a MaxHeap and MaxMinHeap this is the max. 
        /// </summary>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        /// <returns>True in case of success, and false otherwise.</returns>
        bool TryRemoveRoot(out T rootValue, int heapArrayLength);

        /// <summary>
        /// This method is for finding the root of the heap, without removing it. 
        /// </summary>
        /// <param name="rootValue"></param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        /// <returns>True in case of success, and false in case of failure.</returns>
        bool TryFindRoot(out T rootValue, int heapArrayLength);

        /// <summary>
        /// This method implements the bubble down/trickle down operation using recursion.
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the root element, the element for which the trickle down should be performed.</param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        void BubbleDown_Recursively(int rootIndex, int heapArrayLength);

        /// <summary>
        /// This method implements the bubble down/trickle down operation using iteration.
        /// </summary>
        /// <param name="rootIndex">Specifies the index of the root element, the element for which the trickle down should be performed.</param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        void BubbleDown_Iteratively(int rootIndex, int heapArrayLength);

        /// <summary>
        /// Moves the value in the given index, up in the heap till its position is found. The position is defined such to respect heap ordering property.
        /// </summary>
        /// <param name="index">Specifies the index of the element that should be bubbled up.</param>
        /// <param name="heapArrayLength">Specifies the length/size of the heap array. </param>
        void BubbleUp_Iteratively(int index, int heapArrayLength);

        /// <summary>
        /// Returns the index of the left child for the given index in a heap array.
        /// </summary>
        /// <param name="index">Specifies the index of a node in an array.</param>
        /// <returns>The index of the left child.</returns>
        int GetLeftChildIndexInHeapArray(int index);

        /// <summary>
        /// Returns the index of the right child for the given index in a heap array.
        /// </summary>
        /// <param name="index">Specifies the index of a node in an array.</param>
        /// <returns>The index of the right child.</returns>
        int GetRightChildIndexInHeapArray(int index);

        /// <summary>
        /// Returns the index of the parent for the given index in a heap array.
        /// </summary>
        /// <param name="index">Specifies the index of a node in an array.</param>
        /// <returns>The index of the parent.</returns>
        int GetParentIndex(int index);

        /// <summary>
        /// Returns the level of a node in the heap, given the node's index in the heap array.
        /// </summary>
        /// <param name="index">Specifies the index of a node in an array. </param>
        /// <returns>Returns the level of the node. </returns>
        int GetNodeLevel(int index);

        /// <summary>
        /// Swaps the values at the given two indexes in the given array.
        /// </summary>
        /// <param name="array">Specifies an array.</param>
        /// <param name="index1">Specifies the first index. </param>
        /// <param name="index2">Specifies the second index.</param>
        void Swap(List<T> array, int index1, int index2);
    }
}

//TODO: search all the swap implementations and have only one!