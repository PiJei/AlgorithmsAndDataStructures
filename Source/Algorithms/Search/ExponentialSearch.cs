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
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    /// <summary>
    /// Implements Exponential search algorithm for finding a specific value in a sorted list.
    /// </summary>
    public class ExponentialSearch
    {
        /// <summary>
        /// Implements exponential search, where the search step is a multiple of 2, hence the naming. 
        /// Notice that only works if the given list is sorted. 
        /// </summary>
        /// <typeparam name="T">Type of the values in the sorted list.</typeparam>
        /// <param name="sortedList">A sorted list of any comparable type. </param>
        /// <param name="key">The value that is being searched for. </param>
        /// <returns>The index of the <paramref name="key"/> in the list, and -1 if it does not exist in the list. </returns>
        [Algorithm(AlgorithmType.Search, "ExponentialSearch", Assumptions = "List is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(log(i)), i is the index of the key in the list.")]
        [TimeComplexity(Case.Average, "O(log(i)), i is the index of the key in the list.")]
        public static int Search<T>(List<T> sortedList, T key) where T : IComparable<T>
        {
            /* If key is NOT in the range, terminate search. Since the input list is sorted this early check is feasible. */
            if (key.CompareTo(sortedList[0]) < 0 || key.CompareTo(sortedList[sortedList.Count - 1]) > 0)
            {
                return -1;
            }

            if (sortedList[0].CompareTo(key) == 0)
            {
                return 0;
            }

            int nextIndex = 1; /* Ideally should start from index 0, however that would make the while loop indexing complex, thus treating index 0 differently, and then continuing with the rest. */
            while (nextIndex < sortedList.Count && sortedList[nextIndex].CompareTo(key) < 0) /* multiple the search step by 2, until encountering an element that is bigger than the key. */
            {
                nextIndex *= 2;
            }

            if (nextIndex >= sortedList.Count)
            {
                nextIndex = sortedList.Count - 1;
            }
            if (sortedList[nextIndex].CompareTo(key) == 0)
            {
                return nextIndex;
            }

            /* The range at which the key is expected to be is thus [(nextIndex/2)+1, nextIndex-1] - perform a binary search over this range. */
            return BinarySearch.Search(sortedList, key, nextIndex / 2 + 1, nextIndex - 1);
        }
    }
}
