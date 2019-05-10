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
    /// Tests methods in <see cref="QuickSort"/> class.
    /// </summary>
    [TestClass]
    public partial class QuickSortTests
    {
        /// <summary>
        /// Tests the correctness of Quick sort algorithm recursive version over an array with distinct values. 
        /// To visualize how the array is evolved while executing quick sort see <img src = "../Images/Sorts/QuickSort.png"/>.
        /// </summary>
        [TestMethod]
        public void QuickSort_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            QuickSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Quick sort algorithm recursive version over an array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void QuickSort_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            QuickSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Quick sort algorithm recursive version over a sorted array with distinct values. 
        /// </summary>
        [TestMethod]
        public void QuickSort_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            QuickSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Quick sort algorithm recursive version over a sorted array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void QuickSort_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            QuickSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Quick sort algorithm recursive version over a reversely sorted array with distinct values. 
        /// </summary>
        [TestMethod]
        public void QuickSort_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            QuickSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Quick sort algorithm recursive version over a reversely sorted array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void QuickSort_WithReverselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            QuickSort.Sort(values, 0, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }
    }
}
