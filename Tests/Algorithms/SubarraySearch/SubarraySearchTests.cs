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
using AlgorithmsAndDataStructures.Algorithms.SubarraySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.SubarraySearch
{
    /// <summary>
    /// Tests methods in <see cref="SubarraySearch"/> class. 
    /// </summary>
    [TestClass]
    public class SubarraySearchTests
    {
        /// <summary>
        /// Tests the correctness of checking whether a sublist exists continuously in another list. 
        /// </summary>
        [TestMethod]
        public void Search_NaiveContiguousSublist()
        {
            Assert.IsTrue(Naive.Search_NaiveContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 7 }));
            Assert.IsFalse(Naive.Search_NaiveContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 8 }));
            Assert.IsFalse(Naive.Search_NaiveContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 80 }));
            Assert.IsTrue(Naive.Search_NaiveContiguousSublist(new List<int> { 1, 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 7 }));
            Assert.IsTrue(Naive.Search_NaiveContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { }));
            Assert.IsFalse(Naive.Search_NaiveContiguousSublist(new List<int> { }, new List<int> { }));
        }

        /// <summary>
        /// Tests the correctness of checking whether a sublist exists in another list non-continuously. 
        /// </summary>
        [TestMethod]
        public void Search_UnContiguousSublist()
        {
            Assert.IsTrue(Naive.Search_UnContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 7 }));
            Assert.IsTrue(Naive.Search_UnContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 8 }));
            Assert.IsFalse(Naive.Search_UnContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 80 }));
            Assert.IsTrue(Naive.Search_UnContiguousSublist(new List<int> { 1, 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 7 }));
            Assert.IsTrue(Naive.Search_UnContiguousSublist(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { }));
            Assert.IsTrue(Naive.Search_UnContiguousSublist(new List<int> { }, new List<int> { }));
            Assert.IsFalse(Naive.Search_UnContiguousSublist(new List<int> { }, new List<int> { 1 }));
        }
    }
}
