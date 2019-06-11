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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AlgorithmsAndDataStructures.Decoration;

[assembly: InternalsVisibleTo("CSFundamentalAlgorithmsTests")]

namespace AlgorithmsAndDataStructures.Algorithms.PatternSearch
{
    /// <summary>
    /// Implements Boyer-More algorithm for searching a (pattern) string in another string. 
    /// </summary>
    public class BoyerMooreSearch
    {
        /// <summary>
        /// Implements BoyerMoore search algorithm to search for all the occurrences of <paramref name="pattern"/> in <paramref name="text"/>.
        /// The idea is to only use the bad character heuristic, to do tail based search, and skip over indexes in <paramref name="text"/> to a proper tail, at which there is a chance of match. 
        /// </summary>
        /// <remarks>
        /// In other versions both bad character heuristic and good suffix are used to skip over <paramref name="text"/>.
        /// </remarks>
        /// <param name= "text">The string in which <paramref name="pattern"/> is searched for.</param>
        /// <param name= "pattern">The string that is being searched in (<paramref name="text"/>).</param>
        /// <returns>All the indexes in <paramref name="text"/> starting from which a match for <paramref name="pattern"/> is found.</returns>
        [Algorithm(AlgorithmType.PatternSearch, "BoyerMoore")]
        public static List<int> Search(string text, string pattern)
        {
            var indexes = new List<int>();

            /* For readability in the code: */
            int n = text.Length;
            int m = pattern.Length;

            /* Preprocessing step for pattern */
            Dictionary<char, int> patternMap = MapCharToLastIndex(pattern); /* Last index is needed, because otherwise if shifted the pattern along the text to right a lot (with the first index) some potential matches could be missed. */

            int i = m - 1;  /* Is the index over text. Setting to (m-1) because BoyerMoore is tail-based search. */

            while (i < n) /* Since this is a tail-based search, i can even be (n-1), hence the loop condition.*/
            {
                int j = m - 1; /* Starting index over pattern, notice that the algorithm matches the string backwards.*/
                while (j >= 0 && i >= 0 && text[i] == pattern[j]) /* Continue moving backward on pattern and text as long as the characters match.*/
                {
                    j--;
                    i--;
                }

                if (j < 0) /* this means a match is found. */
                {
                    /*At this point i has gone backward such that it is set to the (matched-index - 1), so adjust it to point to matched-index. */
                    i += 1;

                    /* Store i, as one of the answers, starting from which a match for pattern is found. */
                    indexes.Add(i);

                    /* Compute the potential new tail index on text.*/
                    int indexOfNextUnVisitedCharOnText = i + m;

                    /* Shift i forward. */
                    i = indexOfNextUnVisitedCharOnText;

                    /* See if index i can be shifted forward even more, meaning the algorithm can skip some characters over text. */
                    if (i < n) /* Get the next unseen character in text*/
                    {
                        char nextUnVisitedCharOnText = text[i]; /* This can also be a bad character, if it does not exist in the map, and should be skipped. */
                        int lastIndexOfNextCharInPattern = patternMap.ContainsKey(nextUnVisitedCharOnText) ? patternMap[nextUnVisitedCharOnText] : -1;

                        /* Shift i further by length of pattern, as the search is tail based. */
                        i += ((m - 1) - lastIndexOfNextCharInPattern);
                    }
                    else
                    {
                        break;
                    }
                }
                else /* this means a bad character is observed in text. The mismatched character in text is called a BadCharacter */
                {
                    // text[i] is the bad character.
                    char badChar = text[i];
                    int lastIndexOfBadCharInPattern = patternMap.ContainsKey(badChar) ? patternMap[badChar] : -1;
                    i += ((m - 1) - lastIndexOfBadCharInPattern); /* Notice that the text[i] in the next round will be compared to pattern[m-1], that is why i should be slided by this much to point to tail of the pattern in text. */
                }
            }

            return indexes;
        }

        /// <summary>
        /// Maps every character in <paramref name="text"/> to the last index it appears at. 
        /// An example use-case is <see cref="BoyerMooreSearch"/> algorithm.
        /// </summary>
        /// <param name= "text">A string value.</param>
        /// <returns>A mapping of all the characters in <paramref name="text"/> to their last index. </returns>
        internal static Dictionary<char, int> MapCharToLastIndex(string text)
        {
            var indexes = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (indexes.ContainsKey(text[i]))
                {
                    indexes[text[i]] = i;
                }
                else
                {
                    indexes.Add(text[i], i);
                }
            }
            return indexes;
        }
    }
}
