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
    public class LinearSearchTests
    {
        /// <summary>
        /// A random array of integers (not sorted), and containing duplicates
        /// </summary>
        private readonly List<int> _values = new List<int> { 4, 1, 9, 100, 3, 2, 45, 37, 3 };

        [TestMethod]
        public void Search_DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition()
        {
            Assert.AreEqual(0, LinearSearch.Search(_values, 4));
            Assert.AreEqual(7, LinearSearch.Search(_values, 37));
            Assert.AreEqual(3, LinearSearch.Search(_values, 100));
            Assert.AreEqual(1, LinearSearch.Search(_values, 1));
            Assert.AreEqual(2, LinearSearch.Search(_values, 9));
            Assert.AreEqual(5, LinearSearch.Search(_values, 2));
            Assert.AreEqual(6, LinearSearch.Search(_values, 45));
        }

        [TestMethod]
        public void Search_DuplicateElements_ExpectsToGetTheIndexOfTheFirstOccurrenceNoMatterHowManyTimesSearchIsPerformed()
        {
            Assert.AreEqual(4, LinearSearch.Search(_values, 3));
            Assert.AreEqual(4, LinearSearch.Search(_values, 3));
        }

        [TestMethod]
        public void Search_NonExistingElements_ExpectsToGetMinusOne()
        {
            Assert.AreEqual(-1, LinearSearch.Search(_values, 200));
            Assert.AreEqual(-1, LinearSearch.Search(_values, 1550));
            Assert.AreEqual(-1, LinearSearch.Search(_values, 8));
        }
    }
}

