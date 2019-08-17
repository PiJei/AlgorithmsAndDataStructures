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
    /// Implements Jump search algorithm for finding a specific value in a sorted list.
    /// </summary>
    public class JumpSearch
    {
        /// <summary>
        /// Performs a jumpSearch on a list of integers to find the <paramref name="key"/>. 
        /// Notice that only works if the given list is sorted. 
        /// </summary>
        /// <param name="sortedList">A sorted list of any comparable type.</param>
        /// <param name="key">The value the method is searching for. </param>
        /// <returns>The index of the <paramref name="key"/> in the list, and -1 if it does not exist in the list. </returns>
        [Algorithm(AlgorithmType.Search, "JumpSearch", Assumptions = "List is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "o(√n)")]
        [TimeComplexity(Case.Average, "O(√n)")]
        public static int Search<T>(List<T> sortedList, T key) where T : IComparable<T>
        {
            /* If key is NOT in the range, terminate search. Since the input list is sorted this early check is feasible. */
            if (key.CompareTo(sortedList[0]) < 0 || key.CompareTo(sortedList[sortedList.Count - 1]) > 0)
            {
                return -1;
            }

            int jumpStepLength = (int)Math.Floor(Math.Sqrt(sortedList.Count));

            int nextIndex = 0;
            while (sortedList[nextIndex].CompareTo(key) < 0)
            {
                nextIndex += jumpStepLength; // Jump forward
                if (nextIndex >= sortedList.Count)
                {
                    nextIndex = sortedList.Count - 1;
                    break;
                }
            }

            if (sortedList[nextIndex].CompareTo(key) == 0)
            {
                return nextIndex;
            }

            int linearSearchStartIndex = nextIndex - jumpStepLength + 1; // Jump backward. 
            if (linearSearchStartIndex < 0)
            {
                return -1;
            }
            return LinearSearch.Search(sortedList, key, linearSearchStartIndex, nextIndex - 1);
        }
    }
}
