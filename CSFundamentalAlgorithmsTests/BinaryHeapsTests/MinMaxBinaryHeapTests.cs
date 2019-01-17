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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CSFundamentalAlgorithms.BinaryHeaps;


namespace CSFundamentalAlgorithmsTests.BinaryHeapsTests
{
    [TestClass]
    public class MinMaxBinaryHeapTests
    {

        public static void CheckMinMaxOrdering_ForMinLevel(BinaryHeapBase heap, int index)
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(index);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(index);
            int parentIndex = heap.GetParentIndex(index);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index] <= heap.HeapArray[leftChildIndex]);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index] <= heap.HeapArray[rightChildIndex]);
            }
            if (parentIndex >= 0 && parentIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index] <= heap.HeapArray[parentIndex]);
            }
        }

        public static void CheckMinMaxOrdering_ForMaxLevel(BinaryHeapBase heap, int index)
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(index);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(index);
            int parentIndex = heap.GetParentIndex(index);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index] >= heap.HeapArray[leftChildIndex]);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index] >= heap.HeapArray[rightChildIndex]);
            }
            if (parentIndex >= 0 && parentIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index] >= heap.HeapArray[parentIndex]);
            }
        }

        [TestMethod]
        public void MinMaxBinaryHeap_BuildHeapRecursively_Test1()
        {
            List<int> values = new List<int> { 70, 21, 220, 10, 1, 34, 3, 150, 85 };
            var heap = new MinMaxBinaryHeap(values);
            heap.BuildHeap_Recursively();

            for (int i = 0; i < values.Count; i++)
            {
                int level = heap.GetNodeLevel(i);
                if (heap.IsMinLevel(level))
                {
                    CheckMinMaxOrdering_ForMinLevel(heap, i);
                }
                else
                {
                    CheckMinMaxOrdering_ForMaxLevel(heap, i);
                }
            }

            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(70))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(21))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(220))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(10))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(1))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(34))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(3))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(150))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(85))));
        }

        [TestMethod]
        public void MinMaxBinaryHeap_BuildHeapRecursively_Test2()
        {
            List<int> values = new List<int> { 39, 45, 37, 45, 38, 50, 59, 65, 27, 25, 36, 30, 57, 28 };
            var heap = new MinMaxBinaryHeap(values);
            heap.BuildHeap_Recursively();

            for (int i = 0; i < values.Count; i++)
            {
                int level = heap.GetNodeLevel(i);
                if (heap.IsMinLevel(level))
                {
                    CheckMinMaxOrdering_ForMinLevel(heap, i);
                }
                else
                {
                    CheckMinMaxOrdering_ForMaxLevel(heap, i);
                }
            }
        }
    }
}
