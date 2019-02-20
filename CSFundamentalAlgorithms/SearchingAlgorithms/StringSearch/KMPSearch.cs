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
using System.Linq;

namespace CSFundamentalAlgorithms.SearchingAlgorithms.StringSearch
{
    public class KMPSearch
    {
        /// <summary>
        /// Implements KMP search = Knuth-Morris-Pratt algorithm for searching a substring in a string, using proper prefixes, and preprocessing of the subString.. 
        /// The idea: while searching for the subString in text, we already 'have seen' some characters in text, so shall not re-check if they match with parts of the subString.
        /// When compared to Naive algorithm, whereas at each internal iteration, we rest j to zero, here we do not always reset j to zero, the value j gets set to depends on its prefixes. 
        /// </summary>
        /// <param name= "text">The parent string in which we are searching for a subString.</param>
        /// <param name= "subString">The string we want to find in parent string (text).</param>
        /// <returns>All the starting index in text at which subString is found [in other words looks for all the occurrences of the subString in text, and does not stop by finding the first one.].</returns>
        public static List<int> Search(string text, string subString)
        {
            /* Starts with a preprocessing step.*/
            List<int> longestProperPrefixLengths = GetLongestProperPrefixWhichIsAlsoSuffix(subString);

            List<int> indexes = new List<int>();

            int i = 0; /* Index to navigate over text */
            int j = 0; /* Index to navigate over subString*/

            while (i < text.Length)
            {
                if (text[i] == subString[j])
                {
                    i++; /* Continue incrementing i and j as long as characters match. */
                    j++;

                    if (j == subString.Length) /* Means subString is matched with text [i-subString.Length, i-1]*/
                    {
                        indexes.Add(i - subString.Length);

                        /* Since we are after all occurrences of subString continue by changing j (in naive approach after each match, this would be set to zero. )*/
                        j = longestProperPrefixLengths[j - 1]; /* Label (A) */
                    }
                }
                else if (text[i] != subString[j]) /* When there is a mismatch stop and go backward in subString. */
                {
                    if (j != 0)
                    {
                        j = longestProperPrefixLengths[j - 1]; /* Label (B)  == Label (A) */
                    }
                    else /* j is reset to zero at this stage, and a one-to-one sequential search of subString in text, starting at index i, starts again. */
                    {
                        i++;
                    }
                }
            }

            return indexes;
        }

        /// <summary>
        /// For each sub pattern in text, ending at position (i)-0-based, computes the length of the longest proper prefix of text[0:i] such that it is also a suffix of text[0:i]
        /// All proper prefixes of text[0:i] must start at index 0, and must end at most at index i-1.
        /// All suffixes of text[0:i] must end at index i, and must start at least at index 0. 
        /// A proper prefix of a string is any prefix that is not equal to the string itself. for example for string = kmp: '', k, km are 3 proper prefixes. Note that they all start at index 0 
        /// A suffix of a string is any suffix. For example for string kmp: p, mp, kmp, '' are 4 suffixes. All end at index 2 . m is not a suffix. 
        /// </summary>
        /// <param name="text">Specifies the string for which we want to compute its longest proper prefixes that are also suffixes. </param>
        /// <returns> An array of longest proper prefixes</returns>
        public static List<int> GetLongestProperPrefixWhichIsAlsoSuffix(string text)
        {
            List<int> longestProperPrexiLengths = Enumerable.Repeat(0, text.Length).ToList(); /* Note that the values in this list, are < text.Length always. */

            int lengthOfPreviousProperPrefixThatIsAlsoSuffix = 0;

            int i = 1; /* longestProperPrexiLengths[0] will always be zero, based on the definition of proper prefix. */
            while (i < text.Length)
            {
                if (text[i] == text[lengthOfPreviousProperPrefixThatIsAlsoSuffix]) /* Means, advance the previous proper prefix by one index (still this index < i) and compare it to the character at i, if they are equal means the length of the proper prefix can increase by one. */
                {
                    lengthOfPreviousProperPrefixThatIsAlsoSuffix++;
                    longestProperPrexiLengths[i] = lengthOfPreviousProperPrefixThatIsAlsoSuffix;
                    i++;
                }
                else /* Means the length of the proper prefix can not grow, and thus we should go backward till we find a proper prefix that is also a suffix.*/
                {
                    if (lengthOfPreviousProperPrefixThatIsAlsoSuffix == 0) // an example would be ABCD, where no character had a proper prefix so far, all set to zero
                    {
                        longestProperPrexiLengths[i] = 0;
                        i++;
                    }
                    else
                    {
                        lengthOfPreviousProperPrefixThatIsAlsoSuffix = longestProperPrexiLengths[lengthOfPreviousProperPrefixThatIsAlsoSuffix - 1];
                        /* Do not increment i, because we should keep navigating backward till we find a proper prefix that is also a suffix. or get to a point where the length reaches 0, and then we set the length of proper prefix for a text ending at i, also to zero, which means we could not find any sub pattern starting at index 0, that could also be a suffix for text ending at i.*/
                    }
                }
            }

            return longestProperPrexiLengths;
        }
    }
}
