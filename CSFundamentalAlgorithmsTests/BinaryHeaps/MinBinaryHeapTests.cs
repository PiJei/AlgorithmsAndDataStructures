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
using System;
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

        // Checking the MinHeap properties (node relations) for each value, to make sure the correct relations between the node and its parent and children holds. 
        private void CheckHeapPropertyForNode(List<int> heapArray, int nodeIndex)
        {
            int leftChildIndex = MinBinaryHeap.GetLeftChildIndexInHeapArray(nodeIndex);
            int rightChildIndex = MinBinaryHeap.GetRightChildIndexInHeapArray(nodeIndex);
            int parentindex = MinBinaryHeap.GetParentIndex(nodeIndex);

            if (leftChildIndex < heapArray.Count)
            {
                Assert.IsTrue(heapArray[nodeIndex] <= heapArray[leftChildIndex]);
            }
            if (rightChildIndex < heapArray.Count)
            {
                Assert.IsTrue(heapArray[nodeIndex] <= heapArray[rightChildIndex]);
            }
            if (parentindex < heapArray.Count)
            {
                Assert.IsTrue(heapArray[nodeIndex] >= heapArray[parentindex]);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapRecursive_Test1()
        {
            MinBinaryHeap.BuildMinHeap_Recursive(arrayHeap1RecursivelyBuilt);

            Assert.AreEqual(6, arrayHeap1RecursivelyBuilt.Count);

            for (int i = 0; i < arrayHeap1RecursivelyBuilt.Count; i++)
            {
                CheckHeapPropertyForNode(arrayHeap1RecursivelyBuilt, i);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapRecursive_Test2()
        {
            MinBinaryHeap.BuildMinHeap_Recursive(arrayHeap2RecursivelyBuilt);

            Assert.AreEqual(9, arrayHeap2RecursivelyBuilt.Count);

            for (int i = 0; i < arrayHeap2RecursivelyBuilt.Count; i++)
            {
                CheckHeapPropertyForNode(arrayHeap2RecursivelyBuilt, i);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapIterative_Test1()
        {
            MinBinaryHeap.BuildMinHeap_Iterative(arrayHeap1IterativelyBuilt);

            Assert.AreEqual(6, arrayHeap1IterativelyBuilt.Count);

            for (int i = 0; i < arrayHeap1IterativelyBuilt.Count; i++)
            {
                CheckHeapPropertyForNode(arrayHeap1IterativelyBuilt, i);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_BuildHeapIterative_Test2()
        {
            Assert.AreEqual(9, arrayHeap2IterativelyBuilt.Count);

            MinBinaryHeap.BuildMinHeap_Iterative(arrayHeap2IterativelyBuilt);

            for (int i = 0; i < arrayHeap2IterativelyBuilt.Count; i++)
            {
                CheckHeapPropertyForNode(arrayHeap2IterativelyBuilt, i);
            }
        }

        //Expect the two versions, recursive and iterative, to construct the same heaps. 
        [TestMethod]
        public void CompareEqualityOfRecursiveAndIterativeMinHeapConstruction()
        {
            MinBinaryHeap.BuildMinHeap_Iterative(arrayHeap1IterativelyBuilt);
            MinBinaryHeap.BuildMinHeap_Iterative(arrayHeap2IterativelyBuilt);
            MinBinaryHeap.BuildMinHeap_Recursive(arrayHeap1RecursivelyBuilt);
            MinBinaryHeap.BuildMinHeap_Recursive(arrayHeap2RecursivelyBuilt);

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

            MinBinaryHeap.BuildMinHeap_Iterative(values);

            // The values in the array are expected to be removed in ascending order. 
            bool result1 = MinBinaryHeap.TryRemoveMin(values, out int min1);
            Assert.IsTrue(result1);
            Assert.AreEqual(1, min1);

            bool result2 = MinBinaryHeap.TryRemoveMin(values, out int min2);
            Assert.IsTrue(result2);
            Assert.AreEqual(3, min2);

            bool result3 = MinBinaryHeap.TryRemoveMin(values, out int min3);
            Assert.IsTrue(result3);
            Assert.AreEqual(10, min3);

            bool result4 = MinBinaryHeap.TryRemoveMin(values, out int min4);
            Assert.IsTrue(result4);
            Assert.AreEqual(21, min4);

            bool result5 = MinBinaryHeap.TryRemoveMin(values, out int min5);
            Assert.IsTrue(result5);
            Assert.AreEqual(34, min5);

            bool result6 = MinBinaryHeap.TryRemoveMin(values, out int min6);
            Assert.IsTrue(result6);
            Assert.AreEqual(42, min6);

            bool result7 = MinBinaryHeap.TryRemoveMin(values, out int min7);
            Assert.IsTrue(result7);
            Assert.AreEqual(70, min7);

            bool result8 = MinBinaryHeap.TryRemoveMin(values, out int min8);
            Assert.IsTrue(result8);
            Assert.AreEqual(150, min8);

            bool result9 = MinBinaryHeap.TryRemoveMin(values, out int min9);
            Assert.IsTrue(result9);
            Assert.AreEqual(202, min9);
        }

        [TestMethod]
        public void MinBinaryHeap_Insert_Test()
        {
            List<int> values = new List<int>();

            // Inserting these values: { 150, 70, 202, 34, 42, 1, 3, 10, 21 };

            MinBinaryHeap.Insert(150, values);
            Assert.AreEqual(1, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(70, values);
            Assert.AreEqual(2, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(202, values);
            Assert.AreEqual(3, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(34, values);
            Assert.AreEqual(4, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(42, values);
            Assert.AreEqual(5, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(1, values);
            Assert.AreEqual(6, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(3, values);
            Assert.AreEqual(7, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(10, values);
            Assert.AreEqual(8, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }

            MinBinaryHeap.Insert(21, values);
            Assert.AreEqual(9, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                CheckHeapPropertyForNode(values, i);
            }
        }

        [TestMethod]
        public void MinBinaryHeap_Swap_Test()
        {
            List<int> values = new List<int> { 10, 34, 56, 2, 12, 1 };
            MinBinaryHeap.Swap(values, 1, 2);
            Assert.AreEqual(6, values.Count);
            Assert.AreEqual(56, values[1]);
            Assert.AreEqual(34, values[2]);
        }

        [TestMethod]
        public void MinBinaryHeap_TryFindMinIndex_Test()
        {
            List<int> values = new List<int> { 150, 70, 202, 34, 42, 1, 3, 10, 21 };

            bool result1 = MinBinaryHeap.TryFindMinIndex(values, 1, 2, 150, out int minValueIndex1);
            Assert.IsTrue(result1);
            Assert.AreEqual(1, minValueIndex1);

            bool result2 = MinBinaryHeap.TryFindMinIndex(values, 1, 2, Int32.MinValue, out int minValueIndex2);
            Assert.IsFalse(result2);
            Assert.AreEqual(int.MinValue, minValueIndex2);

            bool result3 = MinBinaryHeap.TryFindMinIndex(values, 1, 120, 21, out int minValueIndex3);
            Assert.IsFalse(result3);
            Assert.AreEqual(int.MinValue, minValueIndex3);

            bool result4 = MinBinaryHeap.TryFindMinIndex(values, 1, 3, 21, out int minValueIndex4);
            Assert.IsFalse(result4);
            Assert.AreEqual(int.MinValue, minValueIndex4);
        }


        // Also test the out put of the iterative and recursive methods are equal!
    }
}
