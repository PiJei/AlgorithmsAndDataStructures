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
    public class HeapSortTests
    {
        [TestMethod]
        public void HeapSort_HeapSortAscending_Test_WithDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            HeapSort.HeapSort_Ascending(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void HeapSort_HeapSortAscending_Test_WithDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithDuplicateValues);
            HeapSort.HeapSort_Ascending(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void HeapSort_HeapSortAscending_Test_WithSortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            HeapSort.HeapSort_Ascending(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void HeapSort_HeapSortAscending_Test_WithSortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            HeapSort.HeapSort_Ascending(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void HeapSort_HeapSortAscending_Test_WithReverselySortedDistinctValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            HeapSort.HeapSort_Ascending(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void HeapSort_HeapSortAscending_Test_WithRevereselySortedDuplicateValues()
        {
            var values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            HeapSort.HeapSort_Ascending(values);
            Common.CheckIfListIsSortedAscendingly(values);
        }


        /// <summary>
        /// Tests if heap sort is stable or not. Heapsort by design is not stable. 
        /// </summary>
        [TestMethod]
        public void HeapSort_IsStable_Test()
        {
            /* All we need to do is to find "a" list with a particular arrangements of duplicate values and other distnct values, such that breaks isStable sort question for heap sort.. 
             * Meaning that not finding this list, does not prove that the sort method is stable.
             * This also means that there might be lots of lists with duplicate values, for which heap sort acts as stable. 
             */
            List<int> duplicateValues1 = new List<int> { 4, 2, 3, 1, 4 };
            bool isStable = CSFundamentalAlgorithms.SortingAlgorithms.Common.IsSortMethodStable(HeapSort.HeapSort_Ascending, duplicateValues1);
            Assert.IsFalse(isStable);
        }
    }
}
