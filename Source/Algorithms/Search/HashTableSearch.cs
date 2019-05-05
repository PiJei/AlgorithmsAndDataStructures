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
using System;
using System.Collections.Generic;
using CSFundamentals.Decoration;

// TODO: Re-implement with a better understanding of key values (int, string)
// TODO: Make generic
namespace CSFundamentals.Algorithms.Search
{
    /// <summary>
    /// Implements search using a hash table. Search algorithm is for finding a specific value in an array.
    /// </summary>
    public class HashTableSearch
    {
        /// <summary>
        /// Implements search using a hash table. 
        /// </summary>
        /// <param name="list">A list of any comparable type.</param>
        /// <param name="key">The value the method is searching for. </param>
        /// <returns>The list of all the indexes in the array that have <paramref name="key"/>. </returns>
        [Algorithm(AlgorithmType.Search, "HashTable")]
        [SpaceComplexity("O(n)", InPlace = false)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "All the elements are mapped to the same key (for example due to lots of conflicts in the hashing method).")]
        [TimeComplexity(Case.Average, "O(1)")]
        public static List<int> Search<T>(List<T> list, T key) where T : IComparable<T>
        {
            Dictionary<T, List<int>> hashTable = ConvertList2HashTable(list);
            if (hashTable.ContainsKey(key)) //todo: sHOULD USE my own contains... 
            {
                return hashTable[key];
            }
            return new List<int> { };
        }

        private static Dictionary<T, List<int>> ConvertList2HashTable<T>(List<T> values) where T : IComparable<T>
        {
            var hashTable = new Dictionary<T, List<int>>();
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
