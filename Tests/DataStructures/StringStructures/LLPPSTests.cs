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
using CSFundamentals.DataStructures.StringStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.StringStructures
{
    /// <summary>
    /// Tests methods in <see cref="LLPPS"/> class. 
    /// </summary>
    [TestClass]
    public class LLPPSTests
    {
        /// <summary>
        /// Tests the correctness of Build operation. 
        /// </summary>
        [TestMethod]
        public void Build_1()
        {
            List<int> longestProperPrefixes1 = LLPPS.Build("aaaabcbaab");
            Assert.AreEqual(0, longestProperPrefixes1[0]);
            Assert.AreEqual(1, longestProperPrefixes1[1]);
            Assert.AreEqual(2, longestProperPrefixes1[2]);
            Assert.AreEqual(3, longestProperPrefixes1[3]);
            Assert.AreEqual(0, longestProperPrefixes1[4]);
            Assert.AreEqual(0, longestProperPrefixes1[5]);
            Assert.AreEqual(0, longestProperPrefixes1[6]);
            Assert.AreEqual(1, longestProperPrefixes1[7]);
            Assert.AreEqual(2, longestProperPrefixes1[8]);
            Assert.AreEqual(0, longestProperPrefixes1[9]);
        }

        /// <summary>
        /// Tests the correctness of Build operation.
        /// </summary>
        [TestMethod]
        public void Build_2()
        {
            List<int> longestProperPrefixes1 = LLPPS.Build("abcdef");
            Assert.AreEqual(0, longestProperPrefixes1[0]);
            Assert.AreEqual(0, longestProperPrefixes1[1]);
            Assert.AreEqual(0, longestProperPrefixes1[2]);
            Assert.AreEqual(0, longestProperPrefixes1[3]);
            Assert.AreEqual(0, longestProperPrefixes1[4]);
            Assert.AreEqual(0, longestProperPrefixes1[5]);
        }

        /// <summary>
        /// Tests the correctness of Build operation. 
        /// </summary>
        [TestMethod]
        public void Build_3()
        {
            List<int> longestProperPrefixes1 = LLPPS.Build("ddgddcddgdd");
            Assert.AreEqual(0, longestProperPrefixes1[0]);
            Assert.AreEqual(1, longestProperPrefixes1[1]);
            Assert.AreEqual(0, longestProperPrefixes1[2]);
            Assert.AreEqual(1, longestProperPrefixes1[3]);
            Assert.AreEqual(2, longestProperPrefixes1[4]);
            Assert.AreEqual(0, longestProperPrefixes1[5]);
            Assert.AreEqual(1, longestProperPrefixes1[6]);
            Assert.AreEqual(2, longestProperPrefixes1[7]);
            Assert.AreEqual(3, longestProperPrefixes1[8]);
            Assert.AreEqual(4, longestProperPrefixes1[9]);
            Assert.AreEqual(5, longestProperPrefixes1[10]);
        }
    }
}
