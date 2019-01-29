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
using CSFundamentalAlgorithms.SortingAlgs;

namespace CSFundamentalAlgorithmsTests.SortingAlgsTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void MergeSort_MergeSort_Recursively_Test()
        {
            List<int> values = new List<int> { 5, 3, 7, 1, 100 };
            MergeSort.MergeSort_Recursively(values, 0, 4);

            SortingTestsCommon.CheckIfListIsSortedAscendingly(values);
        }
    }
}
