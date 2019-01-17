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

using CSFundamentalAlgorithms.BinaryHeaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CSFundamentalAlgorithmsTests.BinaryHeapsTests
{
    [TestClass]
    public class MinBinaryHeapTests
    {
        private List<int> arrayHeap1RecursivelyBuilt = new List<int> { 9, 6, 1, 8, 3, 5 };
        private List<int> arrayHeap1IterativelyBuilt = new List<int> { 9, 6, 1, 8, 3, 5 };

        private List<int> arrayHeap2RecursivelyBuilt = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };
        private List<int> arrayHeap2IterativelyBuilt = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };

        // Checking the MinHeap ordering (node relations) for the node at the given index, to make sure the correct relations between the node and its parent and children holds. 
        public static void CheckMinHeapOrderingPropertyForNode(MinBinaryHeap heap, int nodeIndex)
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(nodeIndex);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(nodeIndex);
            int parentindex = heap.GetParentIndex(nodeIndex);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex] <= heap.HeapArray[leftChildIndex]);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex] <= heap.HeapArray[rightChildIndex]);
            }
            if (parentindex >= 0 && parentindex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex] >= heap.HeapArray[parentindex]);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapRecursive_Test1()
        {
            var heap = new MinBinaryHeap(arrayHeap1RecursivelyBuilt);
            heap.BuildHeap_Recursively();

            Assert.AreEqual(6, arrayHeap1RecursivelyBuilt.Count);

            for (int i = 0; i < arrayHeap1RecursivelyBuilt.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapRecursive_Test2()
        {
            var heap = new MinBinaryHeap(arrayHeap2RecursivelyBuilt);
            heap.BuildHeap_Recursively();

            Assert.AreEqual(9, arrayHeap2RecursivelyBuilt.Count);

            for (int i = 0; i < arrayHeap2RecursivelyBuilt.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapIterative_Test1()
        {
            var heap = new MinBinaryHeap(arrayHeap1IterativelyBuilt);
            heap.BuildHeap_Iteratively();

            Assert.AreEqual(6, arrayHeap1IterativelyBuilt.Count);

            for (int i = 0; i < arrayHeap1IterativelyBuilt.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapIterative_Test2()
        {
            var heap = new MinBinaryHeap(arrayHeap2IterativelyBuilt);
            heap.BuildHeap_Iteratively();

            Assert.AreEqual(9, arrayHeap2IterativelyBuilt.Count);

            for (int i = 0; i < arrayHeap2IterativelyBuilt.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }
        }

        //Expect the two versions, recursive and iterative, to construct the same heaps. 
        [TestMethod]
        public void CompareEqualityOfRecursiveAndIterativeMinHeapConstruction()
        {
            var heap1 = new MinBinaryHeap(arrayHeap1IterativelyBuilt); heap1.BuildHeap_Iteratively();
            var heap2 = new MinBinaryHeap(arrayHeap2IterativelyBuilt); heap2.BuildHeap_Iteratively();
            var heap3 = new MinBinaryHeap(arrayHeap1RecursivelyBuilt); heap3.BuildHeap_Recursively();
            var heap4 = new MinBinaryHeap(arrayHeap2RecursivelyBuilt); heap4.BuildHeap_Recursively();

            for (int i = 0; i < arrayHeap1IterativelyBuilt.Count; i++)
            {
                Assert.AreEqual(arrayHeap1IterativelyBuilt[i], arrayHeap1RecursivelyBuilt[i]);
            }

            for (int i = 0; i < arrayHeap2IterativelyBuilt.Count; i++)
            {
                Assert.AreEqual(arrayHeap2IterativelyBuilt[i], arrayHeap2RecursivelyBuilt[i]);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_TryRemoveMin_Test1()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };

            var heap = new MinBinaryHeap(values);
            heap.BuildHeap_Iteratively();

            // The values in the array are expected to be removed in ascending order. 
            bool result1 = heap.TryRemoveRoot(out int min1);
            Assert.IsTrue(result1);
            Assert.AreEqual(1, min1);

            bool result2 = heap.TryRemoveRoot(out int min2);
            Assert.IsTrue(result2);
            Assert.AreEqual(3, min2);

            bool result3 = heap.TryRemoveRoot(out int min3);
            Assert.IsTrue(result3);
            Assert.AreEqual(10, min3);

            bool result4 = heap.TryRemoveRoot(out int min4);
            Assert.IsTrue(result4);
            Assert.AreEqual(21, min4);

            bool result5 = heap.TryRemoveRoot(out int min5);
            Assert.IsTrue(result5);
            Assert.AreEqual(34, min5);

            bool result6 = heap.TryRemoveRoot(out int min6);
            Assert.IsTrue(result6);
            Assert.AreEqual(42, min6);

            bool result7 = heap.TryRemoveRoot(out int min7);
            Assert.IsTrue(result7);
            Assert.AreEqual(70, min7);

            bool result8 = heap.TryRemoveRoot(out int min8);
            Assert.IsTrue(result8);
            Assert.AreEqual(150, min8);

            bool result9 = heap.TryRemoveRoot(out int min9);
            Assert.IsTrue(result9);
            Assert.AreEqual(202, min9);
        }

        [TestMethod]
        public void MinBinaryHeap_Insert_Test()
        {
            List<int> values = new List<int>();
            var heap = new MinBinaryHeap(values);

            // Inserting these values: { 150, 70, 202, 34, 42, 1, 3, 10, 21 };

            heap.Insert(150);
            Assert.AreEqual(1, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(70);
            Assert.AreEqual(2, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(202);
            Assert.AreEqual(3, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(34);
            Assert.AreEqual(4, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(42);
            Assert.AreEqual(5, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(1);
            Assert.AreEqual(6, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(3);
            Assert.AreEqual(7, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(10);
            Assert.AreEqual(8, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }

            heap.Insert(21);
            Assert.AreEqual(9, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckMinHeapOrderingPropertyForNode(heap, i);
            }
        }
    }
}
