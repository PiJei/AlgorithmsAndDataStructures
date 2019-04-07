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
using CSFundamentals.Styling;

namespace CSFundamentals.Algorithms.Search
{
    public class BinarySearch
    {
        /// <summary>
        /// Searches in a sorted list of any comparable type, and returns the index of the <paramref name="searchValue"/> using binary search, and -1 if it is not found. 
        /// </summary>
        /// <param name="values">A sorted list of any comparable type. </param>
        /// <param name="startIndex">Specifies the lowest (left-most) index of the array - inclusive. </param>
        /// <param name="endIndex">Specifies the highest (right-most) index of the array - inclusive. </param>
        /// <param name="searchValue">Specifies the value that is being searched for. </param>
        /// <returns>The index of the <paramref name="searchValue"/> in the array, and -1 if it is absent from the array. </returns>
        [Algorithm(AlgorithmType.Search, "BinarySearch", Assumptions = "Array is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        public static int Search<T>(List<T> values, int startIndex, int endIndex, T searchValue) where T : IComparable<T>
        {
            if (startIndex <= endIndex &&
                searchValue.CompareTo(values[startIndex]) >= 0 && /* Check whether searchValue is in the range. Since the input array is sorted this is feasible. */
                searchValue.CompareTo(values[endIndex]) <= 0)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                T middleValue = values[middleIndex];

                if (searchValue.CompareTo(middleValue) == 0)
                {
                    return middleIndex;
                }
                if (searchValue.CompareTo(middleValue) < 0)
                {
                    return Search(values, startIndex, middleIndex - 1, searchValue);
                }
                if (searchValue.CompareTo(middleValue) > 0)
                {
                    return Search(values, middleIndex + 1, endIndex, searchValue);
                }
            }
            return -1;
        }
    }
}
