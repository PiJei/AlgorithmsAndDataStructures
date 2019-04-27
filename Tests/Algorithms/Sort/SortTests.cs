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
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.Sort
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public static void TestSortMethodWithDifferentInputs(Action<List<int>> sortMethod)
        {
            var values = new List<int>(Constants.ArrayWithDistinctValues);
            sortMethod(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));

            values = new List<int>(Constants.ArrayWithDuplicateValues);
            sortMethod(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));

            values = new List<int>(Constants.ArrayWithSortedDistinctValues);
            sortMethod(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));

            values = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            sortMethod(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));

            values = new List<int>(Constants.ArrayWithReverselySortedDistinctValues);
            sortMethod(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));

            values = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            sortMethod(values);
            Assert.IsTrue(UtilsTests.IsSortedAscendingly(values));
        }
    }
}
