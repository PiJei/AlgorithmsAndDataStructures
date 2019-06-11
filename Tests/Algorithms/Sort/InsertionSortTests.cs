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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.Algorithms.Sort
{
    /// <summary>
    /// Tests methods in <see cref="InsertionSort"/> class. 
    /// </summary>
    [TestClass]
    public partial class InsertionSortTests
    {
        /// <summary>
        /// Tests the correctness of Insertion sort iterative version1. 
        /// </summary>
        [TestMethod]
        public void Sort_Iterative_V1_WithDifferentInputs()
        {
            SortTests.TestSortMethodWithDifferentInputs(InsertionSort.Sort_Iterative_V1);
        }

        /// <summary>
        /// Tests the correctness of Insertion sort iterative version2. 
        /// To visualize how the array evolves while executing insertion sort on <see cref="Constants.ArrayWithDistinctValues"/> see: 
        /// <img src = "../Images/Sorts/InsertionSort-Part1.png"/>, 
        /// <img src = "../Images/Sorts/InsertionSort-Part2.png"/>,
        /// <img src = "../Images/Sorts/InsertionSort-Part3.png"/>, 
        /// <img src = "../Images/Sorts/InsertionSort-Part4.png"/>,
        /// <img src = "../Images/Sorts/InsertionSort-Part5.png"/>, 
        /// <img src = "../Images/Sorts/InsertionSort-Part6.png"/>,
        /// <img src = "../Images/Sorts/InsertionSort-Part7.png"/>, 
        /// <img src = "../Images/Sorts/InsertionSort-Part8.png"/>.
        /// </summary>
        [TestMethod]
        public void Sort_Iterative_V2_WithDifferentInputs()
        {
            SortTests.TestSortMethodWithDifferentInputs(InsertionSort.Sort_Iterative_V2);
        }

        // TODO: How can I use the SortTests library to test this version as well?
        /// <summary>
        /// Tests the correctness of Insertion sort recursive version over an array with distinct values. 
        /// </summary>
        [TestMethod]
        public void Sort_Recursive_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            InsertionSort.Sort_Recursive(values, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        /// <summary>
        /// Tests the correctness of Insertion sort recursive version over an array with duplicate values. 
        /// </summary>
        [TestMethod]
        public void Sort_Recursive_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            InsertionSort.Sort_Recursive(values, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }
    }
}
