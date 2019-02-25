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
using System;
// TODO: Add a linear implementation of suffix array. 

namespace CSFundamentalAlgorithms.StringDataStructures
{
    /// <summary>
    /// Implements SuffixArray data structure. A suffix array of an string is an array of integers that contains the starting index of all suffixes of the string in alphabetically sorted order. 
    /// For example for string 'data' , where suffixes are : 'data', 'ata', 'ta', 'a' the suffix array is [3, 1, 0, 2]
    /// </summary>
    [DataStructure("SuffixArray")]
    public class SuffixArray
    {
        public List<int> Build(string text)
        {
            List<int> suffixArray = new List<int>(); // length is text.Length

            List<StringSuffix> suffixes = new List<StringSuffix>();
            for (int i = 0; i < text.Length; i++)
            {
                char firstChar = text[i];
                char secondChar = (i + 1) < text.Length ? text[i + 1] : '\0';
                suffixes.Add(new StringSuffix(i, firstChar, secondChar));
            }

            return suffixArray;
        }
    }
}
