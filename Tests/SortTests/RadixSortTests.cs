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
using CSFundamentalAlgorithms.Sort;
using System.Collections.Generic;

namespace CSFundamentalAlgorithmsTests.SortTests
{
    [TestClass]
    public partial class RadixSortTests
    {
        [TestMethod]
        public void RadixSort_RadixSort_Iterative_V1_Test_WithDistinctValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithDistinctValues);
            RadixSort.Sort_Iterative_V1(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void RadixSort_RadixSort_Iterative_V1_Test_WithDuplicateValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithDuplicateValues);
            RadixSort.Sort_Iterative_V1(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void RadixSort_RadixSort_Iterative_V1_Test_WithSortedDistinctValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            RadixSort.Sort_Iterative_V1(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void RadixSort_RadixSort_Iterative_V1_Test_WithSortedDuplicateValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            RadixSort.Sort_Iterative_V1(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void RadixSort_RadixSort_Iterative_V1_Test_WithReverselySortedDistinctValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            RadixSort.Sort_Iterative_V1(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void RadixSort_RadixSort_Iterative_V1_Test_WithReverselyDuplicateValues()
        {
            List<int> values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            RadixSort.Sort_Iterative_V1(values);
            UtilsTests.CheckIfListIsSortedAscendingly(values);
        }
    }
}
