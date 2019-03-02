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

namespace CSFundamentals.Algorithms.PatternSearch
{
    public class NaiveSearch
    {
        /// <summary>
        /// Implements a naive- brute force algorithm for finding subString in text.
        /// Note: Any optimization, should try to reduce either the size of the outer loop or the inner loop.
        /// </summary>
        /// <param name="text">The parent string in which we are searching for a subString.</param>
        /// <param name="pattern">The string we want to find in parent string (text).</param>
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
