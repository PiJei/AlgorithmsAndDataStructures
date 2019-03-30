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
using CSFundamentals.DataStructures.BinaryHeaps;
using CSFundamentals.DataStructures.BinaryHeaps.API;

namespace CSFundamentalsTests.DataStructures.BinaryHeaps
{
    [TestClass]
    public class MaxBinaryHeapTests
    {
        // Checking the MaxHeap ordering (node relations) for the node at the given index, to make sure the correct relations between the node and its parent and children holds. 
        public static bool HasMaxHeapOrderingPropertyForNode(BinaryHeapBase<int> heap, int nodeIndex)
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(nodeIndex);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(nodeIndex);
            int parentindex = heap.GetParentIndex(nodeIndex);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex] >= heap.HeapArray[leftChildIndex]);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex] >= heap.HeapArray[rightChildIndex]);
            }
            if (parentindex >= 0 && parentindex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex] <= heap.HeapArray[parentindex]);
            }
            return true;
        }

        public static bool HasMaxHeapOrderingPropertyForHeap(int arraySize, MaxBinaryHeap<int> heap)
        {
            for (int i = 0; i < arraySize; i++)
            {
                HasMaxHeapOrderingPropertyForNode(heap, i);
            }
            return true;
        }

        [TestMethod]
        public void BuildHeap_Recursively()
        {
            List<int> values = new List<int> { 1, 20, 32, 56, 5, 3, 10, 100, 72 };

            MaxBinaryHeap<int> heap = new MaxBinaryHeap<int>(values);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));
        }

        [TestMethod]
        public void BuildHeap_Itratively()
        {
            List<int> values = new List<int> { 1, 20, 32, 56, 5, 3, 10, 100, 72 };

            MaxBinaryHeap<int> heap = new MaxBinaryHeap<int>(values);
            heap.BuildHeap_Iteratively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));
        }

        [TestMethod]
        public void TryRemoveRoot()
        {
            List<int> values = new List<int> { 1, 20, 32, 56, 5, 3, 10, 100, 72 };

            MaxBinaryHeap<int> heap = new MaxBinaryHeap<int>(values);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue1, heap.HeapArray.Count));
            Assert.AreEqual(100, maxValue1);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue2, heap.HeapArray.Count));
            Assert.AreEqual(72, maxValue2);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue3, heap.HeapArray.Count));
            Assert.AreEqual(56, maxValue3);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue4, heap.HeapArray.Count));
            Assert.AreEqual(32, maxValue4);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue5, heap.HeapArray.Count));
            Assert.AreEqual(20, maxValue5);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue6, heap.HeapArray.Count));
            Assert.AreEqual(10, maxValue6);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue7, heap.HeapArray.Count));
            Assert.AreEqual(5, maxValue7);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue8, heap.HeapArray.Count));
            Assert.AreEqual(3, maxValue8);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue9, heap.HeapArray.Count));
            Assert.AreEqual(1, maxValue9);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(values.Count, heap));
        }

        [TestMethod]
        public void Insert()
        {
            MaxBinaryHeap<int> heap = new MaxBinaryHeap<int>(new List<int> { });
            heap.Insert(1, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(20, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(32, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(56, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(5, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(3, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(10, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(100, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));

            heap.Insert(72, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxHeapOrderingPropertyForHeap(heap.HeapArray.Count, heap));
        }
    }
}
