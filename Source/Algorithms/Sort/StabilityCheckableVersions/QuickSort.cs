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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Sort.StabilityCheckableVersions;

namespace AlgorithmsAndDataStructures.Algorithms.Sort
{
    public partial class QuickSort
    {
        /// <summary>
        /// Implements a recursive version of quick sort. 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void Sort_Recursively(List<Element> list, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = PartitionList_StabilityCheckableVersion(list, startIndex, endIndex);
                Sort_Recursively(list, startIndex, partitionIndex);
                Sort_Recursively(list, partitionIndex + 1, endIndex);
            }
        }

        /// <summary>
        /// Partitions the given list, with respect to the computed pivot, such that elements to the left of the pivot are smaller than the pivot, and elements to the right of the pivot are bigger than the pivot. 
        /// </summary>
        /// <param name="list">The list of integer values to be sorted. </param>
        /// <param name="startIndex">The lower index in the list, inclusive. </param>
        /// <param name="endIndex">The higher index in the list, inclusive. </param>
        /// <returns>The next partitioning index. </returns>
        public static int PartitionList_StabilityCheckableVersion(List<Element> list, int startIndex, int endIndex)
        {
            int pivotIndex = GetPivotIndex(startIndex, endIndex);
            int pivotValue = list[pivotIndex].Value;

            int leftIndex = startIndex;
            int rightIndex = endIndex;

            while (true)
            {
                while (leftIndex <= endIndex && list[leftIndex].Value < pivotValue)
                {
                    leftIndex++;
                }
                while (rightIndex <= endIndex && list[rightIndex].Value > pivotValue)
                {
                    rightIndex--;
                }
                if (rightIndex <= leftIndex)
                {
                    return rightIndex;
                }

                Utils.Swap(list, leftIndex, rightIndex);

                /* The next two increments are needed, as otherwise there will be issues with duplicate values in the list.
                 * Notice an alternative would be to remove these two increments, and make the loops do-while, in which case leftIndex = currentLeftIndex-1, and rightIndex = currentRightIndex+1 
                 */
                leftIndex++;
                rightIndex--;
            }
        }

        /// <summary>
        /// This is to be able to call QuickSort sort methods with only the list that needs to be sorted, and independent of the indexes. 
        /// This is needed for methods that receive other sort methods as parameters, and would ideally like to have similar signature for all the methods that are passed as parameters, 
        /// In sort methods the signature is: void SortMethod(List{int} list); 
        /// </summary>
        /// <param name="list">The list of integers to be sorted. </param>
        public static void Wrapper(List<Element> list)
        {
            Sort_Recursively(list, 0, list.Count - 1);
        }
    }
}
