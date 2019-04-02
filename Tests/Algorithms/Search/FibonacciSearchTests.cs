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
using CSFundamentals.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.Search
{
    [TestClass]
    public class FibonacciSearchTests
    {
        [TestMethod]
        public void Search_DistinctElements()
        {
            SearchTests.DistinctElements_ExpectsToSuccessfullyGetTheIndexOfTheirPosition(FibonacciSearch.Search);
        }

        [TestMethod]
        public void Search_DuplicateElements()
        {
            SearchTests.DuplicateElements_ExpectsToGetTheIndexOfOneOfTheDupliatesNoMatterHowManyTimeSearchIsPerformed(FibonacciSearch.Search);
        }

        [TestMethod]
        public void Search_NonExistingElements()
        {
            SearchTests.NonExistingElements_ExpectsToGetMinusOne(FibonacciSearch.Search);
        }

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
