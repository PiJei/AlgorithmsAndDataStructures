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
    public partial class RadixSortTests
    {
        /// <summary>
        /// Tests the stability of Radix sort algorithm. 
        /// </summary>
        [TestMethod]
        public void IsStable()
        {
            /* Radix sort is stable, try to find an example which breaks this property.*/

            var duplicateValues1 = new List<int> { 4, 3, 2, 4, 1 };
            List<Element> duplicateValuesElements1 = Utils.Convert(duplicateValues1);
            bool isStable1 = Utils.IsSortMethodStable(RadixSort.Sort_Iterative_V1, duplicateValuesElements1);
            Assert.IsTrue(isStable1);

            var duplicateValues2 = new List<int>(Constants.ArrayWithDuplicateValues);
            List<Element> duplicateValuesElements2 = Utils.Convert(duplicateValues2);
            bool isStable2 = Utils.IsSortMethodStable(RadixSort.Sort_Iterative_V1, duplicateValuesElements2);
            Assert.IsTrue(isStable2);

            var duplicateValues3 = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            List<Element> duplicateValuesElements3 = Utils.Convert(duplicateValues3);
            bool isStable3 = Utils.IsSortMethodStable(RadixSort.Sort_Iterative_V1, duplicateValuesElements3);
            Assert.IsTrue(isStable3);

            var duplicateValues4 = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            List<Element> duplicateValuesElements4 = Utils.Convert(duplicateValues4);
            bool isStable4 = Utils.IsSortMethodStable(RadixSort.Sort_Iterative_V1, duplicateValuesElements4);
            Assert.IsTrue(isStable4);

            var duplicateValues5 = new List<int> { 3, 1, 1, 2, 2, 4, 1, 1, 2, 2 };
            List<Element> duplicateValuesElements5 = Utils.Convert(duplicateValues5);
            bool isStable5 = Utils.IsSortMethodStable(RadixSort.Sort_Iterative_V1, duplicateValuesElements5);
            Assert.IsTrue(isStable5);
        }
    }
}
