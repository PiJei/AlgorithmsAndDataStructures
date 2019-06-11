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
    /// Tests methods in <see cref=" FibonacciSearch"/> class. 
    /// </summary>
    [TestClass]
    public class FibonacciSearchTests
    {
        /// <summary>
        /// Tests the correctness of Fibonacci search algorithm on an array with distinct elements. 
        /// To visualize step by step how Fibonacci Search finds a distinct element (int value of 3) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/FibonacciSearch-Distinct.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DistinctElements()
        {
            SearchTests.DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(FibonacciSearch.Search);
        }

        /// <summary>
        /// Tests the correctness of Fibonacci search algorithm on an array with duplicate elements. 
        /// To visualize step by step how Fibonacci Search finds a duplicate element (int value of 90) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/FibonacciSearch-Duplicate.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_DuplicateElements()
        {
            SearchTests.DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(FibonacciSearch.Search);
        }

        /// <summary>
        /// Tests the correctness of Fibonacci search algorithm when the key does not exist in the array. 
        /// To visualize step by step how Fibonacci Search terminates without finding a missing element (int value of 15) in <see cref="SearchTests.List"/> see: <img src = "../Images/Search/FibonacciSearch-Missing.png"/>.
        /// </summary>
        [TestMethod]
        public void Search_NonExistingElements()
        {
            SearchTests.NonExistingElements_ExpectsToGetMinusOne(FibonacciSearch.Search);
        }

        /// <summary>
        /// Tests computing the smallest Fibonacci number that is bigger than a specific number. 
        /// </summary>
        [TestMethod]
        public void GetSmallestFibonacciBiggerThanNumber()
        {
            Assert.AreEqual(1, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(0).FibN);
            Assert.AreEqual(144, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(143).FibN);
            Assert.AreEqual(13, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(10).FibN);

            Assert.AreEqual(13, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(12).FibN);
            Assert.AreEqual(8, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(12).FibN1);
            Assert.AreEqual(5, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(12).FibN2);
        }
    }
}
