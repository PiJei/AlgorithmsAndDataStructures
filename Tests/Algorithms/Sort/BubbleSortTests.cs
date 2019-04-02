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
using System.Collections.Generic;
using CSFundamentals.Algorithms.Sort;

namespace CSFundamentalsTests.Algorithms.Sort
{
    [TestClass]
    public partial class BubbleSortTests
    {
        [TestMethod]
        public void Iterative_WithDistinctValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithDistinctValues);
            BubbleSort.Sort_Iterative(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void Iterative_WithDuplicateValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithDuplicateValues);
            BubbleSort.Sort_Iterative(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void Iterative_WithSortedDistinctValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            BubbleSort.Sort_Iterative(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void Iterative_WithSortedDuplicateValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            BubbleSort.Sort_Iterative(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void BubbleSort_Iterative_WithReverselySortedDistinctValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            BubbleSort.Sort_Iterative(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void BubbleSort_Iterative_WithReverselySortedDuplicateValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            BubbleSort.Sort_Iterative(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }
    }
}
