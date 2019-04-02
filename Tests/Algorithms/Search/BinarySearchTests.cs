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
using CSFundamentals.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Search
{
    [TestClass]
    public class BinarySearchTests
    {
        private List<int> _values = new List<int> { 1, 3, 10, 14, 25, 27, 34, 78, 90, 90, 120 };

        [TestMethod]
        public void Search_DistinctElementsInArray_ExpectsToSuccessfullyGetTheIndexOfTheirPosition()
        {
            Assert.AreEqual(0, BinarySearch.Search(_values, 0, _values.Count - 1, 1));
            Assert.AreEqual(1, BinarySearch.Search(_values, 0, _values.Count - 1, 3));
            Assert.AreEqual(2, BinarySearch.Search(_values, 0, _values.Count - 1, 10));
            Assert.AreEqual(3, BinarySearch.Search(_values, 0, _values.Count - 1, 14));
            Assert.AreEqual(4, BinarySearch.Search(_values, 0, _values.Count - 1, 25));
            Assert.AreEqual(5, BinarySearch.Search(_values, 0, _values.Count - 1, 27));
            Assert.AreEqual(6, BinarySearch.Search(_values, 0, _values.Count - 1, 34));
            Assert.AreEqual(7, BinarySearch.Search(_values, 0, _values.Count - 1, 78));
            Assert.AreEqual(10, BinarySearch.Search(_values, 0, _values.Count - 1, 120));
        }

        [TestMethod]
        public void Search_DuplicateElementsInArray_ExpectsToSuccessfullyGetTheIndexOfTheirFirstOccurrence()
        {
            Assert.AreEqual(8, BinarySearch.Search(_values, 0, _values.Count - 1, 90));
            Assert.AreEqual(8, BinarySearch.Search(_values, 0, _values.Count - 1, 90));
        }

        [TestMethod]
        public void Search_NonExistingElements_ExpectsToGetMinusOne()
        {
            Assert.AreEqual(-1, BinarySearch.Search(_values, 0, _values.Count - 1, -20));
            Assert.AreEqual(-1, BinarySearch.Search(_values, 0, _values.Count - 1, 15));
            Assert.AreEqual(-1, BinarySearch.Search(_values, 0, _values.Count - 1, 456));
        }
    }
}
