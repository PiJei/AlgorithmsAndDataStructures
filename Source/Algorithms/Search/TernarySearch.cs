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
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    /// <summary>
    /// Implements Ternary search algorithm for finding a specific value in a sorted list.
    /// </summary>
    public class TernarySearch
    {
        /// <summary>
        /// Implements ternary search recursively on a list of any comparable type. 
        /// This search is inspired by binary search (hence the naming, 3 versus 2).
        /// The difference being that rather than dividing the list into 2 sections, divides it into 3 equal sections and performs the search inside each one of those separately.
        /// Notice that only works if the given list is sorted. 
        /// </summary>
        /// <param name="sortedList">A sorted list of any comparable type. </param>
        /// <param name="key">The value that is being searched for. </param>
        /// <param name="startIndex">The lowest (left-most) index of the list - inclusive. </param>
        /// <param name="endIndex">The highest (right-most) index of the list - inclusive. </param>
        /// <returns>The index of the <paramref name="key"/> in the list, and -1 if it does not exist in the list. </returns>
        [Algorithm(AlgorithmType.Search, "TernarySearch", Assumptions = "List is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(log3(n))")]
        [TimeComplexity(Case.Average, "")] // TODO
        public static int Search<T>(List<T> sortedList, T key, int startIndex, int endIndex) where T : IComparable
        {
            if (startIndex > endIndex)
            {
                return -1;
            }

            /* If key is NOT in the range, terminate search. Since the input list is sorted this early check is feasible. */
            if (key.CompareTo(sortedList[startIndex]) < 0 || key.CompareTo(sortedList[endIndex]) > 0)
            {
                return -1;
            }

            /* Dividing list by ((endIndex - startIndex) / 3) size in to 3 sections. */
            int oneThirdIndex = startIndex + (endIndex - startIndex) * 1 / 3;
            int twoThirdIndex = startIndex + (endIndex - startIndex) * 2 / 3;

            T oneThirdValue = sortedList[oneThirdIndex];
            T twoThirdValue = sortedList[twoThirdIndex];

            if (key.CompareTo(oneThirdValue) == 0)
            {
                return oneThirdIndex;
            }

            if (key.CompareTo(twoThirdValue) == 0)
            {
                return twoThirdIndex;
            }

            if (key.CompareTo(oneThirdValue) < 0)
            {
                return Search(sortedList, key, startIndex, oneThirdIndex - 1);
            }

            if (key.CompareTo(oneThirdValue) > 0 && key.CompareTo(twoThirdValue) < 0)
            {
                return Search(sortedList, key, oneThirdIndex + 1, twoThirdIndex - 1);
            }

            if (key.CompareTo(twoThirdValue) > 0)
            {
                return Search(sortedList, key, twoThirdIndex + 1, endIndex);
            }

            return -1;
        }
    }
}
