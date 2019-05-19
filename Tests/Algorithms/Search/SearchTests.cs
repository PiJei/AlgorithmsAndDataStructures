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
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// TODO: Duplicate functions: how can I unify the signatures? ... 

namespace CSFundamentalsTests.Algorithms.Search
{
    /// <summary>
    /// Implements test methods for search algorithms. 
    /// </summary>
    public class SearchTests
    {
        /// <summary>
        /// Sorted array of elements. Note that binary search expects a sorted array. 
        /// </summary>
        public static readonly List<int> List = new List<int> { 1, 1, 3, 10, 14, 25, 27, 34, 78, 90, 90, 120 };

        private static readonly int _startIndex = 0;
        private static readonly int _endIndex = List.Count - 1;

        /// <summary>
        /// Tests the correctness of <paramref name="searchMethod"/> on an array with distinct elements. 
        /// </summary>
        /// <param name="searchMethod">The search method that is being tested. </param>
        public static void DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(Func<List<int>, int, int, int, int> searchMethod)
        {
            Assert.AreEqual(2, searchMethod(List, 3, _startIndex, _endIndex));
            Assert.AreEqual(3, searchMethod(List, 10, _startIndex, _endIndex));
            Assert.AreEqual(4, searchMethod(List, 14, _startIndex, _endIndex));
            Assert.AreEqual(5, searchMethod(List, 25, _startIndex, _endIndex));
            Assert.AreEqual(6, searchMethod(List, 27, _startIndex, _endIndex));
            Assert.AreEqual(7, searchMethod(List, 34, _startIndex, _endIndex));
            Assert.AreEqual(8, searchMethod(List, 78, _startIndex, _endIndex));
            Assert.AreEqual(11, searchMethod(List, 120, _startIndex, _endIndex));
        }

        /// <summary>
        /// Tests the correctness of <paramref name="searchMethod"/> on an array with duplicate elements. 
        /// </summary>
        /// <param name="searchMethod">The search method that is being tested. </param>
        public static void DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(Func<List<int>, int, int, int, int> searchMethod)
        {
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(searchMethod(List, 1, _startIndex, _endIndex)));
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(searchMethod(List, 1, _startIndex, _endIndex)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(searchMethod(List, 90, _startIndex, _endIndex)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(searchMethod(List, 90, _startIndex, _endIndex)));
        }

        /// <summary>
        /// Tests the correctness of <paramref name="searchMethod"/> when the key does not exist in the array. 
        /// </summary>
        /// <param name="searchMethod">The search method that is being tested. </param>
        public static void NonExistingElements_ExpectsToGetMinusOne(Func<List<int>, int, int, int, int> searchMethod)
        {
            //Assert.AreEqual(-1, searchMethod(List, -20, _startIndex, _endIndex));
            Assert.AreEqual(-1, searchMethod(List, 15, _startIndex, _endIndex));
            Assert.AreEqual(-1, searchMethod(List, 456, _startIndex, _endIndex));
        }

        /// <summary>
        /// Tests the correctness of <paramref name="searchMethod"/> on an array with distinct elements. 
        /// </summary>
        /// <param name="searchMethod">The search method that is being tested. </param>
        public static void DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(Func<List<int>, int, int> searchMethod)
        {
            Assert.AreEqual(2, searchMethod(List, 3));
            Assert.AreEqual(3, searchMethod(List, 10));
            Assert.AreEqual(4, searchMethod(List, 14));
            Assert.AreEqual(5, searchMethod(List, 25));
            Assert.AreEqual(6, searchMethod(List, 27));
            Assert.AreEqual(7, searchMethod(List, 34));
            Assert.AreEqual(8, searchMethod(List, 78));
            Assert.AreEqual(11, searchMethod(List, 120));
        }

        /// <summary>
        /// Tests the correctness of <paramref name="searchMethod"/> on an array with duplicate elements. 
        /// </summary>
        /// <param name="searchMethod">The search method that is being tested. </param>
        public static void DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(Func<List<int>, int, int> searchMethod)
        {
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(searchMethod(List, 1)));
            Assert.IsTrue(new List<int> { 0, 1 }.Contains(searchMethod(List, 1)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(searchMethod(List, 90)));
            Assert.IsTrue(new List<int> { 9, 10 }.Contains(searchMethod(List, 90)));
        }

        /// <summary>
        /// Tests the correctness of <paramref name="searchMethod"/> when the key does not exist in the array. 
        /// </summary>
        /// <param name="searchMethod">The search method that is being tested. </param>
        public static void NonExistingElements_ExpectsToGetMinusOne(Func<List<int>, int, int> searchMethod)
        {
            Assert.AreEqual(-1, searchMethod(List, -20));
            Assert.AreEqual(-1, searchMethod(List, 15));
            Assert.AreEqual(-1, searchMethod(List, 456));
        }
    }
}
