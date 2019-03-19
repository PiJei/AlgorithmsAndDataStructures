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

using System.Collections.Generic;
using CSFundamentals.Styling;

//TODO: Re-implement with a better understanding of key values (int, string)
namespace CSFundamentals.Algorithms.Search
{
    public class HashTableSearch
    {
        /// <summary>
        /// Implements search using a hash table. 
        /// </summary>
        /// <param name="values">Specifies a list of integers.</param>
        /// <param name="searchValue">Specifies the value the method is searching for. </param>
        /// <returns>The list of all the indexes in the array that have <paramref name="searchValue">. </returns>
        [Algorithm(AlgorithmType.Search, "HashTable")]
        [SpaceComplexity("O(n)", InPlace = false)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "All the elements are mapped to the same key (for example due to lots of conflicts in the hashing method).")]
        [TimeComplexity(Case.Average, "O(1)")]
        public static List<int> Search(List<int> values, int searchValue)
        {
            Dictionary<int, List<int>> hashTable = ConvertList2HashTable(values);
            if (hashTable.ContainsKey(searchValue))
            {
                return hashTable[searchValue];
            }
            return new List<int> { };
        }

        private static Dictionary<int, List<int>> ConvertList2HashTable(List<int> values)
        {
            Dictionary<int, List<int>> hashTable = new Dictionary<int, List<int>>();
            for (int i = 0; i < values.Count; i++)
            {
                if (!hashTable.ContainsKey(values[i]))
                {
                    hashTable.Add(values[i], new List<int> { i });
                }
                else
                {
                    hashTable[values[i]].Add(i);
                }
            }
            return hashTable;
        }
    }
}
