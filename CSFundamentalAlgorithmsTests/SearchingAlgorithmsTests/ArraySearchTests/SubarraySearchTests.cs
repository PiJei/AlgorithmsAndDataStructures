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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentalAlgorithms.SearchingAlgorithms.ArraySearch;
using System.Collections.Generic;

namespace CSFundamentalAlgorithmsTests.SearchingAlgorithmsTests.ArraySearchTests
{
    [TestClass]
    public class SubarraySearchTests
    {
        [TestMethod]
        public void SubarraySearch_Search_Test()
        {
            Assert.IsTrue(SubarraySearch.Search_ContiguousChild(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 7 }));
            Assert.IsFalse(SubarraySearch.Search_ContiguousChild(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 8 }));
            Assert.IsFalse(SubarraySearch.Search_ContiguousChild(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 80 }));
            Assert.IsTrue(SubarraySearch.Search_ContiguousChild(new List<int> { 1, 10, 3, 4, 1, 7, 8 }, new List<int> { 1, 7 }));
            Assert.IsTrue(SubarraySearch.Search_ContiguousChild(new List<int> { 10, 3, 4, 1, 7, 8 }, new List<int> { }));
            Assert.IsFalse(SubarraySearch.Search_ContiguousChild(new List<int> { }, new List<int> { }));
        }
    }
}
