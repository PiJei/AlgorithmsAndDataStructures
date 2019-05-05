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
using System.Collections.Generic;
using CSFundamentals.DataStructures.StringStructures;
using CSFundamentals.Decoration;

namespace CSFundamentals.Algorithms.PatternSearch
{
    /// <summary>
    /// Implements Knuth-Morris-Pratt algorithm for searching a (pattern) string in another string. 
    /// </summary>
    public class KMPSearch
    {
        /// <summary>
        /// Implements Knuth-Morris-Pratt algorithm to search for all the occurrences of <paramref name="pattern"/> in <paramref name="text"/>.
        /// Uses proper prefixes, and requires preprocessing of <paramref name="pattern"/>.
        /// The idea while searching for <paramref name="pattern"/> in <paramref name="text"/>, is that the algorithm has already 'seen' some characters in <paramref name="text"/>, so it should not check again whether those characters match substrings of <paramref name="pattern"/>.
        /// Compared to <see cref="NaiveSearch"/>, where at each internal iteration, j (iterator over <paramref name="pattern"/>) is reset to zero, here j is not reset to zero always. The value j is set to, depends on its prefixes. 
        /// </summary>
        /// <param name= "text">The string in which <paramref name="pattern"/> is searched for.</param>
        /// <param name= "pattern">The string that is being searched in (<paramref name="text"/>).</param>
        /// <returns>All the indexes in <paramref name="text"/> starting from which a match for <paramref name="pattern"/> is found.</returns>
        [Algorithm(AlgorithmType.PatternSearch, "KMP-KnuthMorrisPratt")]
        public static List<int> Search(string text, string pattern)
        {
            /* Starts with a preprocessing step. Get the data structure for longest proper prefix that is also a suffix. */
            List<int> longestProperPrefixLengths = LLPPS.Build(pattern);

            var indexes = new List<int>();

            int i = 0; /* Index to navigate over text */
            int j = 0; /* Index to navigate over pattern*/

            while (i < text.Length)
            {
                if (text[i] == pattern[j]) /* When there is a match*/
                {
                    i++; /* Continue incrementing i and j as long as characters match. */
                    j++;

                    if (j == pattern.Length) /* Means pattern is matched with text [i-pattern.Length, i-1]*/
                    {
                        indexes.Add(i - pattern.Length);

                        /* Since we are after all occurrences of pattern, continue by changing j (in naive approach after each match, this would be set to zero. )*/
                        j = longestProperPrefixLengths[j - 1]; /* Label (A) */
                    }
                }
                else  /* When there is a mismatch, stop and go backward in pattern. Note: always going forward in the text (main string) */
                {
                    if (j == 0) /* means we have navigated backward so much that j is reset to zero at this stage [reset to naive approach], and a one-to-one sequential search of pattern in text, starting at index i, starts again. */
                    {
                        i++;
                    }
                    else
                    {
                        j = longestProperPrefixLengths[j - 1]; /* Label (B)  == Label (A) */
                    }
                }
            }

            return indexes;
        }
    }
}
