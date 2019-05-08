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

//TODO: Test insert and delete operations, ... 
namespace CSFundamentalsTests.DataStructures.BinaryHeaps
{
    /// <summary>
    /// Tests methods in <see cref="MinMaxBinaryHeap{TKey, TValue}"/> class.
    /// </summary>
    [TestClass]
    public class MinMaxBinaryHeapTests
    {
        /// <summary>
        /// Tests the correctness of Build operation recursive version, when inserting distinct values. 
        /// </summary>
        [TestMethod]
        public void BuildHeapRecursively_DistinctValues()
        {
            var nodeA = new KeyValuePair<int, string>(70, "A");
            var nodeB = new KeyValuePair<int, string>(21, "B");
            var nodeC = new KeyValuePair<int, string>(220, "C");
            var nodeD = new KeyValuePair<int, string>(10, "D");
            var nodeE = new KeyValuePair<int, string>(50, "E");
            var nodeF = new KeyValuePair<int, string>(34, "F");
            var nodeG = new KeyValuePair<int, string>(300, "G");
            var nodeH = new KeyValuePair<int, string>(150, "H");
            var nodeI = new KeyValuePair<int, string>(2, "I");
            var keyValues = new List<KeyValuePair<int, string>> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };

            var heap = new MinMaxBinaryHeap<int, string>(keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, keyValues.Count));

            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeA))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeB))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeC))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeD))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeE))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeF))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeG))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeH))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(keyValues.IndexOf(nodeI))));
        }

        /// <summary>
        /// Tests the correctness of Build operation, recursive version when inserting duplicate values. 
        /// To visualize in-place MinMax Binary Heap building process see <img src = "../Images/Heaps/MinMaxHeap-Build-WithDuplicateKeys.png"/>.
        /// </summary>
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
            Assert.IsTrue(HasMinMaxHeapProperty(heap, keyValues.Count));
        }

        /// <summary>
        /// Tests the correctness of Insert operation when inserting several keys one after the other in the MinMaxBinary binary heap. 
        /// To visualize the steps in this test method see <img src = "../Images/Heaps/MinMaxBinaryHeap-Insert.png"/>.
        /// </summary>
        [TestMethod]
        public void Insert_SeveralValues_ExpectCorrectMinMaxBinaryHeapAfterEachInsert()
        {
            var values = new List<KeyValuePair<int, string>>();
            var heap = new MinMaxBinaryHeap<int, string>(values);

            heap.Insert(new KeyValuePair<int, string>(70, "A"), heap.HeapArray.Count);
            Assert.AreEqual(1, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 1));

            heap.Insert(new KeyValuePair<int, string>(21, "B"), heap.HeapArray.Count);
            Assert.AreEqual(2, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 2));

            heap.Insert(new KeyValuePair<int, string>(220, "C"), heap.HeapArray.Count);
            Assert.AreEqual(3, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 3));

            heap.Insert(new KeyValuePair<int, string>(10, "D"), heap.HeapArray.Count);
            Assert.AreEqual(4, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 4));

            heap.Insert(new KeyValuePair<int, string>(50, "E"), heap.HeapArray.Count);
            Assert.AreEqual(5, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 5));

            heap.Insert(new KeyValuePair<int, string>(34, "F"), heap.HeapArray.Count);
            Assert.AreEqual(6, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 6));

            heap.Insert(new KeyValuePair<int, string>(300, "G"), heap.HeapArray.Count);
            Assert.AreEqual(7, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 7));

            heap.Insert(new KeyValuePair<int, string>(150, "H"), heap.HeapArray.Count);
            Assert.AreEqual(8, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 8));

            heap.Insert(new KeyValuePair<int, string>(2, "I"), heap.HeapArray.Count);
            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 9));
        }

        /// <summary>
        /// Tests the correctness of removing root of the heap. Removes root several times until no member in tree remains.
        /// To visualize the steps in this test method see <img src = "../Images/Heaps/MinMaxBinaryHeap-TryRemoveRoot.png"/>.
        /// </summary>
        [TestMethod]
        public void TryRemoveRoot_RemoveRoot_SeveralTimes_ExpectDescendingOrderInResults()
        {
            var nodeA = new KeyValuePair<int, string>(70, "A");
            var nodeB = new KeyValuePair<int, string>(21, "B");
            var nodeC = new KeyValuePair<int, string>(220, "C");
            var nodeD = new KeyValuePair<int, string>(10, "D");
            var nodeE = new KeyValuePair<int, string>(50, "E");
            var nodeF = new KeyValuePair<int, string>(34, "F");
            var nodeG = new KeyValuePair<int, string>(300, "G");
            var nodeH = new KeyValuePair<int, string>(150, "H");
            var nodeI = new KeyValuePair<int, string>(2, "I");
            var keyValues = new List<KeyValuePair<int, string>> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };

            var heap = new MinMaxBinaryHeap<int, string>(keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 9));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> value1, heap.HeapArray.Count));
            Assert.AreEqual(2, value1.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 8));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue2, heap.HeapArray.Count));
            Assert.AreEqual(10, maxValue2.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 7));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue3, heap.HeapArray.Count));
            Assert.AreEqual(21, maxValue3.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 6));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue4, heap.HeapArray.Count));
            Assert.AreEqual(34, maxValue4.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 5));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue5, heap.HeapArray.Count));
            Assert.AreEqual(50, maxValue5.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 4));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue6, heap.HeapArray.Count));
            Assert.AreEqual(70, maxValue6.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 3));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue7, heap.HeapArray.Count));
            Assert.AreEqual(150, maxValue7.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 2));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue8, heap.HeapArray.Count));
            Assert.AreEqual(220, maxValue8.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 0));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue9, heap.HeapArray.Count));
            Assert.AreEqual(300, maxValue9.Key);
            Assert.IsTrue(HasMinMaxHeapProperty(heap, 0));
        }

        /// <summary>
        /// Checks whether a node in a min level of a MinMax heap has proper properties. 
        /// </summary>
        /// <typeparam name="TKey">Type of the keys stored in the heap. </typeparam>
        /// <typeparam name="TValue">Type of the values stored in the heap. </typeparam>
        /// <param name="heap">A MinMax binary heap. </param>
        /// <param name="index">The index of a node in a heap array and in a Min level.</param>
        /// <returns>True if the node has proper properties, and false otherwise. </returns>
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

        /// <summary>
        /// Checks whether a node in a max level of a MinMax heap has proper properties. 
        /// </summary>
        /// <typeparam name="TKey">Type of the keys stored in the heap. </typeparam>
        /// <typeparam name="TValue">Type of the values stored in the heap. </typeparam>
        /// <param name="heap">A MinMax binary heap. </param>
        /// <param name="index">The index of a node in a heap array and in a Max level.</param>
        /// <returns>True if the node has proper properties, and false otherwise. </returns>
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

        public static bool HasMinMaxHeapProperty<TKey, TValue>(MinMaxBinaryHeap<TKey, TValue> heap, int expectedKeyCount) where TKey : IComparable<TKey>
        {
            for (int i = 0; i < expectedKeyCount; i++)
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
            return true;
        }
    }
}
