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

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.BinaryHeaps.API
{
    [TestClass]
    public class BinaryHeapBaseTests
    {
        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_IndexesInRange_ExpectsSuccessAndCorrectMinIndex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result = heap.TryFindIndexOfMinSmallerThanReference(values, new List<int> { 1, 2 }, 150, out int minValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(1, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_IndexesInRangeAndReferenceMinInteger_ExpectsFailureAndMinIntegerAsIndex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);
            
            bool result = heap.TryFindIndexOfMinSmallerThanReference(values, new List<int> { 1, 2 }, Int32.MinValue, out int minValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MinValue, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_OutOfRangeIndexes_ExpectsFailureAndMinIntegerAsMinIndex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result = heap.TryFindIndexOfMinSmallerThanReference(values, new List<int> { 1, 120 }, 21, out int minValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MinValue, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_ReferenceIsSmallest_ExpectsFailureAndMinIntegerAsMinIndex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result = heap.TryFindIndexOfMinSmallerThanReference(values, new List<int> { 1, 3 }, 21, out int minValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MinValue, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_IndexesInRange_ExpectsSuccessAndCorrectMaxIdex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result = heap.TryFindIndexOfMaxBiggerThanReference(values, values.Count, new List<int> { 1, 2 }, 150, out int maxValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(2, maxValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_ReferenceIsMaxInteger_ExpectsFailureAndMaxIntegerAsMaxIndex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result = heap.TryFindIndexOfMaxBiggerThanReference(values, values.Count, new List<int> { 1, 2 }, Int32.MaxValue, out int maxValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MaxValue, maxValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_OneIndexOutOfRange_ExpectsSuccessAndMaxIntegerAsMaxIndex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result = heap.TryFindIndexOfMaxBiggerThanReference(values, values.Count, new List<int> { 1, 120 }, 21, out int maxValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(1, maxValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_IndexesInRange_ExpectsSuccessAndCorrectMaxIndex()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
            var heap = new MockBinaryHeap<int>(values);

            bool result = heap.TryFindIndexOfMaxBiggerThanReference(values, values.Count, new List<int> { 1, 3 }, 21, out int maxValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(1, maxValueIndex);
        }
    }
}
