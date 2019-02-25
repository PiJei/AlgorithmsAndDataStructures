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

using System.Collections.Generic;

namespace CSFundamentalAlgorithms.SortingAlgorithms
{
    public partial class QuickSort
    {
        /// <summary>
        /// Implements quick sort to sort integer values in an array, ascending. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="lowIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="highIndex">Specifies the higher index in the array, inclusive. </param>
        [Algorithm("Sort", "QuickSort")]
        public static void Sort_Recursively(List<int> values, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int partitionIndex = PartitionArray(values, lowIndex, highIndex);
                Sort_Recursively(values, lowIndex, partitionIndex);
                Sort_Recursively(values, partitionIndex + 1, highIndex);
            }
        }

        /// <summary>
        /// Partitions the given array, with respect to the computed pivot, such that elements to the left of the pivot are smaller than the pivot, and elements to the right of the pivot are bigger than the pivot. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="lowIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="highIndex">Specifies the higher index in the array, inclusive. </param>
        /// <returns>The next partitioning index. </returns>
        public static int PartitionArray(List<int> values, int lowIndex, int highIndex)
        {
            int pivotIndex = GetPivotIndex(lowIndex, highIndex);
            int pivotValue = values[pivotIndex];

            int leftIndex = lowIndex;
            int rightIndex = highIndex;

            while (true)
            {
                while (leftIndex <= highIndex && values[leftIndex] < pivotValue)
                {
                    leftIndex++;
                }
                while (rightIndex <= highIndex && values[rightIndex] > pivotValue)
                {
                    rightIndex--;
                }
                if (rightIndex <= leftIndex)
                {
                    return rightIndex;
                }
                Utils.Swap(values, leftIndex, rightIndex);

                /* The next two increments are needed, as otherwise there will be issues with duplicate values in the array.
                 * Notice an alternative would be to remove these two increments, and make the loops do-while, in which case leftIndex = currentLeftIndex-1, and rightIndex = currentRightIndex+1 
                 */
                leftIndex++;
                rightIndex--;
            }
        }

        /// <summary>
        /// This algorithm uses the middle element of the array as pivot. Other mechanisms exist also. 
        /// </summary>
        /// <param name="lowIndex"></param>
        /// <param name="highIndex"></param>
        /// <returns></returns>
        public static int GetPivotIndex(int lowIndex, int highIndex)
        {
            return (lowIndex + highIndex) / 2;
        }

        /// <summary>
        /// Provides an iterative version of QuickSort.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="lowIndex"></param>
        /// <param name="highIndex"></param>
        public static void Sort_Iteratively(List<int> values, int lowIndex, int highIndex)
        {
            // TODO
        }
    }
}
