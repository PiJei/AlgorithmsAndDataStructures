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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.DataStructures.StringStructures;

namespace CSFundamentalsTests.StringStructures
{
    [TestClass]
    public class SuffixArrayTests
    {
        [TestMethod]
        public void StringSuffix_SortSuffixes_Test()
        {
            int[] suffixArray = SuffixArray.Build("banana");
            Assert.AreEqual(5, suffixArray[0]);
            Assert.AreEqual(3, suffixArray[1]);
            Assert.AreEqual(1, suffixArray[2]);
            Assert.AreEqual(0, suffixArray[3]);
            Assert.AreEqual(4, suffixArray[4]);
            Assert.AreEqual(2, suffixArray[5]);
        }
    }
}
