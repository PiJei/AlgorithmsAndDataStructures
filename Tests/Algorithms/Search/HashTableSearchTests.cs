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
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.Algorithms.Search
{
    /// <summary>
    /// Tests methods in <see cref="HashTableSearch"/> class. 
    /// </summary>
    [TestClass]
    public class HashTableSearchTests
    {
        private readonly static List<int> _list = new List<int> { 27, 1, 120, 10, 3, 90, 25, 14, 1, 34, 90, 78 };

        /// <summary>
        /// Tests the correctness of search algorithm. 
        /// </summary>
        /// To visualize step by step how HashTable Search finds a distinct element (int value of 3) in <see cref="_list"/> see: <img src = "../Images/Search/HashTableSearch-Distinct.png"/>.
        [TestMethod]
        public void Search_DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition()
        {
            Assert.IsTrue(new List<int> { 4 }.SequenceEqual(HashTableSearch.Search(_list, 3)));
            Assert.IsTrue(new List<int> { 3 }.SequenceEqual(HashTableSearch.Search(_list, 10)));
            Assert.IsTrue(new List<int> { 7 }.SequenceEqual(HashTableSearch.Search(_list, 14)));
            Assert.IsTrue(new List<int> { 6 }.SequenceEqual(HashTableSearch.Search(_list, 25)));
            Assert.IsTrue(new List<int> { 0 }.SequenceEqual(HashTableSearch.Search(_list, 27)));
            Assert.IsTrue(new List<int> { 9 }.SequenceEqual(HashTableSearch.Search(_list, 34)));
            Assert.IsTrue(new List<int> { 11 }.SequenceEqual(HashTableSearch.Search(_list, 78)));
            Assert.IsTrue(new List<int> { 2 }.SequenceEqual(HashTableSearch.Search(_list, 120)));
        }

        /// <summary>
        /// Tests the correctness of HashTable search algorithm on an array with duplicate elements. 
        /// To visualize step by step how HashTable Search finds a duplicate element (int value of 90) in <see cref="_list"/> see: <img src = "../Images/Search/HashTableSearch-Duplicate.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DuplicateElements_ExpectsToGetTheIndexOfTheFirstOccurrenceNoMatterHowManyTimesSearchIsPerformed()
        {
            Assert.IsTrue(new List<int> { 1, 8 }.SequenceEqual(HashTableSearch.Search(_list, 1)));
            Assert.IsTrue(new List<int> { 5, 10 }.SequenceEqual(HashTableSearch.Search(_list, 90)));
        }

        /// <summary>
        /// Tests the correctness of HashTable search algorithm when the key does not exist in the array. 
        /// To visualize step by step how HashTable Search terminates without finding a missing element (int value of 15) in <see cref="_list"/> see: <img src = "../Images/Search/HashTableSearch-Missing.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_NonExistingElements_ExpectsToGetMinusOne()
        {
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(_list, 15)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(_list, -20)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(_list, 456)));
        }
        /// <summary>
        /// Tests the correctness of the method that generates a hash table over a list. 
        /// </summary>
        [TestMethod]
        public void ConvertList2HashTable_CheckingTheCorrectnesOfHashTable()
        {
            Dictionary<int, List<int>> hashTable = HashTableSearch.ConvertList2HashTable(_list);
            Assert.AreEqual(10, hashTable.Keys.Count);
            int hashKey1 = 1.GetHashCode();
            Assert.IsTrue(new List<int> { 1 , 8}.SequenceEqual(hashTable[hashKey1]));
        }
    }
}
