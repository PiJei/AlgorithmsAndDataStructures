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
using CSFundamentalAlgorithms.SearchingAlgorithms;
using System.Collections.Generic;

namespace CSFundamentalAlgorithmsTests.SearchingAlgorithmsTests
{
    [TestClass]
    public class InterpolationSearchTests
    {
        [TestMethod]
        public void InterpolationSearch_Search_Test()
        {
            List<int> values = new List<int> { 3, 7, 10, 14, 21, 27, 32, 38, 45, 53 };
            Assert.AreEqual(-1, InterpolationSearch.Search(values, 0, values.Count - 1, 200));
            Assert.AreEqual(9, InterpolationSearch.Search(values, 0, values.Count - 1, 53));
            Assert.AreEqual(-1, InterpolationSearch.Search(values, 0, values.Count - 1, -1));
            Assert.AreEqual(3, InterpolationSearch.Search(values, 0, values.Count - 1, 14));
            Assert.AreEqual(5, InterpolationSearch.Search(values, 0, values.Count - 1, 27));
            Assert.AreEqual(6, InterpolationSearch.Search(values, 0, values.Count - 1, 32));
            Assert.AreEqual(1, InterpolationSearch.Search(values, 0, values.Count - 1, 7));
            Assert.AreEqual(-1, InterpolationSearch.Search(values, 0, values.Count - 1, 4));
        }

        [TestMethod]
        public void InterpolationSearch_GetSearchStartingIndex_Test()
        {
            List<int> values = new List<int> { 3, 7, 10, 14, 21, 27, 32, 38, 45, 53 };

            Assert.AreEqual(35, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, 200));
            Assert.AreEqual(9, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, 53));
            Assert.AreEqual(0, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, -1));
            Assert.AreEqual(1, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, 14));
            Assert.AreEqual(4, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, 27));
            Assert.AreEqual(5, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, 32));
            Assert.AreEqual(0, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, 7));
            Assert.AreEqual(0, InterpolationSearch.GetSearchStartingIndex(values, 0, values.Count - 1, 4));
        }
    }
}
