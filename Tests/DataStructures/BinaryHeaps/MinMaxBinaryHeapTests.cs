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
using CSFundamentals.DataStructures.BinaryHeaps;
using CSFundamentals.DataStructures.BinaryHeaps.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.BinaryHeaps
{
    [TestClass]
    public class MinMaxBinaryHeapTests
    {
        [TestMethod]
        public void BuildHeapRecursively_DistinctValues()
        {
            var A = new KeyValuePair<int, string>(70, "A");
            var B = new KeyValuePair<int, string>(21, "B");
            var C = new KeyValuePair<int, string>(220, "C");
            var D = new KeyValuePair<int, string>(10, "D");
            var E = new KeyValuePair<int, string>(1, "E");
            var F = new KeyValuePair<int, string>(34, "F");
            var G = new KeyValuePair<int, string>(3, "G");
            var H = new KeyValuePair<int, string>(150, "H");
            var I = new KeyValuePair<int, string>(85, "I");
            var keyValues = new List<KeyValuePair<int, string>> { A, B, C, D, E, F, G, H, I };

            var heap = new MinMaxBinaryHeap<int, string>(keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            for (int i = 0; i < keyValues.Count; i++)
            {
                int level = heap.GetNodeLevel(i);
                if (heap.IsMinLevel(level))
                {
                    Assert.IsTrue(HasMinMaxOrderPropertyForMinLevel(heap, i));
                }
                else
                {
                    Assert.IsTrue(HasMinMaxOrderPropertyForMaxLevel(heap, i));
                }
            }

            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(A))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(B))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(C))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(D))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(E))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(F))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(G))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(H))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(I))));
        }

        [TestMethod]
        public void BuildHeapRecursively_DuplicateValues()
        {
            var keyValues = new List<KeyValuePair<int, string>> {
                new KeyValuePair<int, string>(39,"A"),
                new KeyValuePair<int, string>(45,"B"),
                new KeyValuePair<int, string>(37,"C"),
                new KeyValuePair<int, string>(45,"D"),
                new KeyValuePair<int, string>(38,"E"),
                new KeyValuePair<int, string>(50,"F"),
                new KeyValuePair<int, string>(59,"G"),
                new KeyValuePair<int, string>(65,"H"),
                new KeyValuePair<int, string>(27,"I"),
                new KeyValuePair<int, string>(25,"J"),
                new KeyValuePair<int, string>(36,"K"),
                new KeyValuePair<int, string>(30,"L"),
                new KeyValuePair<int, string>(57,"M"),
                new KeyValuePair<int, string>(28, "N")};

            var heap = new MinMaxBinaryHeap<int, string>(keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            for (int i = 0; i < keyValues.Count; i++)
            {
                int level = heap.GetNodeLevel(i);
                if (heap.IsMinLevel(level))
                {
                    Assert.IsTrue(HasMinMaxOrderPropertyForMinLevel(heap, i));
                }
                else
                {
                    Assert.IsTrue(HasMinMaxOrderPropertyForMaxLevel(heap, i));
                }
            }
        }

        public static bool HasMinMaxOrderPropertyForMinLevel<TKey, TValue>(BinaryHeapBase<TKey, TValue> heap, int index) where TKey : IComparable<TKey>
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(index);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(index);
            int parentIndex = heap.GetParentIndex(index);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index].Key.CompareTo(heap.HeapArray[leftChildIndex].Key) <= 0);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index].Key.CompareTo(heap.HeapArray[rightChildIndex].Key) <= 0);
            }
            if (parentIndex >= 0 && parentIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index].Key.CompareTo(heap.HeapArray[parentIndex].Key) <= 0);
            }
            return true;
        }

        public static bool HasMinMaxOrderPropertyForMaxLevel<TKey, TValue>(BinaryHeapBase<TKey, TValue> heap, int index) where TKey : IComparable<TKey>
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(index);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(index);
            int parentIndex = heap.GetParentIndex(index);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index].Key.CompareTo(heap.HeapArray[leftChildIndex].Key) >= 0);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index].Key.CompareTo(heap.HeapArray[rightChildIndex].Key) >= 0);
            }
            if (parentIndex >= 0 && parentIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[index].Key.CompareTo(heap.HeapArray[parentIndex].Key) >= 0);
            }
            return true;
        }
    }
}
