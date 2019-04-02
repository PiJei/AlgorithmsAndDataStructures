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
using CSFundamentals.Algorithms.Sort.StabilityCheckableVersions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.Algorithms.Sort;

namespace CSFundamentalsTests.Algorithms.Sort
{
    public partial class SelectionSortTests
    {
        [TestMethod]
        public void IsStable()
        {
            /* All we need to do is to find "a" list with a particular arrangements of duplicate values and other distinct values, such that breaks isStable sort question for heap sort.. 
             * Meaning that not finding this list, does not prove that the sort method is stable.
             * This also means that there might be lots of lists with duplicate values, for which heap sort acts as stable. 
             */
            List<int> duplicateValues1 = new List<int> { 4, 2, 3, 4, 1 };
            List<Element> duplicateValuesElements1 = Utils.Convert(duplicateValues1);
            bool isStable = Utils.IsSortMethodStable(SelectionSort.Sort_Iteratively, duplicateValuesElements1);
            Assert.IsFalse(isStable);

            List<int> duplicateValues4 = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            List<Element> duplicateValuesElements4 = Utils.Convert(duplicateValues4);
            bool isStable4 = Utils.IsSortMethodStable(SelectionSort.Sort_Iteratively, duplicateValuesElements4);
            Assert.IsFalse(isStable4);
        }
    }
}
