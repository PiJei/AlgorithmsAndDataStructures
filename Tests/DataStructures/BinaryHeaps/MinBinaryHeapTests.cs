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
    public class MinBinaryHeapTests
    {
        private List<KeyValuePair<int, string>> arrayHeap1RecursivelyBuilt = new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(9, "A"), new KeyValuePair<int, string>(6, "B"), new KeyValuePair<int, string>(1, "C"), new KeyValuePair<int, string>(8, "D"), new KeyValuePair<int, string>(3, "E"), new KeyValuePair<int, string>(5, "F") };
        private List<KeyValuePair<int, string>> arrayHeap1IterativelyBuilt = new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(9, "A"), new KeyValuePair<int, string>(6, "B"), new KeyValuePair<int, string>(1, "C"), new KeyValuePair<int, string>(8, "D"), new KeyValuePair<int, string>(3, "E"), new KeyValuePair<int, string>(5, "F") };
        private List<KeyValuePair<int, string>> arrayHeap2RecursivelyBuilt = new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(150, "A"), new KeyValuePair<int, string>(70, "B"), new KeyValuePair<int, string>(202, "C"), new KeyValuePair<int, string>(34, "D"), new KeyValuePair<int, string>(42, "E"), new KeyValuePair<int, string>(1, "F"), new KeyValuePair<int, string>(3, "G"), new KeyValuePair<int, string>(10, "H"), new KeyValuePair<int, string>(21, "J") };
        private List<KeyValuePair<int, string>> arrayHeap2IterativelyBuilt = new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(150, "A"), new KeyValuePair<int, string>(70, "B"), new KeyValuePair<int, string>(202, "C"), new KeyValuePair<int, string>(34, "D"), new KeyValuePair<int, string>(42, "E"), new KeyValuePair<int, string>(1, "F"), new KeyValuePair<int, string>(3, "G"), new KeyValuePair<int, string>(10, "H"), new KeyValuePair<int, string>(21, "J") };

        private MinBinaryHeap<int, string> _heap1 = null;
        private MinBinaryHeap<int, string> _heap2 = null;
        private MinBinaryHeap<int, string> _heap3 = null;
        private MinBinaryHeap<int, string> _heap4 = null;

        [TestInitialize]
        public void Init()
        {
            _heap1 = new MinBinaryHeap<int, string>(arrayHeap1IterativelyBuilt);
            _heap1.BuildHeap_Iteratively(_heap1.HeapArray.Count);

            _heap2 = new MinBinaryHeap<int, string>(arrayHeap2IterativelyBuilt);
            _heap2.BuildHeap_Iteratively(_heap2.HeapArray.Count);

            _heap3 = new MinBinaryHeap<int, string>(arrayHeap1RecursivelyBuilt);
            _heap3.BuildHeap_Recursively(_heap3.HeapArray.Count);

            _heap4 = new MinBinaryHeap<int, string>(arrayHeap2RecursivelyBuilt);
            _heap4.BuildHeap_Recursively(_heap4.HeapArray.Count);
        }

        [TestMethod]
        public void BuildHeapRecursive_1()
        {
            Assert.AreEqual(6, arrayHeap1RecursivelyBuilt.Count);

            for (int i = 0; i < arrayHeap1RecursivelyBuilt.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(_heap3, i));
            }
        }

        [TestMethod]
        public void BuildHeapRecursive_2()
        {
            Assert.AreEqual(9, arrayHeap2RecursivelyBuilt.Count);

            for (int i = 0; i < arrayHeap2RecursivelyBuilt.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(_heap4, i));
            }
        }

        [TestMethod]
        public void BuildHeapIterative_1()
        {
            Assert.AreEqual(6, arrayHeap1IterativelyBuilt.Count);

            for (int i = 0; i < arrayHeap1IterativelyBuilt.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(_heap1, i));
            }
        }

        [TestMethod]
        public void BuildHeapIterative_2()
        {
            Assert.AreEqual(9, arrayHeap2IterativelyBuilt.Count);

            for (int i = 0; i < arrayHeap2IterativelyBuilt.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(_heap2, i));
            }
        }

        //Expect the two versions, recursive and iterative, to construct the same heaps. 
        [TestMethod]
        public void CompareEqualityOfRecursiveAndIterativeMinHeapConstruction()
        {
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
        public void TryRemoveMin_RemoveRootEqualToArrayLengthTimes_ExpectsAscendingOrderInResults()
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

        [TestMethod]
        public void Insert_SeveralValues_ExpectCorrectMinBinaryHeapAfterEachInsert()
        {
            var values = new List<KeyValuePair<int, string>>();
            var heap = new MinBinaryHeap<int, string>(values);

            // Inserting these values: { 150, 70, 202, 34, 42, 1, 3, 10, 21 };

            heap.Insert(new KeyValuePair<int, string>(150, "A"), heap.HeapArray.Count);
            Assert.AreEqual(1, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(70, "B"), heap.HeapArray.Count);
            Assert.AreEqual(2, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(202, "C"), heap.HeapArray.Count);
            Assert.AreEqual(3, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(34, "D"), heap.HeapArray.Count);
            Assert.AreEqual(4, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(42, "E"), heap.HeapArray.Count);
            Assert.AreEqual(5, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(1, "F"), heap.HeapArray.Count);
            Assert.AreEqual(6, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(3, "G"), heap.HeapArray.Count);
            Assert.AreEqual(7, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(10, "H"), heap.HeapArray.Count);
            Assert.AreEqual(8, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }

            heap.Insert(new KeyValuePair<int, string>(21, "I"), heap.HeapArray.Count);
            Assert.AreEqual(9, heap.HeapArray.Count);
            for (int i = 0; i < heap.HeapArray.Count; i++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, i));
            }
        }

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

            for (int index = 0; index < keyValues.Count; index++)
            {
                Assert.IsTrue(HasMinOrderProperty(heap, index));
            }

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
        /// Checking the MinHeap ordering (node relations) for the node at the given index, to make sure the correct relations between the node and its parent and children holds. 
        /// </summary>
        /// <param name="heap"></param>
        /// <param name="nodeIndex"></param>
        public static bool HasMinOrderProperty<TKey, TValue>(BinaryHeapBase<TKey, TValue> heap, int nodeIndex) where TKey : IComparable<TKey>
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
    }
}
