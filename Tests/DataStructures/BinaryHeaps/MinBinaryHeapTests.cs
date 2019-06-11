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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.DataStructures.BinaryHeaps
{
    /// <summary>
    /// Tests methods in <see cref="MinBinaryHeap{TKey, TValue}"/> class. 
    /// </summary>
    [TestClass]
    public class MinBinaryHeapTests
    {
        private readonly KeyValuePair<int, string> _nodeA = new KeyValuePair<int, string>(150, "A");
        private readonly KeyValuePair<int, string> _nodeB = new KeyValuePair<int, string>(70, "B");
        private readonly KeyValuePair<int, string> _nodeC = new KeyValuePair<int, string>(202, "C");
        private readonly KeyValuePair<int, string> _nodeD = new KeyValuePair<int, string>(34, "D");
        private readonly KeyValuePair<int, string> _nodeE = new KeyValuePair<int, string>(42, "E");
        private readonly KeyValuePair<int, string> _nodeF = new KeyValuePair<int, string>(1, "F");
        private readonly KeyValuePair<int, string> _nodeG = new KeyValuePair<int, string>(3, "G");
        private readonly KeyValuePair<int, string> _nodeH = new KeyValuePair<int, string>(10, "H");
        private readonly KeyValuePair<int, string> _nodeI = new KeyValuePair<int, string>(21, "I");
        private List<KeyValuePair<int, string>> _keyValues = null;

        /// <summary>
        /// Initializes/Resets variables before executing each unit test in this class. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _keyValues = new List<KeyValuePair<int, string>> {
                _nodeA,
                _nodeB,
                _nodeC,
                _nodeD,
                _nodeE,
                _nodeF,
                _nodeG,
                _nodeH,
                _nodeI };
        }

        /// <summary>
        /// Tests the correctness of Build operation recursive version. 
        /// To visualize in-place Min Binary Heap building process see: <img src = "../Images/Heaps/MinBinaryHeap-Build.png"/>.
        /// </summary>
        [TestMethod]
        public void BuildHeap_Recursively()
        {
            var heap = new MinBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(_keyValues.Count, heap));
        }

        /// <summary>
        /// Tests the correctness of Build operation iterative version.
        /// To visualize in-place Min Binary Heap building process see: <img src = "../Images/Heaps/MinBinaryHeap-Build.png"/>.
        /// </summary>
        [TestMethod]
        public void BuildHeap_Iteratively()
        {
            var heap = new MinBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Iteratively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(_keyValues.Count, heap));
        }

        /// <summary>
        /// Tests the correctness of removing min node from a Min binary heap. 
        /// To visualize the steps in this test method see: <img src = "../Images/Heaps/MinBinaryHeap-TryRemoveRoot.png"/>.
        /// </summary>
        [TestMethod]
        public void TryRemoveRoot_RemoveRoot_SeveralTimes_ExpectsAscendingOrderInResults()
        {
            var keyValues = new List<KeyValuePair<int, string>> {
                new KeyValuePair<int, string>(150, "A"),
                new KeyValuePair<int, string>(70,"B"),
                new KeyValuePair<int, string>(202,"C"),
                new KeyValuePair<int, string>(34,"D"),
                new KeyValuePair<int, string>(42,"E"),
                new KeyValuePair<int, string>(1,"F"),
                new KeyValuePair<int, string>(3,"G"),
                new KeyValuePair<int, string>(10,"H"),
                new KeyValuePair<int, string>(21,"I") };

            var heap = new MinBinaryHeap<int, string>(keyValues);
            heap.BuildHeap_Iteratively(heap.HeapArray.Count);

            // The values in the array are expected to be removed in ascending order. 
            bool result1 = heap.TryRemoveRoot(out KeyValuePair<int, string> min1, heap.HeapArray.Count);
            Assert.IsTrue(result1);
            Assert.AreEqual(1, min1.Key);

            bool result2 = heap.TryRemoveRoot(out KeyValuePair<int, string> min2, heap.HeapArray.Count);
            Assert.IsTrue(result2);
            Assert.AreEqual(3, min2.Key);

            bool result3 = heap.TryRemoveRoot(out KeyValuePair<int, string> min3, heap.HeapArray.Count);
            Assert.IsTrue(result3);
            Assert.AreEqual(10, min3.Key);

            bool result4 = heap.TryRemoveRoot(out KeyValuePair<int, string> min4, heap.HeapArray.Count);
            Assert.IsTrue(result4);
            Assert.AreEqual(21, min4.Key);

            bool result5 = heap.TryRemoveRoot(out KeyValuePair<int, string> min5, heap.HeapArray.Count);
            Assert.IsTrue(result5);
            Assert.AreEqual(34, min5.Key);

            bool result6 = heap.TryRemoveRoot(out KeyValuePair<int, string> min6, heap.HeapArray.Count);
            Assert.IsTrue(result6);
            Assert.AreEqual(42, min6.Key);

            bool result7 = heap.TryRemoveRoot(out KeyValuePair<int, string> min7, heap.HeapArray.Count);
            Assert.IsTrue(result7);
            Assert.AreEqual(70, min7.Key);

            bool result8 = heap.TryRemoveRoot(out KeyValuePair<int, string> min8, heap.HeapArray.Count);
            Assert.IsTrue(result8);
            Assert.AreEqual(150, min8.Key);

            bool result9 = heap.TryRemoveRoot(out KeyValuePair<int, string> min9, heap.HeapArray.Count);
            Assert.IsTrue(result9);
            Assert.AreEqual(202, min9.Key);
        }

        /// <summary>
        /// Tests the correctness of Insert operation when inserting several keys one after the other in the Min binary heap. 
        /// To visualize the steps in this test method see: <img src = "../Images/Heaps/MinBinaryHeap-Insert.png"/>.
        /// </summary>
        [TestMethod]
        public void Insert_SeveralValues_ExpectCorrectMinBinaryHeapAfterEachInsert()
        {
            var values = new List<KeyValuePair<int, string>>();
            var heap = new MinBinaryHeap<int, string>(values);

            // Inserting these values: { 150, 70, 202, 34, 42, 1, 3, 10, 21 };

            heap.Insert(new KeyValuePair<int, string>(150, "A"), heap.HeapArray.Count);
            Assert.AreEqual(1, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(1, heap));

            heap.Insert(new KeyValuePair<int, string>(70, "B"), heap.HeapArray.Count);
            Assert.AreEqual(2, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(2, heap));

            heap.Insert(new KeyValuePair<int, string>(202, "C"), heap.HeapArray.Count);
            Assert.AreEqual(3, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(3, heap));

            heap.Insert(new KeyValuePair<int, string>(34, "D"), heap.HeapArray.Count);
            Assert.AreEqual(4, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(4, heap));

            heap.Insert(new KeyValuePair<int, string>(42, "E"), heap.HeapArray.Count);
            Assert.AreEqual(5, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(5, heap));

            heap.Insert(new KeyValuePair<int, string>(1, "F"), heap.HeapArray.Count);
            Assert.AreEqual(6, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(6, heap));

            heap.Insert(new KeyValuePair<int, string>(3, "G"), heap.HeapArray.Count);
            Assert.AreEqual(7, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(7, heap));

            heap.Insert(new KeyValuePair<int, string>(10, "H"), heap.HeapArray.Count);
            Assert.AreEqual(8, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(8, heap));

            heap.Insert(new KeyValuePair<int, string>(21, "I"), heap.HeapArray.Count);
            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMinOrderPropertyForHeap(9, heap));
        }

        /// <summary>
        /// Tests the correctness of computing node levels in a Min binary heap. 
        /// </summary>
        [TestMethod]
        public void GetNodeLevel()
        {
            var A = new KeyValuePair<int, string>(150, "A");
            var B = new KeyValuePair<int, string>(70, "B");
            var C = new KeyValuePair<int, string>(202, "C");
            var D = new KeyValuePair<int, string>(34, "D");
            var E = new KeyValuePair<int, string>(42, "E");
            var F = new KeyValuePair<int, string>(1, "F");
            var G = new KeyValuePair<int, string>(3, "G");
            var H = new KeyValuePair<int, string>(10, "H");
            var I = new KeyValuePair<int, string>(21, "I");

            var keyValues = new List<KeyValuePair<int, string>> { A, B, C, D, E, F, G, H, I };

            var heap = new MinBinaryHeap<int, string>(keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.IsTrue(HasMinOrderPropertyForHeap(9, heap));

            /* This is the expected positions of keys. */
            Assert.AreEqual(0, keyValues.IndexOf(F));
            Assert.AreEqual(1, keyValues.IndexOf(H));
            Assert.AreEqual(2, keyValues.IndexOf(G));
            Assert.AreEqual(3, keyValues.IndexOf(I));
            Assert.AreEqual(4, keyValues.IndexOf(E));
            Assert.AreEqual(5, keyValues.IndexOf(C));
            Assert.AreEqual(6, keyValues.IndexOf(A));
            Assert.AreEqual(7, keyValues.IndexOf(D));
            Assert.AreEqual(8, keyValues.IndexOf(B));

            Assert.AreEqual(2, heap.GetNodeLevel(keyValues.IndexOf(A)));
            Assert.AreEqual(3, heap.GetNodeLevel(keyValues.IndexOf(B)));
            Assert.AreEqual(2, heap.GetNodeLevel(keyValues.IndexOf(C)));
            Assert.AreEqual(3, heap.GetNodeLevel(keyValues.IndexOf(D)));
            Assert.AreEqual(2, heap.GetNodeLevel(keyValues.IndexOf(E)));
            Assert.AreEqual(0, heap.GetNodeLevel(keyValues.IndexOf(F)));
            Assert.AreEqual(1, heap.GetNodeLevel(keyValues.IndexOf(G)));
            Assert.AreEqual(1, heap.GetNodeLevel(keyValues.IndexOf(H)));
            Assert.AreEqual(2, heap.GetNodeLevel(keyValues.IndexOf(I)));
        }

        /// <summary>
        /// Checks whether the given heap is a proper Min binary heap. 
        /// Checking the MinHeap ordering (node relations) for the node at the given index, to make sure the correct relations between the node and its parent and children holds. 
        /// </summary>
        /// <param name="heap">A Min binary heap. </param>
        /// <param name="nodeIndex">The index of a heap node in a heap array. </param>
        public static bool HasMinOrderPropertyForNode<TKey, TValue>(BinaryHeapBase<TKey, TValue> heap, int nodeIndex) where TKey : IComparable<TKey>
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(nodeIndex);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(nodeIndex);
            int parentindex = heap.GetParentIndex(nodeIndex);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[leftChildIndex].Key) <= 0);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[rightChildIndex].Key) <= 0);
            }
            if (parentindex >= 0 && parentindex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[parentindex].Key) >= 0);
            }
            return true;
        }

        /// <summary>
        /// Checks whether the heap is a proper Min heap. 
        /// </summary>
        /// <typeparam name="TKey">Type of the keys stored in the heap. </typeparam>
        /// <typeparam name="TValue">Type of the values stored in the heap. </typeparam>
        /// <param name="arraySize">Size of the heap array. </param>
        /// <param name="heap">A Min binary heap. </param>
        /// <returns>True if the heap is a proper Min binary heap, and false otherwise. </returns>
        public static bool HasMinOrderPropertyForHeap<TKey, TValue>(int arraySize, MinBinaryHeap<TKey, TValue> heap) where TKey : IComparable<TKey>
        {
            for (int i = 0; i < arraySize; i++)
            {
                HasMinOrderPropertyForNode(heap, i);
            }
            return true;
        }
    }
}
