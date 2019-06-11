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
using AlgorithmsAndDataStructures.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.Algorithms.Search
{
    /// <summary>
    /// Tests the methods in <see cref="BinarySearch"/> class. 
    /// </summary>
    [TestClass]
    public class BinarySearchTests
    {
        /// <summary>
        /// Tests the correctness of binary search algorithm on an array with distinct elements. 
        /// To visualize step by step how Binary Search finds a distinct element (int value of 3) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/BinarySearch-Distinct.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DistinctElements()
        {
            SearchTests.DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(BinarySearch.Search);
        }

        /// <summary>
        /// Tests the correctness of binary search algorithm on an array with duplicate elements. 
        /// To visualize step by step how Binary Search finds a duplicate element (int value of 90) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/BinarySearch-Duplicate.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DuplicateElements()
        {
            SearchTests.DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(BinarySearch.Search);
        }

        /// <summary>
        /// Tests the correctness of binary search algorithm when the key does not exist in the array. 
        /// To visualize step by step how Binary Search terminates without finding a missing element (int value of 15) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/BinarySearch-Missing.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_NonExistingElements()
        {
            SearchTests.NonExistingElements_ExpectsToGetMinusOne(BinarySearch.Search);
        }
    }
}
