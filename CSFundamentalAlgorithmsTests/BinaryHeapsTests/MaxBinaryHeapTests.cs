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
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentalAlgorithms.BinaryHeaps;

namespace CSFundamentalAlgorithmsTests.BinaryHeapsTests
{
    [TestClass]
    public class MaxBinaryHeapTests
    {
        // Checking the MaxHeap ordering (node relations) for the node at the given index, to make sure the correct relations between the node and its parent and children holds. 
        public static void CheckMaxHeapOrderingPropertyForNode(BinaryHeapBase heap, int nodeIndex)
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
        }

        public static void CheckMaxHeapOrderingPropertyForHeap(int arraySize, MaxBinaryHeap heap)
        {
            for (int i = 0; i < arraySize; i++)
            {
                CheckMaxHeapOrderingPropertyForNode(heap, i);
            }
        }

        [TestMethod]
        public void MaxBinaryHeap_BuildHeap_Recursively_Test()
        {
            List<int> values = new List<int> { 1, 20, 32, 56, 5, 3, 10, 100, 72 };

            MaxBinaryHeap heap = new MaxBinaryHeap(values);
            heap.BuildHeap_Recursively();

            Assert.AreEqual(9, heap.HeapArray.Count);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);
        }

        [TestMethod]
        public void MaxBinaryHeap_BuildHeap_Itratively_Test()
        {
            List<int> values = new List<int> { 1, 20, 32, 56, 5, 3, 10, 100, 72 };

            MaxBinaryHeap heap = new MaxBinaryHeap(values);
            heap.BuildHeap_Iteratively();

            Assert.AreEqual(9, heap.HeapArray.Count);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);
        }

        [TestMethod]
        public void MaxBinaryHeap_TryRemoveRoot_Test()
        {
            List<int> values = new List<int> { 1, 20, 32, 56, 5, 3, 10, 100, 72 };

            MaxBinaryHeap heap = new MaxBinaryHeap(values);
            heap.BuildHeap_Recursively();

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue1));
            Assert.AreEqual(100, maxValue1);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue2));
            Assert.AreEqual(72, maxValue2);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue3));
            Assert.AreEqual(56, maxValue3);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue4));
            Assert.AreEqual(32, maxValue4);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue5));
            Assert.AreEqual(20, maxValue5);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue6));
            Assert.AreEqual(10, maxValue6);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue7));
            Assert.AreEqual(5, maxValue7);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue8));
            Assert.AreEqual(3, maxValue8);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);

            Assert.IsTrue(heap.TryRemoveRoot(out int maxValue9));
            Assert.AreEqual(1, maxValue9);
            CheckMaxHeapOrderingPropertyForHeap(values.Count, heap);
        }
    }
}
