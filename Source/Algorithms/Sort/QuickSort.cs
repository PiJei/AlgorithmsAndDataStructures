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
using System.Runtime.CompilerServices;
using CSFundamentals.Decoration;

[assembly: InternalsVisibleTo("CSFundamentalAlgorithmsTests")]

namespace CSFundamentals.Algorithms.Sort
{
    public partial class QuickSort
    {
        /// <summary>
        /// Implements quick sort recursively. 
        /// </summary>
        /// <param name="values">Specifies the list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        [Algorithm(AlgorithmType.Sort, "QuickSort")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(nLog(n))")]
        [TimeComplexity(Case.Worst, "O(n²)", When = "Minimum or maximum element in the array is chosen as the pivot.")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        public static void Sort_Recursively<T>(List<T> values, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = PartitionArray(values, startIndex, endIndex);
                Sort_Recursively(values, startIndex, partitionIndex);
                Sort_Recursively(values, partitionIndex + 1, endIndex);
            }
        }

        //TODO: Write a unit test for this 
        /// <summary>
        /// Partitions the given array, with respect to the computed pivot, such that elements to the left of the pivot are smaller than the pivot, and elements to the right of the pivot are bigger than the pivot. 
        /// </summary>
        /// <param name="values">Specifies the list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        /// <returns>The next partitioning index. </returns>
        internal static int PartitionArray<T>(List<T> values, int startIndex, int endIndex) where T : IComparable<T>
        {
            int pivotIndex = GetPivotIndex(startIndex, endIndex);
            T pivotValue = values[pivotIndex];

            int leftIndex = startIndex;
            int rightIndex = endIndex;

            while (true)
            {
                while (leftIndex <= endIndex && values[leftIndex].CompareTo(pivotValue) < 0)
                {
                    leftIndex++;
                }
                while (rightIndex <= endIndex && values[rightIndex].CompareTo(pivotValue) > 0)
                {
                    rightIndex--;
                }
                if (rightIndex <= leftIndex)
                {
                    return rightIndex;
                }
                Utils.Swap(values, leftIndex, rightIndex);

                /* The next two increments are needed, as otherwise there will be issues with duplicate values in the array.
                 * Notice an alternative would be to remove these two increments, and make the loops do-while, in which case leftIndex = currentLeftIndex-1, and rightIndex = currentRightIndex+1 */
                leftIndex++;
                rightIndex--;
            }
        }

        /// <summary>
        /// This algorithm uses the middle element of the array as pivot. The algorithm can be replaced with other mechanisms as well. 
        /// </summary>
        /// <param name="startIndex">Specifies the startIndex of an array.</param>
        /// <param name="endIndex">Specifies the endIndex of an array. </param>
        /// <returns></returns>
        public static int GetPivotIndex(int startIndex, int endIndex)
        {
            return (startIndex + endIndex) / 2;
        }

        /// <summary>
        /// Provides an iterative version of QuickSort.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void Sort_Iteratively<T>(List<T> values, int startIndex, int endIndex) where T : IComparable<T>
        {
            throw new NotImplementedException();
        }
    }
}
