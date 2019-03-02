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

// TODO: make generic

using System.Collections.Generic;
using CSFundamentalAlgorithms.BinaryHeaps;

namespace CSFundamentalAlgorithms.Algorithms.Sort
{
    public partial class HeapSort
    {
        // TODO: Make generic
        /// <summary>
        /// Sorts the elements in an integer array using heap sort algorithm in to an ascending order. 
        /// </summary>
        /// <param name="values">Specifies the list of values (of type T, e.g., int) to be sorted.</param>
        [Algorithm(AlgorithmType.Sort, "HeapSort")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(nLog(n))")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        public static void Sort_Ascending(List<int> values)
        {
            // 1- re-arrange the elements in the integer array into a max heap. 
            var maxHeap = new MaxBinaryHeap(values);
            maxHeap.BuildHeap_Recursively(values.Count);

            // 2- repeat the following 2 steps for all the elements in the array. 
            for (int i = values.Count - 1; i >= 0; i--)
            {
                // Since the root element/node in a max heap, is the most maximum value in the array, putting it to the last element of the unsorted part of the array, will determine its right position in an array that is eventually ordered ascending
                Utils.Swap(values, 0, i);
                // Since the new value in the root position of the heap (index :0) may not be in its correct position, heap-order-wise, then bubble it down, until it reaches its correct position.
                maxHeap.BubbleDown_Recursively(0, i);
            }
        }
    }
}
