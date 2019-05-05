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
    /// Implements Interpolation search algorithm for finding a specific value in a sorted array.
    /// </summary>
    public class InterpolationSearch
    {
        /// <summary>
        /// Searches in a sorted list of any comparable type, where values have a uniform distribution. Interpolation search is an improvement over binary search, and has a very similar implementation, the only main difference is where (which index in the array) the search starts at.
        /// The search is named interpolation, as it always has two main poles that it moves back and forth between them, these poles are the start index and the end index of the array. 
        /// Notice that only works if the given array is sorted. 
        /// </summary>
        /// <param name="sortedList">A sorted list of any comparable type that are also uniformly distributed. </param>
        /// <param name="startIndex">The lowest (left-most) index of the array - inclusive. </param>
        /// <param name="endIndex">The highest (right-most) index of the array - inclusive. </param>
        /// <param name="key">The value that is being searched for. </param>
        /// <returns>The index of the <paramref name="key"/> in the array, and -1 if it does not exist in the array. </returns>
        [Algorithm(AlgorithmType.Search, "InterpolationSearch", Assumptions = "Array is sorted with an ascending order, and elements are driven from a uniform distribution.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(Log(Log(n)))")]
        public static int Search<T>(List<T> sortedList, int startIndex, int endIndex, T key) where T : IComparable<T>
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

            int searchStartIndex = GetStartIndex(sortedList, startIndex, endIndex, key);
            if (!(searchStartIndex >= startIndex && searchStartIndex <= endIndex))
            {
                return -1;
            }

            T searchStartValue = sortedList[searchStartIndex];

            if (key.CompareTo(searchStartValue) == 0)
            {
                return searchStartIndex;
            }

            if (key.CompareTo(searchStartValue) < 0)
            {
                return Search(sortedList, startIndex, searchStartIndex - 1, key);
            }

            if (key.CompareTo(searchStartValue) > 0)
            {
                return Search(sortedList, searchStartIndex + 1, endIndex, key);
            }

            return -1;
        }

        /// <summary>
        /// Computes an index to start the search from, Dependent on the value we are after. 
        /// This formula is such that if the <paramref name="key"/> is closer to the value in the <paramref name="startIndex"/>, the search start point will be chosen closer to the <paramref name="startIndex"/>, and if the <paramref name="key"/> is closer to the value at <paramref name="endIndex"/>, the search start point will be chosen closer to the <paramref name="endIndex"/>.
        /// </summary>
        /// <param name="sortedList">A sorted list of any comparable type that are also uniformly distributed. </param>
        /// <param name="startIndex">The lowest (left-most) index of the array - inclusive. </param>
        /// <param name="endIndex">The highest (right-most) index of the array - inclusive. </param>
        /// <param name="key">The value that is being searched for. </param>
        /// <returns>The index in the array at which to start the search. </returns>
        public static int GetStartIndex<T>(List<T> sortedList, int startIndex, int endIndex, T key) where T : IComparable<T>
        {
            double distanceFromStartIndex = ((dynamic)key - (dynamic)sortedList[startIndex]) / (double)((dynamic)sortedList[endIndex] - (dynamic)sortedList[startIndex]);
            distanceFromStartIndex = distanceFromStartIndex * (endIndex - startIndex);
            int index = (int)(startIndex + distanceFromStartIndex);
            return index;
        }

        // TODO: Implement using binary search, ... where the location of the array is computed by a method, which I will pass here: 
        // also means that I can make a parent class for all the search algorithms, and enforce them to implement their own find the next search position

        // TODO: Implement iterative versions and recursive versions for each search algorithm.. 

        // TODO: Implement methods to count the number of elements each search algorithm checks before finding a value and measure it in average?
        // TODO: Not sure if this will work with types other than integer, because of conversion to dynamic... test with string for example. ... or any object, etc, .. 
    }
}
