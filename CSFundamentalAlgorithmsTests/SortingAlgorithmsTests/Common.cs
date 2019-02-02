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

namespace CSFundamentalAlgorithmsTests.SortingAlgorithmsTests
{
    public class Common
    {
        /// <summary>
        /// Is an array of integers with only distinct values. 
        /// </summary>
        public static readonly List<int> ArrayWithDistinctValues = new List<int> { 100, 2, 3, 1, 56, 78, 209, 46, 21, 10, 12, 15, 51 };

        /// <summary>
        /// Is an array of integers with duplicate values. 
        /// </summary>
        public static List<int> ArrayWithDuplicateValues = new List<int> { 100, 2, 3, 1, 56, 78, 209, 21, 46, 78, 10, 12, 1, 51, 15 };

        /// <summary>
        /// Is an array of integers with distinct values, such that the array is already sorted ascending. 
        /// </summary>
        public static List<int> ArrayWithSortedDistinctValues = new List<int> { 1, 2, 3, 10, 12, 15, 21, 46, 51, 56, 78, 100, 209 };

        /// <summary>
        /// Is an array of integers with duplicate values, such that the array is already sorted ascending. 
        /// </summary>
        public static List<int> ArrayWithSortedDuplicateValues = new List<int> { 1, 2, 3, 10, 12, 15, 21, 21, 46, 51, 56, 78, 100, 209 };

        /// <summary>
        /// Is an array of integers with distinct values, such that the array is reversly sorted, meaning it is descending, whereas sort meant ascending.  
        /// </summary>
        public static List<int> ArrayWithReverselySortedDistinctValues = new List<int> { 209, 100, 78, 56, 51, 46, 21, 15, 12, 10, 3, 2, 1 };

        /// <summary>
        /// Is an array of integers with duplicate values, such that the array is reversly sorted, meaning it is descending, whereas sort meant ascending. 
        /// </summary>
        public static List<int> ArrayWithReverselySortedDuplicateValues = new List<int> { 209, 100, 78, 56, 51, 46, 21, 21, 15, 12, 10, 3, 2, 1, 1 };

        // TODO: Measure the timing for each case, ... 

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
    }
}
