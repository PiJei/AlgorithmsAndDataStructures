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

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.Search
{
    public class SearchTests
    {
        /// <summary>
        /// Sorted array of elements. Note that binary search expects a sorted array. 
        /// </summary>
        private static readonly List<int> _values = new List<int> { 1, 1, 3, 10, 14, 25, 27, 34, 78, 90, 90, 120 };

        private static readonly int _startIndex = 0;
        private static readonly int _endIndex = _values.Count - 1;

        public static void DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(Func<List<int>, int, int, int, int> search)
        {
            Assert.AreEqual(2, search(_values, _startIndex, _endIndex, 3));
            Assert.AreEqual(3, search(_values, _startIndex, _endIndex, 10));
            Assert.AreEqual(4, search(_values, _startIndex, _endIndex, 14));
            Assert.AreEqual(5, search(_values, _startIndex, _endIndex, 25));
            Assert.AreEqual(6, search(_values, _startIndex, _endIndex, 27));
            Assert.AreEqual(7, search(_values, _startIndex, _endIndex, 34));
            Assert.AreEqual(8, search(_values, _startIndex, _endIndex, 78));
            Assert.AreEqual(11, search(_values, _startIndex, _endIndex, 120));
        }

        public static void DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(Func<List<int>, int, int, int, int> search)
        {
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(search(_values, _startIndex, _endIndex, 1)));
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(search(_values, _startIndex, _endIndex, 1)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(search(_values, _startIndex, _endIndex, 90)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(search(_values, _startIndex, _endIndex, 90)));
        }

        public static void NonExistingElements_ExpectsToGetMinusOne(Func<List<int>, int, int, int, int> search)
        {
            Assert.AreEqual(-1, search(_values, _startIndex, _endIndex, -20));
            Assert.AreEqual(-1, search(_values, _startIndex, _endIndex, 15));
            Assert.AreEqual(-1, search(_values, _startIndex, _endIndex, 456));
        }

        public static void DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(Func<List<int>, int, int> search)
        {
            Assert.AreEqual(2, search(_values, 3));
            Assert.AreEqual(3, search(_values, 10));
            Assert.AreEqual(4, search(_values, 14));
            Assert.AreEqual(5, search(_values, 25));
            Assert.AreEqual(6, search(_values, 27));
            Assert.AreEqual(7, search(_values, 34));
            Assert.AreEqual(8, search(_values, 78));
            Assert.AreEqual(11, search(_values, 120));
        }

        public static void DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(Func<List<int>, int, int> search)
        {
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(search(_values, 1)));
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(search(_values, 1)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(search(_values, 90)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(search(_values, 90)));
        }

        public static void NonExistingElements_ExpectsToGetMinusOne(Func<List<int>, int, int> search)
        {
            Assert.AreEqual(-1, search(_values, -20));
            Assert.AreEqual(-1, search(_values, 15));
            Assert.AreEqual(-1, search(_values, 456));
        }
    }
}
