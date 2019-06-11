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
    /// Tests methods in <see cref="ExponentialSearch"/> class. 
    /// </summary>
    [TestClass]
    public class ExponentialSearchTests
    {
        /// <summary>
        /// Tests the correctness of Exponential search algorithm on an array with distinct elements.
        /// To visualize step by step how Exponential Search finds a distinct element (int value of 3) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/ExponentialSearch-Distinct.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DistinctElements()
        {
            SearchTests.DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(ExponentialSearch.Search);
        }

        /// <summary>
        /// Tests the correctness of Exponential search algorithm on an array with duplicate elements. 
        /// To visualize step by step how Exponential Search finds a duplicate element (int value of 90) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/ExponentialSearch-Duplicate.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DuplicateElements()
        {
            SearchTests.DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(ExponentialSearch.Search);
        }

        /// <summary>
        /// Tests the correctness of Exponential search algorithm when the key does not exist in the array. 
        /// To visualize step by step how Exponential Search terminates without finding a missing element (int value of 15) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/ExponentialSearch-Missing.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_NotExistingElements()
        {
            SearchTests.NonExistingElements_ExpectsToGetMinusOne(ExponentialSearch.Search);
        }
    }
}
