#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
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
    /// Tests methods in <see cref="JumpSearch"/> class. 
    /// </summary>
    [TestClass]
    public class JumpSearchTests
    {
        /// <summary>
        /// Tests the correctness of Jump search algorithm on an array with distinct elements. 
        /// To visualize step by step how Jump Search finds a distinct element (int value of 3) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/JumpSearch-Distinct.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DistinctElements()
        {
            SearchTests.DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(JumpSearch.Search);
        }

        /// <summary>
        /// Tests the correctness of Jump search algorithm on an array with duplicate elements. 
        /// To visualize step by step how Jump Search finds a duplicate element (int value of 90) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/JumpSearch-Duplicate.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DuplicateElements()
        {
            SearchTests.DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(JumpSearch.Search);
        }

        /// <summary>
        /// Tests the correctness of Jump search algorithm when the key does not exist in the array.
        /// To visualize step by step how Jump Search terminates without finding a missing element (int value of 15) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/JumpSearch-Missing.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_NotExistingElements()
        {
            SearchTests.NonExistingElements_ExpectsToGetMinusOne(JumpSearch.Search);
        }
    }
}
