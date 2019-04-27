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
using System.Collections.Generic;
using CSFundamentals.Algorithms.Sort.StabilityCheckableVersions;

namespace CSFundamentals.Algorithms.Sort
{
    public partial class QuickSort
    {
        public static void Sort_Recursively(List<Element> values, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = PartitionArray_StabilityCheckableVersion(values, startIndex, endIndex);
                Sort_Recursively(values, startIndex, partitionIndex);
                Sort_Recursively(values, partitionIndex + 1, endIndex);
            }
        }

        /// <summary>
        /// Partitions the given array, with respect to the computed pivot, such that elements to the left of the pivot are smaller than the pivot, and elements to the right of the pivot are bigger than the pivot. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        /// <returns>The next partitioning index. </returns>
        public static int PartitionArray_StabilityCheckableVersion(List<Element> values, int startIndex, int endIndex)
        {
            int pivotIndex = GetPivotIndex(startIndex, endIndex);
            int pivotValue = values[pivotIndex].Value;

            int leftIndex = startIndex;
            int rightIndex = endIndex;

            while (true)
            {
                while (leftIndex <= endIndex && values[leftIndex].Value < pivotValue)
                {
                    leftIndex++;
                }
                while (rightIndex <= endIndex && values[rightIndex].Value > pivotValue)
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
        /// This is to be able to call QuickSort sort methods with only the list that needs to be sorted, and independent of the indexes. 
        /// This is needed for methods that receive other sort methods as parameters, and would ideally like to have similar signature for all the methods that are passed as parameters, 
        /// In sort methods the signature is: void SortMethod(List<int> values); 
        /// </summary>
        /// <param name="values">Specifies the list of integers to be sorted. </param>
        public static void Wrapper(List<Element> values)
        {
            Sort_Recursively(values, 0, values.Count - 1);
        }
    }
}
