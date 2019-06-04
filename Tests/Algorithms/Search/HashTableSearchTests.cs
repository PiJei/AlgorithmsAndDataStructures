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
using System.Collections.Generic;
using System.Linq;
using CSFundamentals.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//TODO: Unify similar to other searches, ... but first must make sure the algorithm is what we wanted, .. 

namespace CSFundamentalsTests.Algorithms.Search
{
    /// <summary>
    /// Tests methods in <see cref="HashTableSearch"/> class. 
    /// </summary>
    [TestClass]
    public class HashTableSearchTests
    {
        /// <summary>
        /// Tests the correctness of search algorithm. 
        /// </summary>
        [TestMethod]
        public void Search()
        {
            var list = new List<int> { 27, 1, 120, 10, 3, 90, 25, 14, 1, 34, 90, 78 };

            Assert.IsTrue(new List<int> { 1, 8 }.SequenceEqual(HashTableSearch.Search(list, 1)));
            Assert.IsTrue(new List<int> { 4 }.SequenceEqual(HashTableSearch.Search(list, 3)));
            Assert.IsTrue(new List<int> { 3 }.SequenceEqual(HashTableSearch.Search(list, 10)));
            Assert.IsTrue(new List<int> { 7 }.SequenceEqual(HashTableSearch.Search(list, 14)));
            Assert.IsTrue(new List<int> { 6 }.SequenceEqual(HashTableSearch.Search(list, 25)));
            Assert.IsTrue(new List<int> { 0 }.SequenceEqual(HashTableSearch.Search(list, 27)));
            Assert.IsTrue(new List<int> { 9 }.SequenceEqual(HashTableSearch.Search(list, 34)));
            Assert.IsTrue(new List<int> { 11 }.SequenceEqual(HashTableSearch.Search(list, 78)));
            Assert.IsTrue(new List<int> { 5, 10 }.SequenceEqual(HashTableSearch.Search(list, 90)));
            Assert.IsTrue(new List<int> { 2 }.SequenceEqual(HashTableSearch.Search(list, 120)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(list, 15)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(list, -20)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(list, 456)));
        }

        /// <summary>
        /// Tests the correctness of the method that generates a hash table over a list. 
        /// </summary>
        [TestMethod]
        public void ConvertList2HashTable_CheckingTheCorrectnesOfHashTable()
        {
            var list = new List<int> { 27, 1, 120, 10, 3, 90, 25, 14, 1, 34, 90, 78 };
            Dictionary<int, List<int>> hashTable = HashTableSearch.ConvertList2HashTable(list);
            Assert.AreEqual(10, hashTable.Keys.Count);
            int hashKey1 = 1.GetHashCode();
            Assert.IsTrue(new List<int> { 1 , 8}.SequenceEqual(hashTable[hashKey1]));
        }
    }
}
