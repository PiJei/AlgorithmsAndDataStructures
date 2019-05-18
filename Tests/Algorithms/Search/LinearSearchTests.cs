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
using CSFundamentals.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.Search
{
    /// <summary>
    /// Tests methods in <see cref="LinearSearch"/> class. 
    /// </summary>
    [TestClass]
    public class LinearSearchTests
    {
        /// <summary>
        /// A random array of integers (not sorted), and containing duplicates
        /// </summary>
        private readonly static List<int> _values = new List<int> { 27, 1, 120, 10, 3, 90, 25, 14, 1, 34, 78 };
        private readonly static int _startIndex = 0;
        private readonly static int _endIndex = _values.Count - 1;

        /// <summary>
        /// Tests the correctness of Linear search algorithm on an array with distinct elements. 
        /// </summary>
        [TestMethod]
        public void Search_DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition()
        {
            Assert.AreEqual(4, LinearSearch.Search(_values, 3, _startIndex, _endIndex));
            Assert.AreEqual(3, LinearSearch.Search(_values, 10, _startIndex, _endIndex));
            Assert.AreEqual(7, LinearSearch.Search(_values, 14, _startIndex, _endIndex));
            Assert.AreEqual(6, LinearSearch.Search(_values, 25, _startIndex, _endIndex));
            Assert.AreEqual(0, LinearSearch.Search(_values, 27, _startIndex, _endIndex));
            Assert.AreEqual(9, LinearSearch.Search(_values, 34, _startIndex, _endIndex));
            Assert.AreEqual(10, LinearSearch.Search(_values, 78, _startIndex, _endIndex));
            Assert.AreEqual(2, LinearSearch.Search(_values, 120, _startIndex, _endIndex));
        }

        /// <summary>
        /// Tests the correctness of Linear search algorithm on an array with duplicate elements. 
        /// </summary>
        [TestMethod]
        public void Search_DuplicateElements_ExpectsToGetTheIndexOfTheFirstOccurrenceNoMatterHowManyTimesSearchIsPerformed()
        {
            Assert.AreEqual(1, LinearSearch.Search(_values, 1, _startIndex, _endIndex));
            Assert.AreEqual(5, LinearSearch.Search(_values, 90, _startIndex, _endIndex));
        }

        /// <summary>
        /// Tests the correctness of Linear search algorithm when the key does not exist in the array. 
        /// </summary>
        [TestMethod]
        public void Search_NonExistingElements_ExpectsToGetMinusOne()
        {
            Assert.AreEqual(-1, LinearSearch.Search(_values, -20, _startIndex, _endIndex));
            Assert.AreEqual(-1, LinearSearch.Search(_values, 15, _startIndex, _endIndex));
            Assert.AreEqual(-1, LinearSearch.Search(_values, 456, _startIndex, _endIndex));
        }
    }
}

