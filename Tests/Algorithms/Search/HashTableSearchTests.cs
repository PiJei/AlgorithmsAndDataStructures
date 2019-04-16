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
using System.Linq;
using CSFundamentals.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//TODO: Unify similar to other searches, ... but first must make sure the algorithm is what we wanted, .. 

namespace CSFundamentalsTests.Algorithms.Search
{
    [TestClass]
    public class HashTableSearchTests
    {
        [TestMethod]
        public void Search()
        {
            var values = new List<int> { 1, 3, 10, 14, 25, 27, 34, 78, 90, 90, 120 };

            Assert.IsTrue(new List<int> { 0 }.SequenceEqual(HashTableSearch.Search(values, 1)));
            Assert.IsTrue(new List<int> { 1 }.SequenceEqual(HashTableSearch.Search(values, 3)));
            Assert.IsTrue(new List<int> { 2 }.SequenceEqual(HashTableSearch.Search(values, 10)));
            Assert.IsTrue(new List<int> { 3 }.SequenceEqual(HashTableSearch.Search(values, 14)));
            Assert.IsTrue(new List<int> { 4 }.SequenceEqual(HashTableSearch.Search(values, 25)));
            Assert.IsTrue(new List<int> { 5 }.SequenceEqual(HashTableSearch.Search(values, 27)));
            Assert.IsTrue(new List<int> { 6 }.SequenceEqual(HashTableSearch.Search(values, 34)));
            Assert.IsTrue(new List<int> { 7 }.SequenceEqual(HashTableSearch.Search(values, 78)));
            Assert.IsTrue(new List<int> { 8, 9 }.SequenceEqual(HashTableSearch.Search(values, 90)));
            Assert.IsTrue(new List<int> { 10 }.SequenceEqual(HashTableSearch.Search(values, 120)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(values, 15)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(values, -20)));
            Assert.IsTrue(new List<int> { }.SequenceEqual(HashTableSearch.Search(values, 456)));
        }
    }
}
