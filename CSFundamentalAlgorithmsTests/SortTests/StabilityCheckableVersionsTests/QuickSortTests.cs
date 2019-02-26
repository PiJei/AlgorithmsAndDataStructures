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
using CSFundamentalAlgorithms.Sort;
using CSFundamentalAlgorithms.Sort.StabilityCheckableVersions;

namespace CSFundamentalAlgorithmsTests.SortTests
{
    public partial class QuickSortTests
    {
        [TestMethod]
        public void QuickSort_IsStable_Test()
        {
            /* We need to find "a" list with duplicate values, such that shows Quick sort is not stable. 
               This does not mean that Quick sort is unstable for all arrays with duplicate values. */
            List<int> duplicateValues = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            List<Element> duplicateValuesElements = Utils.Convert(duplicateValues);
            bool isStable = Utils.IsSortMethodStable(QuickSort.Wrapper, duplicateValuesElements);
            Assert.IsFalse(isStable);
        }
    }
}
