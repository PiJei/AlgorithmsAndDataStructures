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
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.BinaryHeaps.API
{
    [TestClass]
    public class BinaryHeapBaseTests
    {
        private static List<KeyValuePair<int, string>> _keyValues;
        private static MockBinaryHeap<int, string> _heap;

        [TestInitialize]
        public void Init()
        {
            _keyValues = new List<KeyValuePair<int, string>> {
                new KeyValuePair<int, string>(150, "A"),
                new KeyValuePair<int, string>(70, "B"),
                new KeyValuePair<int, string>(202, "C"),
                new KeyValuePair<int, string>(34, "D"),
                new KeyValuePair<int, string>(42, "E"),
                new KeyValuePair<int, string>(1, "F"),
                new KeyValuePair<int, string>(3, "G"),
                new KeyValuePair<int, string>(10, "H"),
                new KeyValuePair<int, string>(21, "I") };

            _heap = new MockBinaryHeap<int, string>(_keyValues);
        }

        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_IndexesInRange_ExpectsSuccessAndCorrectMinIndex()
        {
            bool result = _heap.TryFindIndexOfMinSmallerThanReference(_keyValues, new List<int> { 1, 2 }, 150, out int minValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(1, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_IndexesInRangeAndReferenceMinInteger_ExpectsFailureAndMinIntegerAsIndex()
        {
            bool result = _heap.TryFindIndexOfMinSmallerThanReference(_keyValues, new List<int> { 1, 2 }, int.MinValue, out int minValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MinValue, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_OutOfRangeIndexes_ExpectsFailureAndMinIntegerAsMinIndex()
        {
            bool result = _heap.TryFindIndexOfMinSmallerThanReference(_keyValues, new List<int> { 1, 120 }, 21, out int minValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MinValue, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMinSmallerThanReference_ReferenceIsSmallest_ExpectsFailureAndMinIntegerAsMinIndex()
        {
            bool result = _heap.TryFindIndexOfMinSmallerThanReference(_keyValues, new List<int> { 1, 3 }, 21, out int minValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MinValue, minValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_IndexesInRange_ExpectsSuccessAndCorrectMaxIdex()
        {
            bool result = _heap.TryFindIndexOfMaxBiggerThanReference(_keyValues, _keyValues.Count, new List<int> { 1, 2 }, 150, out int maxValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(2, maxValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_ReferenceIsMaxInteger_ExpectsFailureAndMaxIntegerAsMaxIndex()
        {
            bool result = _heap.TryFindIndexOfMaxBiggerThanReference(_keyValues, _keyValues.Count, new List<int> { 1, 2 }, int.MaxValue, out int maxValueIndex);
            Assert.IsFalse(result);
            Assert.AreEqual(int.MaxValue, maxValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_OneIndexOutOfRange_ExpectsSuccessAndMaxIntegerAsMaxIndex()
        {
            bool result = _heap.TryFindIndexOfMaxBiggerThanReference(_keyValues, _keyValues.Count, new List<int> { 1, 120 }, 21, out int maxValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(1, maxValueIndex);
        }

        [TestMethod]
        public void TryFindIndexOfMaxBiggerThanReference_IndexesInRange_ExpectsSuccessAndCorrectMaxIndex()
        {
            bool result = _heap.TryFindIndexOfMaxBiggerThanReference(_keyValues, _keyValues.Count, new List<int> { 1, 3 }, 21, out int maxValueIndex);
            Assert.IsTrue(result);
            Assert.AreEqual(1, maxValueIndex);
        }
    }
}
