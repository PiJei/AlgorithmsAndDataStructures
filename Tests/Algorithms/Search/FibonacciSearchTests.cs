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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.Algorithms.Search;

namespace CSFundamentalsTests.Search
{
    [TestClass]
    public class FibonacciSearchTests
    {
        [TestMethod]
        public void Search()
        {
            // TODO: Investigate: Fibonacci search for duplicates, will return the biggest index, as it searches close to the end?
            List<int> values = new List<int> { 1, 1, 3, 10, 14, 25, 27, 34, 78, 90, 90, 120 };
            Assert.AreEqual(13, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(values.Count).FibN);
            Assert.AreEqual(8, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(values.Count).FibN1);
            Assert.AreEqual(5, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(values.Count).FibN2);

            Assert.AreEqual(11, FibonacciSearch.Search(values, 120));
            Assert.AreEqual(1, FibonacciSearch.Search(values, 1)); // TODO: Investigate returns index 1 rather than 0, as always looks more to the end of the array. (by starting from the smallest fib number that is bigger than the array size)
            Assert.AreEqual(2, FibonacciSearch.Search(values, 3));
            Assert.AreEqual(3, FibonacciSearch.Search(values, 10));
            Assert.AreEqual(4, FibonacciSearch.Search(values, 14));
            Assert.AreEqual(5, FibonacciSearch.Search(values, 25));
            Assert.AreEqual(6, FibonacciSearch.Search(values, 27));
            Assert.AreEqual(7, FibonacciSearch.Search(values, 34));
            Assert.AreEqual(8, FibonacciSearch.Search(values, 78));
            Assert.AreEqual(9, FibonacciSearch.Search(values, 90)); // TODO: Investigate Why returns index 9 and not 10. 
            Assert.AreEqual(-1, FibonacciSearch.Search(values, -20));
            Assert.AreEqual(-1, FibonacciSearch.Search(values, 15));
            Assert.AreEqual(-1, FibonacciSearch.Search(values, 456));
        }

        [TestMethod]
        public void GetSmallestFibonacciBiggerThanNumber()
        {
            Assert.AreEqual(1, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(0).FibN);
            Assert.AreEqual(144, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(143).FibN);
            Assert.AreEqual(13, FibonacciSearch.GetSmallestFibonacciBiggerThanNumber(10).FibN);
        }
    }
}
