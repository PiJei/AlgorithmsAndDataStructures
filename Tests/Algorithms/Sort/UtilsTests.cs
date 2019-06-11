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
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO: Rename this class, 

namespace AlgorithmsAndDataStructuresTests.Algorithms.Sort
{
    /// <summary>
    /// Tests methods in <see cref="Utils"/> class.
    /// </summary>
    public partial class UtilsTests
    {
        /// <summary>
        /// Checks whether the given integer list is sorted in ascending order. 
        /// </summary>
        public static bool IsSortedAscendingly(List<int> values)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                Assert.IsTrue(values[i] <= values[i + 1]);
            }
            return true;
        }

        /// <summary>
        /// Tests the correctness of computing number of digits in an integer. 
        /// </summary>
        [TestMethod]
        public void GetDigitsCount()
        {
            Assert.AreEqual(3, Utils.GetDigitsCount(123));
            Assert.AreEqual(1, Utils.GetDigitsCount(9));
            Assert.AreEqual(1, Utils.GetDigitsCount(0));
            Assert.AreEqual(6, Utils.GetDigitsCount(456123));
            Assert.AreEqual(7, Utils.GetDigitsCount(1230000));
            Assert.AreEqual(2, Utils.GetDigitsCount(45));
        }

        /// <summary>
        /// Tests the correctness of computing the n(th) digit of a number from right. 
        /// </summary>
        [TestMethod]
        public void GetNthDigitFromRight()
        {
            Assert.AreEqual(3, Utils.GetNthDigitFromRight(123, 1));
            Assert.AreEqual(2, Utils.GetNthDigitFromRight(123, 2));
            Assert.AreEqual(1, Utils.GetNthDigitFromRight(123, 3));
            Assert.AreEqual(0, Utils.GetNthDigitFromRight(123, 4));

            Assert.AreEqual(9, Utils.GetNthDigitFromRight(9, 1));
            Assert.AreEqual(0, Utils.GetNthDigitFromRight(9, 2));
            Assert.AreEqual(0, Utils.GetNthDigitFromRight(9, 3));
            Assert.AreEqual(0, Utils.GetNthDigitFromRight(9, 0));

            Assert.AreEqual(0, Utils.GetNthDigitFromRight(0, 1));
            Assert.AreEqual(0, Utils.GetNthDigitFromRight(0, 0));

            Assert.AreEqual(4, Utils.GetNthDigitFromRight(-456123, 6));
        }
    }
}
