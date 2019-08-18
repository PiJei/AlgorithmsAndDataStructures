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
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.Algorithms.PatternSearch
{
    /// <summary>
    /// Implements a naive (i.e. inefficient) algorithm for searching a (pattern) string in another string. 
    /// </summary>
    public class NaiveSearch
    {
        /// <summary>
        /// Implements a naive, brute force algorithm for finding <paramref name="pattern"/> in <paramref name="text"/>.
        /// Note: Any optimization over this algorithm, can try to reduce the length of the outer or inner loop.
        /// </summary>
        /// <param name= "text">The string in which <paramref name="pattern"/> is searched for.</param>
        /// <param name= "pattern">The string that is being searched in (<paramref name="text"/>).</param>
        /// <returns>The first index in <paramref name="text"/> starting from which a match for <paramref name="pattern"/> is found.</returns>
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
