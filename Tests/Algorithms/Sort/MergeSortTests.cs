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
using CSFundamentals.Algorithms.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.Sort
{
    [TestClass]
    public partial class MergeSortTests
    {
        [TestMethod]
        public void MergeSort_Recursively_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            MergeSort.Sort_Recursively(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void MergeSort_Recursively_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            MergeSort.Sort_Recursively(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void MergeSort_Recursively_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            MergeSort.Sort_Recursively(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void MergeSort_Recursively_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            MergeSort.Sort_Recursively(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void MergeSort_Recursively_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            MergeSort.Sort_Recursively(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void MergeSort_Recursively_WithReverselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            MergeSort.Sort_Recursively(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void Merge()
        {
            var values1 = new List<int> { 10, 1 };
            MergeSort.Merge(values1, 0, 0, 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values1));

            var values2 = new List<int> { 10, 1 };
            // Indexes are such that the list will not get sorted, 
            MergeSort.Merge(values2, 0, 1, 1);
            Assert.IsTrue(values2[0] == 10);
            Assert.IsTrue(values2[1] == 1);

            var values3 = new List<int> { 10, 41, 3, 10 };
            MergeSort.Merge(values3, 0, 1, 3);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values3));
        }
    }
}
