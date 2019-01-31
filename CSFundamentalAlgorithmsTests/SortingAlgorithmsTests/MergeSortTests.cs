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

namespace CSFundamentalAlgorithmsTests.SortingAlgorithmsTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_withDistinctValues()
        {
            List<int> values = new List<int> { 5, 3, 7, 1, 100 };
            MergeSort.MergeSort_Recursively(values, 0, 4);

            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test_withRedundantValues()
        {
            List<int> values = new List<int> { 100, 2, 3, 1, 56, 78, 209, 46, 78, 10, 12, 1, 51, 15 };
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);

            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void MergeSort_Merge_Test()
        {
            List<int> values1 = new List<int> { 10, 1 };
            MergeSort.Merge(values1, 0, 0, 1);
            Common.CheckIfListIsSortedAscendingly(values1);

            List<int> values2 = new List<int> { 10, 1 };
            // Indices are such that the list will not get sorted, 
            MergeSort.Merge(values2, 0, 1, 1);
            Assert.IsTrue(values2[0] == 10);
            Assert.IsTrue(values2[1] == 1);

            List<int> values3 = new List<int> { 10, 41, 3, 10 };
            MergeSort.Merge(values3, 0, 1, 3);
            Common.CheckIfListIsSortedAscendingly(values3);
        }
    }
}
