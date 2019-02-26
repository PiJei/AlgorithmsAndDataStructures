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
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using CSFundamentalAlgorithms.StringDataStructures;

namespace CSFundamentalAlgorithms.PatternSearch
{
    public class KMPSearch
    {
        /// <summary>
        /// Implements KMP search = Knuth-Morris-Pratt algorithm for searching a substring in a string, using proper prefixes, and preprocessing of the subString.. 
        /// The idea: while searching for the subString in text, we already 'have seen' some characters in text, so shall not re-check if they match with parts of the subString.
        /// When compared to Naive algorithm, whereas at each internal iteration, we rest j to zero, here we do not always reset j to zero, the value j gets set to depends on its prefixes. 
        /// </summary>
        /// <param name= "text">The parent string in which we are searching for a subString.</param>
        /// <param name= "pattern">The string we want to find in parent string (text).</param>
        /// <returns>All the starting index in text at which subString is found [in other words looks for all the occurrences of the subString in text, and does not stop by finding the first one.].</returns>
        [Algorithm("PatternSearch", "KMP-KnuthMorrisPratt")]
        public static List<int> Search(string text, string pattern)
        {
            /* Starts with a preprocessing step. Get the data structure for longest proper prefix that is also a suffix. */
            List<int> longestProperPrefixLengths = LLPPS.Build(pattern);

            List<int> indexes = new List<int>();

            int i = 0; /* Index to navigate over text */
            int j = 0; /* Index to navigate over subString*/

            while (i < text.Length)
            {
                if (text[i] == pattern[j]) /* When there is a match*/
                {
                    i++; /* Continue incrementing i and j as long as characters match. */
                    j++;

                    if (j == pattern.Length) /* Means subString is matched with text [i-subString.Length, i-1]*/
                    {
                        indexes.Add(i - pattern.Length);

                        /* Since we are after all occurrences of subString continue by changing j (in naive approach after each match, this would be set to zero. )*/
                        j = longestProperPrefixLengths[j - 1]; /* Label (A) */
                    }
                }
                else  /* When there is a mismatch, stop and go backward in subString. Note: always going forward in the text (main string) */
                {
                    if (j == 0) /* means we have navigated backward so much that j is reset to zero at this stage [reset to naive approach], and a one-to-one sequential search of subString in text, starting at index i, starts again. */
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
