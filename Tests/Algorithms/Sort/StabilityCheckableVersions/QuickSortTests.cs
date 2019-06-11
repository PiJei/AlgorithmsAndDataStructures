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
using AlgorithmsAndDataStructures.Algorithms.Sort.StabilityCheckableVersions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.Algorithms.Sort
{
    public partial class QuickSortTests
    {
        /// <summary>
        /// Tests the stability of Quick sort algorithm. 
        /// </summary>
        [TestMethod]
        public void IsStable()
        {
            /* We need to find "a" list with duplicate values, such that shows Quick sort is not stable. 
               This does not mean that Quick sort is unstable for all arrays with duplicate values. */
            var duplicateValues2 = new List<int> { 4 , 2, 3, 4, 1, 1, 1};
            List<Element> duplicateValuesElements2 = Utils.Convert(duplicateValues2);
            bool isStable2 = Utils.IsSortMethodStable(QuickSort.Wrapper, duplicateValuesElements2);
            Assert.IsFalse(isStable2);
        }
    }
}
