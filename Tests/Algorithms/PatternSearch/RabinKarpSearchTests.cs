﻿#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.PatternSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.PatternSearch
{
    /// <summary>
    /// Tests methods in <see cref="RabinKarpSearch"/> class.
    /// </summary>
    [TestClass]
    public class RabinKarpSearchTests
    {
        /// <summary>
        /// Tests the correctness of pattern search algorithm.
        /// </summary>
        [TestMethod]
        public void Search()
        {
            Assert.AreEqual(-1, RabinKarpSearch.Search("abd", "abdfgh")); /* Testing the case where substring is longer than string. */
            Assert.AreEqual(1, RabinKarpSearch.Search("abcd", "bc"));
            Assert.AreEqual(2, RabinKarpSearch.Search("abcd", "cd"));
            Assert.AreEqual(12, RabinKarpSearch.Search("aaaaaakcdkaaaabcd", "aab"));
            Assert.IsTrue(new List<int> { 0, 3, 4 }.Contains(RabinKarpSearch.Search("abcaab", "a")));
            Assert.IsTrue(new List<int> { 0 }.Contains(RabinKarpSearch.Search("abcaab", "abc")));
            Assert.AreEqual(-1, RabinKarpSearch.Search("aaabbbdaacbb", "kjh"));
        }
    }
}
