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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.Algorithms.Sort;

namespace CSFundamentalsTests.Algorithms.Sort
{
    [TestClass]
    public partial class SelectionSortTests
    {
        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithDistnctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            SelectionSort.Sort_Iteratively(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            SelectionSort.Sort_Iteratively(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            SelectionSort.Sort_Iteratively(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            SelectionSort.Sort_Iteratively(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            SelectionSort.Sort_Iteratively(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void SelectionSort_SelectionSortIteratively_Test_WithReverselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            SelectionSort.Sort_Iteratively(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }
    }
}
