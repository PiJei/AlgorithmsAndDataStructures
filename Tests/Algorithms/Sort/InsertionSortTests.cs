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

using System.Collections.Generic;
using CSFundamentals.Algorithms.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.Sort
{
    [TestClass]
    public partial class InsertionSortTests
    {
        [TestMethod]
        public void Sort_Iterative_V1_WithDifferentInputs()
        {
            SortTests.TestSortMethodWithDifferentInputs(InsertionSort.Sort_Iterative_V1);
        }

        [TestMethod]
        public void Sort_Iterative_V2_WithDifferentInputs()
        {
            SortTests.TestSortMethodWithDifferentInputs(InsertionSort.Sort_Iterative_V2);
        }

        // TODO: How can I use the SortTests library to test this version as well?
        [TestMethod]
        public void Sort_Recursive_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            InsertionSort.Sort_Recursive(values, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }

        [TestMethod]
        public void Sort_Recursive_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            InsertionSort.Sort_Recursive(values, values.Count - 1);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }
    }
}
