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
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    /// <summary>
    /// Implements search using a hash table. Search algorithm is for finding a specific value in a list.
    /// </summary>
    public class HashTableSearch
    {
        /// <summary>
        /// Implements search using a hash table. 
        /// </summary>
        /// <param name="list">A list of any comparable type.</param>
        /// <param name="key">The value the method is searching for. </param>
        /// <returns>The list of all the indexes in the list that have <paramref name="key"/>. </returns>
        [Algorithm(AlgorithmType.Search, "HashTable")]
        [SpaceComplexity("O(n)", InPlace = false)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "All the elements are mapped to the same key (for example due to lots of conflicts in the hashing method).")]
        [TimeComplexity(Case.Average, "O(1)")]
        public static List<int> Search<T>(List<T> list, T key) where T : IComparable<T>
        {
            Dictionary<int, List<int>> hashTable = ConvertList2HashTable(list);
            int keyHash = key.GetHashCode();
            if (hashTable.ContainsKey(keyHash))
            {
                return hashTable[keyHash];
            }
            return new List<int> { };
        }

        /// <summary>
        /// Creates a hash table for the given list. The keys are hashes of the elements in the list and th
        /// </summary>e value for each hash key is the list of indexes over the main list. 
        /// <typeparam name="T">Type of the values stored in list.</typeparam>
        /// <param name="list">A list of elements. </param>
        /// <returns>A hash table of elements hashes to their indexes in the list.</returns>
        public static Dictionary<int, List<int>> ConvertList2HashTable<T>(List<T> list) where T : IComparable<T>
        {
            var hashTable = new Dictionary<int, List<int>>();
            for (int i = 0; i < list.Count; i++)
            {
                int hash = list[i].GetHashCode();
                if (!hashTable.ContainsKey(hash))
                {
                    hashTable.Add(hash, new List<int> { i });
                }
                else
                {
                    hashTable[hash].Add(i);
                }
            }
            return hashTable;
        }
    }
}
