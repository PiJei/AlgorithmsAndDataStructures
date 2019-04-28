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
using CSFundamentals.DataStructures.BinaryHeaps;
using CSFundamentals.DataStructures.BinaryHeaps.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.BinaryHeaps
{
    [TestClass]
    public class MaxBinaryHeapTests
    {
        private static readonly KeyValuePair<int, string> _A = new KeyValuePair<int, string>(1, "A");
        private static readonly KeyValuePair<int, string> _B = new KeyValuePair<int, string>(20, "B");
        private static readonly KeyValuePair<int, string> _C = new KeyValuePair<int, string>(32, "C");
        private static readonly KeyValuePair<int, string> _D = new KeyValuePair<int, string>(56, "D");
        private static readonly KeyValuePair<int, string> _E = new KeyValuePair<int, string>(5, "E");
        private static readonly KeyValuePair<int, string> _F = new KeyValuePair<int, string>(3, "F");
        private static readonly KeyValuePair<int, string> _G = new KeyValuePair<int, string>(10, "G");
        private static readonly KeyValuePair<int, string> _H = new KeyValuePair<int, string>(100, "H");
        private static readonly KeyValuePair<int, string> _I = new KeyValuePair<int, string>(72, "I");

        private static List<KeyValuePair<int, string>> _keyValues;

        /// <summary>
        /// Initializes/Resets variables before executing each unit test in this class. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _keyValues = new List<KeyValuePair<int, string>> { _A, _B, _C, _D, _E, _F, _G, _H, _I };
        }

        [TestMethod]
        public void BuildHeap_Recursively()
        {
            var heap = new MaxBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));
        }

        [TestMethod]
        public void BuildHeap_Itratively()
        {
            var heap = new MaxBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Iteratively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));
        }

        [TestMethod]
        public void TryRemoveRoot_RemoveRootEqualToArrayLengthTimes_ExpectDescendingOrderInResults()
        {
            var heap = new MaxBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue1, heap.HeapArray.Count));
            Assert.AreEqual(100, maxValue1.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue2, heap.HeapArray.Count));
            Assert.AreEqual(72, maxValue2.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue3, heap.HeapArray.Count));
            Assert.AreEqual(56, maxValue3.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue4, heap.HeapArray.Count));
            Assert.AreEqual(32, maxValue4.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue5, heap.HeapArray.Count));
            Assert.AreEqual(20, maxValue5.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue6, heap.HeapArray.Count));
            Assert.AreEqual(10, maxValue6.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue7, heap.HeapArray.Count));
            Assert.AreEqual(5, maxValue7.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue8, heap.HeapArray.Count));
            Assert.AreEqual(3, maxValue8.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue9, heap.HeapArray.Count));
            Assert.AreEqual(1, maxValue9.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));
        }

        [TestMethod]
        public void Insert_SeveralValues_ExpectCorrectMaxBinaryHeapAfterEachInsert()
        {
            var heap = new MaxBinaryHeap<int, string>(new List<KeyValuePair<int, string>> { });

            heap.Insert(_A, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_B, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_C, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_D, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_E, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_F, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_G, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_H, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(_I, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(heap.HeapArray.Count, heap));
        }

        // Checking the MaxHeap ordering (node relations) for the node at the given index, to make sure the correct relations between the node and its parent and children holds. 
        public static bool HasMaxOrderPropertyForNode<TKey, TValue>(BinaryHeapBase<TKey, TValue> heap, int nodeIndex) where TKey : IComparable<TKey>
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(nodeIndex);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(nodeIndex);
            int parentindex = heap.GetParentIndex(nodeIndex);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[leftChildIndex].Key) >= 0);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[rightChildIndex].Key) >= 0);
            }
            if (parentindex >= 0 && parentindex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[parentindex].Key) <= 0);
            }
            return true;
        }

        public static bool HasMaxOrderPropertyForHeap<TKey, TValue>(int arraySize, MaxBinaryHeap<TKey, TValue> heap) where TKey : IComparable<TKey>
        {
            for (int i = 0; i < arraySize; i++)
            {
                HasMaxOrderPropertyForNode(heap, i);
            }
            return true;
        }
    }
}
