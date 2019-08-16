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
using AlgorithmsAndDataStructures.Algorithms.Sort;
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.DataStructures.StringStructures
{
    /// <summary>
    /// Implements SuffixArray data structure. A suffix array of an string is an array of integers that contains the starting index of all suffixes of the string in alphabetically sorted order. 
    /// For example for string 'data' , where suffixes are : 'data', 'ata', 'ta', 'a' the suffix array is [3, 1, 0, 2]
    /// </summary>
    [DataStructure("SuffixArray")]
    public class SuffixArray
    {
        /// <summary>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int[] Build(string text)
        {
            var suffixes = new List<StringSuffix>();
            for (int i = 0; i < text.Length; i++)
            {
                char firstChar = text[i];
                char secondChar = (i + 1) < text.Length ? text[i + 1] : '\0';
                suffixes.Add(new StringSuffix(i, firstChar, secondChar));
            }

            /* Sort suffixes using the first 2 characters. */
            MergeSort.Sort(suffixes, 0, suffixes.Count - 1);

            int[] indexes = new int[text.Length];
            /* Comparing suffixes based on the 4, 8, ... characters, ... */
            for (int k = 4; k < 2 * text.Length; k = k * 2)
            {
                int rank = suffixes[0].RankPair[0];
                suffixes[0].RankPair[0] = 0; /* reset the first rank of the first suffix in the list to zero. */
                indexes[suffixes[0].StartIndex] = 0;

                /* Update the first rank of all the suffixes, which depends on the ranks of their immediately preceding suffix. */
                for (int i = 1; i < text.Length; i++)
                {

                    if (suffixes[i].RankPair[0] == rank && suffixes[i].RankPair[1] == suffixes[i - 1].RankPair[1])
                    {
                        rank = suffixes[i].RankPair[0];
                        suffixes[i].RankPair[0] = suffixes[i - 1].RankPair[0];
                    }
                    else
                    {
                        rank = suffixes[i].RankPair[0];
                        suffixes[i].RankPair[0] = suffixes[i - 1].RankPair[0] + 1;
                    }

                    indexes[suffixes[i].StartIndex] = i;
                }

                /* Update the second rank of all the suffixes. */
                for (int i = 0; i < text.Length; i++)
                {
                    int nextIndex = k / 2 + suffixes[i].StartIndex;
                    if (nextIndex < text.Length)
                    {
                        suffixes[i].RankPair[1] = suffixes[indexes[nextIndex]].RankPair[0];
                    }
                    else
                    {
                        suffixes[i].RankPair[1] = -1;
                    }
                }

                MergeSort.Sort(suffixes, 0, suffixes.Count - 1);
            }

            int[] suffixArray = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                suffixArray[i] = suffixes[i].StartIndex;
            }

            return suffixArray;
        }
    }
}
