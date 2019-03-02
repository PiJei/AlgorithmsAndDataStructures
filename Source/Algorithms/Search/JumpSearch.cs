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

namespace CSFundamentals.Algorithms.Search
{
    public class JumpSearch
    {
        /// <summary>
        /// Performs a jumpSearch on a list of integers to find the searchValue. 
        /// Notice that only works if the given array is sorted. 
        /// </summary>
        /// <param name="values">Specifies a sorted list of integers.</param>
        /// <param name="searchValue">Specifies the value the method is searching for. </param>
        /// <returns>The index of the searchValue in the array values, and -1 if it does not exist in the array, </returns>
        [Algorithm(AlgorithmType.Search, "JumpSearch")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "o(√n)")]
        [TimeComplexity(Case.Average, "O(√n)")]
        public static int Search(List<int> values, int searchValue)
        {
            if (searchValue < values[0] || searchValue > values[values.Count - 1]) // We can perform this check as the array is expected to be sorted. 
            {
                return -1;
            }

            int jumpStepLength = (int)Math.Floor(Math.Sqrt(values.Count));

            int nextIndex = 0;
            while (values[nextIndex] < searchValue)
            {
                nextIndex += jumpStepLength; // Jump forward
                if (nextIndex >= values.Count) { return -1; }
            }

            int linearSearchStartIndex = nextIndex - jumpStepLength; // Jump backward. 
            if (linearSearchStartIndex < 0)
            {
                return -1;
            }
            return LinearSearch.Search(values.GetRange(linearSearchStartIndex, nextIndex), searchValue);
        }

        // TODO: Write a recursive version as well. 
    }
}
