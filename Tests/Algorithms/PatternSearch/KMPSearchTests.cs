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
using System.Linq;
using CSFundamentals.Algorithms.PatternSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.PatternSearch
{
    [TestClass]
    public class KMPSearchTests
    {
        [TestMethod]
        public void Search()
        {
            Assert.IsTrue(KMPSearch.Search("abd", "abdfgh").SequenceEqual(new List<int> { })); /* Testing the case where substring is longer than string. */
            Assert.AreEqual(1, KMPSearch.Search("abcd", "bc")[0]);
            Assert.AreEqual(2, KMPSearch.Search("abcd", "cd")[0]);
            Assert.AreEqual(12, KMPSearch.Search("aaaaaakcdkaaaabcd", "aab")[0]);
            Assert.IsTrue(KMPSearch.Search("abcaab", "a").SequenceEqual(new List<int> { 0, 3, 4 }));
            Assert.IsTrue(KMPSearch.Search("abcaab", "abc").SequenceEqual(new List<int> { 0 }));
            Assert.AreEqual(0, KMPSearch.Search("aaabbbdaacbb", "kjh").Count);
        }
    }
}

