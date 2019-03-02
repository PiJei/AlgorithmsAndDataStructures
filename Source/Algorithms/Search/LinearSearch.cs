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

using System.Collections.Generic;
using CSFundamentals.Styling;

namespace CSFundamentals.Algorithms.Search
{
    /// <summary>
    /// Implements linear search, time complexity is O(N)
    /// </summary>
    public class LinearSearch
    {
        /// <summary>
        /// Searches for a given value in a list. 
        /// </summary>
        /// <param name="values">Specifies a list of integers.</param>
        /// <param name="searchValue">Specifies the value the method is searching for. </param>
        /// <returns>The index of the searchValue in the array values, and -1 if it does not exist in the array, </returns>
        [Algorithm(AlgorithmType.Search, "LinearSearch")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public static int Search(List<int> values, int searchValue)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == searchValue)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
