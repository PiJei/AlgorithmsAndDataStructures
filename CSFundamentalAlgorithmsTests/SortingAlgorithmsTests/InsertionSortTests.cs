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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentalAlgorithms.SortingAlgorithms;
using System.Collections.Generic;

namespace CSFundamentalAlgorithmsTests.SortingAlgorithmsTests
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void InsertionSort_InsertionSort_Iterative_V1_Test_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            InsertionSort.InsertionSort_Iterative_V1(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void InsertionSort_InsertionSort_Iterative_V1_Test_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            InsertionSort.InsertionSort_Iterative_V1(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void InsertionSort_InsertionSort_Iterative_V2_Test_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            InsertionSort.InsertionSort_Iterative_V2(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void InsertionSort_InsertionSort_Iterative_V2_Test_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            InsertionSort.InsertionSort_Iterative_V2(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void InsertionSort_InsertionSort_Recursive_Test_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            InsertionSort.InsertionSort_Recursive(values, values.Count - 1);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void InsertionSort_InsertionSort_Recursive_Test_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            InsertionSort.InsertionSort_Recursive(values, values.Count - 1);
            Common.CheckIfListIsSortedAscendingly(values);

        }

    }
}
