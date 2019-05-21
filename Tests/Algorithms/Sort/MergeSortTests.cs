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
    /// <summary>
    /// Tests method in <see cref=" MergeSort"/> class.
    /// </summary>
    [TestClass]
    public partial class MergeSortTests
    {
        /// <summary>
        /// Tests the correctness of Merge sort algorithm recursive version over an array with distinct values. 
        /// To visualize how the array is evolved while executing merge sort see: 
        /// <img src = "../Images/Sorts/MergeSort-Part1.png"/>,
        /// <img src = "../Images/Sorts/MergeSort-Part2.png"/>,
        /// <img src = "../Images/Sorts/MergeSort-Part3.png"/>,
        /// <img src = "../Images/Sorts/MergeSort-Part4.png"/>,
        /// <img src = "../Images/Sorts/MergeSort-Part5.png"/>,
        /// </summary>
        [TestMethod]
        public void MergeSort_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            MergeSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Merge sort algorithm recursive version over an array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void MergeSort_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            MergeSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Merge sort algorithm recursive version over a sorted array with distinct values. 
        /// </summary>
        [TestMethod]
        public void MergeSort_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            MergeSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Merge sort algorithm recursive version over a sorted array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void MergeSort_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            MergeSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Merge sort algorithm recursive version over a reversely sorted array with distinct values. 
        /// </summary>
        [TestMethod]
        public void MergeSort_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            MergeSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Merge sort algorithm recursive version over a reversely sorted array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void MergeSort_WithReverselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            MergeSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Merge operation. 
        /// </summary>
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
