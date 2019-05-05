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
    /// Implements Ternary search algorithm for finding a specific value in a sorted array.
    /// </summary>
    public class TernarySearch
    {
        /// <summary>
        /// Implements ternary search recursively on a list of any comparable type. 
        /// This search is inspired by binary search (hence the naming, 3 versus 2).
        /// The difference being that rather than dividing the array into 2 sections, divides it into 3 equal sections and performs the search inside each one of those separately.
        /// Notice that only works if the given array is sorted. 
        /// </summary>
        /// <param name="sortedList">A sorted list of any comparable type. </param>
        /// <param name="startIndex">The lowest (left-most) index of the array - inclusive. </param>
        /// <param name="endIndex">The highest (right-most) index of the array - inclusive. </param>
        /// <param name="key">The value that is being searched for. </param>
        /// <returns>The index of the <paramref name="key"/> in the array, and -1 if it does not exist in the array. </returns>
        [Algorithm(AlgorithmType.Search, "TernarySearch", Assumptions = "Array is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(log3(n))")]
        [TimeComplexity(Case.Average, "")] // TODO
        public static int Search<T>(List<T> sortedList, int startIndex, int endIndex, T key) where T : IComparable
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

            /* Dividing array by ((endIndex - startIndex) / 3) size in2o 3 sections. */
            int middleIndex1 = startIndex + (endIndex - startIndex) / 3;
            int middleIndex2 = middleIndex1 + (endIndex - startIndex) / 3;

            T middleValue1 = sortedList[middleIndex1];
            T middleValue2 = sortedList[middleIndex2];

            if (key.CompareTo(middleValue1) == 0)
            {
                return middleIndex1;
            }

            if (key.CompareTo(middleValue2) == 0)
            {
                return middleIndex2;
            }

            if (key.CompareTo(middleValue1) < 0)
            {
                return Search(sortedList, startIndex, middleIndex1 - 1, key);
            }

            if (key.CompareTo(middleValue1) > 0 && key.CompareTo(middleValue2) < 0)
            {
                return Search(sortedList, middleIndex1 + 1, middleIndex2 - 1, key);
            }

            if (key.CompareTo(middleValue2) > 0)
            {
                return Search(sortedList, middleIndex2 + 1, endIndex, key);
            }

            return -1;
        }
    }
}
