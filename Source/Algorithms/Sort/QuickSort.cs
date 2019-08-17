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
using System.Runtime.CompilerServices;
using AlgorithmsAndDataStructures.Decoration;

[assembly: InternalsVisibleTo("AlgorithmsAndDataStructuresTests")]

namespace AlgorithmsAndDataStructures.Algorithms.Sort
{
    /// <summary>
    /// Implements Quick sort algorithm. 
    /// </summary>
    public partial class QuickSort
    {
        /// <summary>
        /// Implements quick sort recursively. 
        /// </summary>
        /// <param name="list">The list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">The lower index in the list, inclusive. </param>
        /// <param name="endIndex">The higher index in the list, inclusive. </param>
        [Algorithm(AlgorithmType.Sort, "QuickSort")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(nLog(n))")]
        [TimeComplexity(Case.Worst, "O(n²)", When = "Minimum or maximum element in the list is chosen as the pivot.")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        public static void Sort<T>(List<T> list, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = PartitionList(list, startIndex, endIndex);
                Sort(list, startIndex, partitionIndex);
                Sort(list, partitionIndex + 1, endIndex);
            }
        }

        /// <summary>
        /// Partitions the given list, with respect to the computed pivot, such that elements to the left of the pivot are smaller than the pivot, and elements to the right of the pivot are bigger than the pivot. 
        /// </summary>
        /// <param name="list">The list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">The lower index in the list, inclusive. </param>
        /// <param name="endIndex">The higher index in the list, inclusive. </param>
        /// <returns>The next partitioning index. </returns>
        internal static int PartitionList<T>(List<T> list, int startIndex, int endIndex) where T : IComparable<T>
        {
            int pivotIndex = GetPivotIndex(startIndex, endIndex);
            T pivotValue = list[pivotIndex];

            int leftIndex = startIndex;
            int rightIndex = endIndex;

            while (true)
            {
                while (leftIndex <= endIndex && list[leftIndex].CompareTo(pivotValue) < 0)
                {
                    leftIndex++;
                }
                while (rightIndex <= endIndex && list[rightIndex].CompareTo(pivotValue) > 0)
                {
                    rightIndex--;
                }
                if (rightIndex <= leftIndex)
                {
                    return rightIndex;
                }
                Utils.Swap(list, leftIndex, rightIndex);

                /* The next two operations are needed, as otherwise there will be issues with duplicate values in the list.
                 * Notice an alternative would be to remove the next two operations, and make the loops do-while, in which case leftIndex = currentLeftIndex-1, and rightIndex = currentRightIndex+1 */
                leftIndex++;
                rightIndex--;
            }
        }

        /// <summary>
        /// This algorithm uses the middle element of the list as pivot. The algorithm can be replaced with other mechanisms as well. 
        /// </summary>
        /// <param name="startIndex">The startIndex of a list.</param>
        /// <param name="endIndex">The endIndex of a list. </param>
        /// <returns></returns>
        public static int GetPivotIndex(int startIndex, int endIndex)
        {
            return (startIndex + endIndex) / 2;
        }
    }
}
