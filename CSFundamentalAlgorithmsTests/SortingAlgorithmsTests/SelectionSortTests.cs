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
    public class SelectionSortTests
    {
        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithDistnctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            SelectionSort.SelectionSort_Iteratively(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            SelectionSort.SelectionSort_Iteratively(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            SelectionSort.SelectionSort_Iteratively(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            SelectionSort.SelectionSort_Iteratively(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            SelectionSort.SelectionSort_Iteratively(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithReverselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            SelectionSort.SelectionSort_Iteratively(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_IsStable_Test()
        {
            /* We need to find "a" list with duplicate values, such that shows Selection sort is not stable. 
             * This does not mean that Selection sort is unstable for all arrays with duplicate values. */
            List<int> duplicateValues1 = new List<int> { 4, 2, 3, 4, 1 };
            bool isStable = CSFundamentalAlgorithms.SortingAlgorithms.Common.IsSortMethodStable(SelectionSort.SelectionSort_Iteratively, duplicateValues1);
            Assert.IsFalse(isStable);
        }
    }
}
