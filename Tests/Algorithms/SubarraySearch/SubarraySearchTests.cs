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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.Algorithms.SubarraySearch;
using System.Collections.Generic;

namespace CSFundamentalsTests.SubarraySearch
{
    [TestClass]
    public class SubarraySearchTests
    {
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
