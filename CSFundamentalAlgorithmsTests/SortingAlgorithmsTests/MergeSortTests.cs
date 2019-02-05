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
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentalAlgorithms.SortingAlgorithms;
using CSFundamentalAlgorithms.SortingAlgorithms.Helpers;

namespace CSFundamentalAlgorithmsTests.SortingAlgorithmsTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_WithReverselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_Merge_Test()
        {
            List<int> values1 = new List<int> { 10, 1 };
            MergeSort.Merge(values1, 0, 0, 1);
            UtilsTests.CheckIfListIsSortedAscendingly(values1);

            List<int> values2 = new List<int> { 10, 1 };
            // Indices are such that the list will not get sorted, 
            MergeSort.Merge(values2, 0, 1, 1);
            Assert.IsTrue(values2[0] == 10);
            Assert.IsTrue(values2[1] == 1);

            List<int> values3 = new List<int> { 10, 41, 3, 10 };
            MergeSort.Merge(values3, 0, 1, 3);
            UtilsTests.CheckIfListIsSortedAscendingly(values3);
        }
    }
}
