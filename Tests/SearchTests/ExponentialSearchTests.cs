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
using CSFundamentals.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalAlgorithmsTests.SearchTests
{
    [TestClass]
    public class ExponentialSearchTests
    {
        [TestMethod]
        public void ExponentialSearch_Search_Test()
        {
            List<int> values = new List<int> { 1, 3, 10, 14, 25, 27, 34, 78, 90, 90, 120 };

            Assert.AreEqual(0, ExponentialSearch.Search(values, 1));
            Assert.AreEqual(1, ExponentialSearch.Search(values, 3));
            Assert.AreEqual(2, ExponentialSearch.Search(values, 10));
            Assert.AreEqual(3, ExponentialSearch.Search(values, 14));
            Assert.AreEqual(4, ExponentialSearch.Search(values, 25));
            Assert.AreEqual(5, ExponentialSearch.Search(values, 27));
            Assert.AreEqual(6, ExponentialSearch.Search(values, 34));
            Assert.AreEqual(7, ExponentialSearch.Search(values, 78));
            Assert.AreEqual(8, ExponentialSearch.Search(values, 90));
            Assert.AreEqual(8, ExponentialSearch.Search(values, 90));
            Assert.AreEqual(10, ExponentialSearch.Search(values, 120));
            Assert.AreEqual(-1, ExponentialSearch.Search(values, -20));
            Assert.AreEqual(-1, ExponentialSearch.Search(values, 15));
            Assert.AreEqual(-1, ExponentialSearch.Search(values, 456));
        }
    }
}
