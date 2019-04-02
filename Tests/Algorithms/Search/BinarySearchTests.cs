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
        /// <summary>
        /// Sorted array of elements, Note that binary Search expects a sorted array. 
        /// </summary>
        private List<int> _values = new List<int> { 1, 3, 10, 14, 25, 27, 34, 78, 90, 90, 120 };
        private int _startIndex;
        private int _endIndex;

        [TestInitialize]
        public void Init()
        {
            _startIndex = 0;
            _endIndex = _values.Count - 1;
        }

        [TestMethod]
        public void Search_DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition()
        {
            Assert.AreEqual(0, BinarySearch.Search(_values, _startIndex, _endIndex, 1));
            Assert.AreEqual(1, BinarySearch.Search(_values, _startIndex, _endIndex, 3));
            Assert.AreEqual(2, BinarySearch.Search(_values, _startIndex, _endIndex, 10));
            Assert.AreEqual(3, BinarySearch.Search(_values, _startIndex, _endIndex, 14));
            Assert.AreEqual(4, BinarySearch.Search(_values, _startIndex, _endIndex, 25));
            Assert.AreEqual(5, BinarySearch.Search(_values, _startIndex, _endIndex, 27));
            Assert.AreEqual(6, BinarySearch.Search(_values, _startIndex, _endIndex, 34));
            Assert.AreEqual(7, BinarySearch.Search(_values, _startIndex, _endIndex, 78));
            Assert.AreEqual(10, BinarySearch.Search(_values, _startIndex, _endIndex, 120));
        }

        [TestMethod]
        public void Search_DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed()
        {
            Assert.AreEqual(8, BinarySearch.Search(_values, _startIndex, _endIndex, 90));
            Assert.AreEqual(8, BinarySearch.Search(_values, _startIndex, _endIndex, 90));
        }

        [TestMethod]
        public void Search_NonExistingElements_ExpectsToGetMinusOne()
        {
            Assert.AreEqual(-1, BinarySearch.Search(_values, _startIndex, _endIndex, -20));
            Assert.AreEqual(-1, BinarySearch.Search(_values, _startIndex, _endIndex, 15));
            Assert.AreEqual(-1, BinarySearch.Search(_values, _startIndex, _endIndex, 456));
        }
    }
}
