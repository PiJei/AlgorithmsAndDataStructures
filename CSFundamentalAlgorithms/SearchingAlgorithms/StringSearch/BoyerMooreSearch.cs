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

namespace CSFundamentalAlgorithms.SearchingAlgorithms.StringSearch
{
    public class BoyerMooreSearch
    {

        /// <summary>
        /// Maps every character in the given string to its last index in the string. 
        /// An example use is for bad character lookup in Boyer-Moore search algorithm.
        /// </summary>
        /// <returns>A mapping of all the characters in the given string to their last index in the string. </returns>
        public static Dictionary<char, int> MapCharToLastIndex(string text)
        {
            Dictionary<char, int> indexes = new Dictionary<char, int>();

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
