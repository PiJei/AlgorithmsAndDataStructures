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
    /// Tests methods in <see cref="HeapSort"/> class. 
    /// </summary>
    [TestClass]
    public class HeapSortTests
    {
        /// <summary>
        /// Tests the correctness of Heap sort algorithm over an array with distinct values.  
        /// To visualize how the array evolves while executing Heap sort on <see cref="Constants.ArrayWithDistinctValues"/> see:
        /// <img src = "../Images/Sorts/HeapSort-Part1.png"/>, 
        /// <img src = "../Images/Sorts/HeapSort-Part2.png"/>, 
        /// <img src = "../Images/Sorts/HeapSort-Part3.png"/>, 
        /// <img src = "../Images/Sorts/HeapSort-Part4.png"/>, 
        /// <img src = "../Images/Sorts/HeapSort-Part5.png"/>, 
        /// <img src = "../Images/Sorts/HeapSort-Part6.png"/>, 
        /// <img src = "../Images/Sorts/HeapSort-Part7.png"/>.
        /// </summary>
        [TestMethod]
        public void Sort_WithDistinctValues()
        {
            // TODO: HeapSort signature is not the same as others, ... 
            // SortTests.TestSortMethodWithDifferentInputs(HeapSort.Sort);
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            values = HeapSort.Sort(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Heap sort algorithm over an array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void Sort_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            values = HeapSort.Sort(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Heap sort algorithm over a sorted array with distinct values. 
        /// </summary>
        [TestMethod]
        public void Sort_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            values = HeapSort.Sort(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Heap sort algorithm over a sorted array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void Sort_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            values = HeapSort.Sort(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Heap sort algorithm over a reversely sorted array with distinct values. 
        /// </summary>
        [TestMethod]
        public void Sort_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            values = HeapSort.Sort(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Heap sort algorithm over a reversely sorted array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void Sort_WithRevereselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            values = HeapSort.Sort(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }
    }
}
