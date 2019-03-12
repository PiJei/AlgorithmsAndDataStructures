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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSFundamentalsTests.DataStructures.BinaryHeaps
{
    [TestClass]
    public class BinaryHeapBaseTests
    {
        [TestMethod]
        public void BinaryHeap_Swap_Test()
        {
            List<int> values = new List<int> { 10, 34, 56, 2, 12, 1 };
            var heap = new MockBinaryHeap<int>(values);
            heap.Swap(values, 1, 2);
            Assert.AreEqual(6, values.Count);
            Assert.AreEqual(56, values[1]);
            Assert.AreEqual(34, values[2]);
        }

        [TestMethod]
        public void BinaryHeap_TryFindMinIndex_Test()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result1 = heap.TryFindMinIndex(values, new List<int> { 1, 2 }, 150, out int minValueIndex1);
            Assert.IsTrue(result1);
            Assert.AreEqual(1, minValueIndex1);

            bool result2 = heap.TryFindMinIndex(values, new List<int> { 1, 2 }, Int32.MinValue, out int minValueIndex2);
            Assert.IsFalse(result2);
            Assert.AreEqual(int.MinValue, minValueIndex2);

            bool result3 = heap.TryFindMinIndex(values, new List<int> { 1, 120 }, 21, out int minValueIndex3);
            Assert.IsFalse(result3);
            Assert.AreEqual(int.MinValue, minValueIndex3);

            bool result4 = heap.TryFindMinIndex(values, new List<int> { 1, 3 }, 21, out int minValueIndex4);
            Assert.IsFalse(result4);
            Assert.AreEqual(int.MinValue, minValueIndex4);
        }

        [TestMethod]
        public void BinaryHeap_TryFindMaxIndex_Test()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result1 = heap.TryFindMaxIndex(values, values.Count, new List<int> { 1, 2 }, 150, out int maxValueIndex1);
            Assert.IsTrue(result1);
            Assert.AreEqual(2, maxValueIndex1);

            bool result2 = heap.TryFindMaxIndex(values, values.Count, new List<int> { 1, 2 }, Int32.MaxValue, out int maxValueIndex2);
            Assert.IsFalse(result2);
            Assert.AreEqual(int.MaxValue, maxValueIndex2);

            bool result3 = heap.TryFindMaxIndex(values, values.Count, new List<int> { 1, 120 }, 21, out int maxValueIndex3);
            Assert.IsTrue(result3);
            Assert.AreEqual(1, maxValueIndex3);

            bool result4 = heap.TryFindMaxIndex(values, values.Count, new List<int> { 1, 3 }, 21, out int maxValueIndex4);
            Assert.IsTrue(result4);
            Assert.AreEqual(1, maxValueIndex4);
        }
    }
}
