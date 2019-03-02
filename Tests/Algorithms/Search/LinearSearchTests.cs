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
using CSFundamentals.Algorithms.Search;
using System.Collections.Generic;

namespace CSFundamentalsTests.Search
{
    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void LinearSearch_Search_Test()
        {
            List<int> values = new List<int> { 4, 1, 9, 100, 3, 2, 45, 37, 3 };
            Assert.AreEqual(-1, LinearSearch.Search(values, 200));
            Assert.AreEqual(4, LinearSearch.Search(values, 3));
            Assert.AreEqual(0, LinearSearch.Search(values, 4));
            Assert.AreEqual(7, LinearSearch.Search(values, 37));
        }
    }
}
