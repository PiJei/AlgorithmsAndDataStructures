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
using CSFundamentals.Decoration;

namespace CSFundamentals.Algorithms.PatternSearch
{
    /// <summary>
    /// Implements a naive simple algorithm for searching a pattern string in a string. 
    /// </summary>
    public class NaiveSearch
    {
        /// <summary>
        /// Implements a naive, brute force algorithm for finding <paramref name="pattern"/> in <paramref name="text"/>.
        /// Note: Any optimization over this algorithm, can try to reduce either the size of the outer loop or the inner loop.
        /// </summary>
        /// <param name="text">The string in which we are searching for <paramref name="pattern"/>.</param>
        /// <param name="pattern">The string we want to find in <paramref name="text"/>.</param>
        [Algorithm(AlgorithmType.PatternSearch, "Naive")]
        public static int Search(string text, string pattern)
        {
            for (int i = 0; i < text.Length; i++)
            {
                int searchStartIndex = i;
                bool found = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if ((searchStartIndex + j) >= text.Length)
                    {
                        found = false;
                        break;
                    }
                    if (text[searchStartIndex + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
