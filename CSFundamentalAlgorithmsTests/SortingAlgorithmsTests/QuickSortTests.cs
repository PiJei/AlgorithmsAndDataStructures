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
    public class QuickSortTests
    {
        [TestMethod]
        public void QuickSort_QuickSort_Recursively_Test_WithDistinctValues()
        {
            List<int> values = new List<int> { 100, 2, 3, 1, 56, 78, 209, 46, 21, 10, 12, 15, 51 };
            QuickSort.QuickSort_Recursively(values, 0, values.Count - 1);

            Common.CheckIfListIsSortedAscendingly(values);
        }

        [TestMethod]
        public void QuickSort_QuickSort_Recursively_Test_WithDuplicateValues()
        {
            List<int> values = new List<int> { 100, 2, 3, 1, 56, 78, 209, 46, 78, 10, 12, 1, 51, 15 };
            QuickSort.QuickSort_Recursively(values, 0, values.Count - 1);

            Common.CheckIfListIsSortedAscendingly(values);
        }
    }
}
