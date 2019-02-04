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
using CSFundamentalAlgorithms;

// TODO: Rename this class, 

namespace CSFundamentalAlgorithmsTests.SortingAlgorithmsTests
{
    [TestClass]
    public class Common
    {
        /// <summary>
        /// Checkes whether the given integer list is sorted in ascending order. 
        /// </summary>
        public static void CheckIfListIsSortedAscendingly(List<int> values)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                Assert.IsTrue(values[i] <= values[i + 1]);
            }
        }

        [TestMethod]
        public void Common_GetDigitsCount_Test()
        {
            Assert.AreEqual(3, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetDigitsCount(123));
            Assert.AreEqual(1, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetDigitsCount(9));
            Assert.AreEqual(1, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetDigitsCount(0));
            Assert.AreEqual(6, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetDigitsCount(456123));
            Assert.AreEqual(7, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetDigitsCount(1230000));
            Assert.AreEqual(2, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetDigitsCount(45));
        }

        [TestMethod]
        public void Common_GetNthDigitFromRight_Test()
        {
            Assert.AreEqual(3, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(123, 1));
            Assert.AreEqual(2, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(123, 2));
            Assert.AreEqual(1, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(123, 3));
            Assert.AreEqual(0, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(123, 4));

            Assert.AreEqual(9, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(9, 1));
            Assert.AreEqual(0, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(9, 2));
            Assert.AreEqual(0, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(9, 3));
            Assert.AreEqual(0, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(9, 0));

            Assert.AreEqual(0, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(0, 1));
            Assert.AreEqual(0, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(0, 0));

            Assert.AreEqual(4, CSFundamentalAlgorithms.SortingAlgorithms.Common.GetNthDigitFromRight(-456123, 6));
        }
    }
}
