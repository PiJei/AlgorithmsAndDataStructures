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
using CSFundamentals.Decoration;

namespace CSFundamentals.Algorithms.Search
{
    /// <summary>
    /// Implements Binary search algorithm for finding a specific value in a sorted array.
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// Searches in a sorted list of any comparable type, and returns the index of the <paramref name="key"/> using binary search, and -1 if it is not found. 
        /// </summary>
        /// <param name="sortedList">A sorted list of any comparable type. </param>
        /// <param name="key">The value that is being searched for. </param>
        /// <param name="startIndex">The lowest (left-most) index of the array - inclusive. </param>
        /// <param name="endIndex">The highest (right-most) index of the array - inclusive. </param>
        /// <returns>The index of the <paramref name="key"/> in the array, and -1 if it is absent from the array. </returns>
        [Algorithm(AlgorithmType.Search, "BinarySearch", Assumptions = "Array is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        public static int Search<T>(List<T> sortedList, T key, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex > endIndex)
            {
                return -1;
            }

            /* If key is NOT in the range, terminate search. Since the input array is sorted this early check is feasible. */
            if (key.CompareTo(sortedList[startIndex]) < 0 || key.CompareTo(sortedList[endIndex]) > 0)
            {
                return -1;
            }

            int middleIndex = (startIndex + endIndex) / 2;
            T middleValue = sortedList[middleIndex];

            if (key.CompareTo(middleValue) == 0)
            {
                return middleIndex;
            }
            if (key.CompareTo(middleValue) < 0)
            {
                return Search(sortedList, key, startIndex, middleIndex - 1);
            }
            if (key.CompareTo(middleValue) > 0)
            {
                return Search(sortedList, key, middleIndex + 1, endIndex);
            }

            return -1;
        }
    }
}
