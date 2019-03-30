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
using CSFundamentals.DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO: Completely test all methods for each number of b-tree instance. 

namespace CSFundamentalsTests.DataStructures.Trees
{
    /// <summary>
    /// Tests BTreeNode implementation by a 3-5 BTree Node.
    /// </summary>
    [TestClass]
    public class _3_5_BTreeNodeTests
    {
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetMaxKey_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            KeyValuePair<int, string> maxKeyValue = node.GetMaxKey();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetMinKey_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            KeyValuePair<int, string> minKeyValue = node.GetMinKey();
        }

        [TestMethod]
        public void IsUnderFlown()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);
            Assert.IsTrue(node.IsUnderFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyCount);
            Assert.IsTrue(node.IsUnderFlown());

            /* Testing with duplicate keys with the same value */
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            Assert.AreEqual(1, node.KeyCount);
            Assert.IsTrue(node.IsUnderFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "B"));

            Assert.AreEqual(1, node.KeyCount);
            Assert.IsTrue(node.IsUnderFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "C"));
            Assert.AreEqual(2, node.KeyCount);
            Assert.IsFalse(node.IsUnderFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(30, "C"));
            Assert.AreEqual(3, node.KeyCount);
            Assert.IsFalse(node.IsUnderFlown());
        }

        [TestMethod]
        public void KeyValueToMoveUp_Success_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(60, "D"));

            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
            Assert.AreEqual(60, keyValue.Key);
            Assert.AreEqual("D", keyValue.Value, ignoreCase: false);
        }

        [TestMethod]
        public void IsFull()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            Assert.IsFalse(node.IsFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "A"));
            Assert.IsFalse(node.IsFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            Assert.IsFalse(node.IsFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "C"));
            Assert.IsFalse(node.IsFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(200, "D"));
            Assert.IsTrue(node.IsFull());

            /* Inserting one ore element so that the node is overFlown, which is not the same as full. */
            node.InsertKeyValue(new KeyValuePair<int, string>(40, "E"));
            Assert.IsFalse(node.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIndexAtParentChildren_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            int index = node.GetIndexAtParentChildren();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetIndexAtParentChildren_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            node.Parent = new BTreeNode<int, string>(5);
            int index = node.GetIndexAtParentChildren();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetIndexAtParentChildren_Fail_3()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { new BTreeNode<int, string>(5, new KeyValuePair<int, string>(40, "C")) });
            int index = node.GetIndexAtParentChildren();
        }

        [TestMethod]
        public void GetIndexAtParentChildren_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            int index = node.GetIndexAtParentChildren();
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void HasLeftSibling_False()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            Assert.IsFalse(node.HasLeftSibling());
        }

        [TestMethod]
        public void HasLeftSibling_2()
        {
            BTreeNode<int, string> node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            BTreeNode<int, string> node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.IsFalse(node1.HasLeftSibling());
            Assert.IsTrue(node2.HasLeftSibling());
            Assert.IsTrue(node3.HasLeftSibling());
        }

        [TestMethod]
        public void HasRightSibling_False()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            Assert.IsFalse(node.HasRightSibling());
        }

        [TestMethod]
        public void HasRightSibling_2()
        {
            BTreeNode<int, string> node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            BTreeNode<int, string> node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.IsTrue(node1.HasRightSibling());
            Assert.IsFalse(node2.HasRightSibling());
            Assert.IsTrue(node3.HasRightSibling());
        }

        [TestMethod]
        public void GetLeftSibling()
        {
            BTreeNode<int, string> node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            BTreeNode<int, string> node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.AreEqual(node3, node2.GetLeftSibling());
            Assert.AreEqual(node1, node3.GetLeftSibling());
        }

        [TestMethod]
        public void GetRightSibling()
        {
            BTreeNode<int, string> node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            BTreeNode<int, string> node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.AreEqual(node3, node1.GetRightSibling());
            Assert.AreEqual(node2, node3.GetRightSibling());
        }

        [TestMethod]
        public void IsMinFull()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            Assert.IsFalse(node.IsMinFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.IsFalse(node.IsMinFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            Assert.IsTrue(node.IsMinFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            Assert.IsFalse(node.IsMinFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "D"));
            Assert.IsFalse(node.IsMinFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(150, "E"));
            Assert.IsFalse(node.IsMinFull());
        }

        [TestMethod]
        public void IsMinOneFull()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            Assert.IsFalse(node.IsMinFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.IsFalse(node.IsMinOneFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            Assert.IsFalse(node.IsMinOneFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            Assert.IsTrue(node.IsMinOneFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "D"));
            Assert.IsFalse(node.IsMinOneFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(150, "E"));
            Assert.IsFalse(node.IsMinOneFull());
        }

        [TestMethod]
        public void IsEmpty()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            Assert.IsTrue(node.IsEmpty());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.IsFalse(node.IsEmpty());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            Assert.IsFalse(node.IsEmpty());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            Assert.IsFalse(node.IsEmpty());

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "D"));
            Assert.IsFalse(node.IsEmpty());

            node.InsertKeyValue(new KeyValuePair<int, string>(150, "E"));
            Assert.IsFalse(node.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveKey_ByKey_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            /* Testing with an empty node.*/
            node.RemoveKey(10);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveKey_ByKey_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            /* Testing with a non-existing key.*/
            node.RemoveKey(10);
        }

        [TestMethod]
        public void RemoveKey_ByKey_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            node.RemoveKey(100);
            Assert.AreEqual(0, node.KeyCount);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            node.RemoveKey(10);
            Assert.AreEqual(2, node.KeyCount);

            node.RemoveKey(100);
            Assert.AreEqual(1, node.KeyCount);

            node.RemoveKey(50);
            Assert.AreEqual(0, node.KeyCount);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveKey_ByIndex_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            /* Testing with a non-existing key.*/
            node.RemoveKeyByIndex(2);
        }

        [TestMethod]
        public void RemoveKey_ByIndex_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            node.RemoveKeyByIndex(0);
            Assert.AreEqual(0, node.KeyCount);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            node.RemoveKeyByIndex(1);
            Assert.AreEqual(2, node.KeyCount);

            node.RemoveKeyByIndex(1);
            Assert.AreEqual(1, node.KeyCount);

            node.RemoveKeyByIndex(0);
            Assert.AreEqual(0, node.KeyCount);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveChild_ByIndex_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with no children. */
            node.RemoveChildByIndex(2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveChild_ByIndex_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            /* Testing with a non-existing child. */
            node.RemoveChildByIndex(2);
        }

        [TestMethod]
        public void RemoveChild_ByIndex_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "B")));
            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "C")));

            Assert.AreEqual(3, node.ChildrenCount);

            node.RemoveChildByIndex(2);
            Assert.AreEqual(2, node.ChildrenCount);

            node.RemoveChildByIndex(0);
            Assert.AreEqual(1, node.ChildrenCount);

            node.RemoveChildByIndex(0);
            Assert.AreEqual(0, node.ChildrenCount);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveChild_ByKey_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with no children. */
            node.RemoveChild(new BTreeNode<int, string>(5));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveChild_ByKey_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            /* Testing with a non-existing child. */
            node.RemoveChild(new BTreeNode<int, string>(5));
        }

        [TestMethod]
        public void RemoveChild_ByKey_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            node.InsertChild(child1);

            var child2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "B"));
            node.InsertChild(child2);

            var child3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "C"));
            node.InsertChild(child3);

            Assert.AreEqual(3, node.ChildrenCount);

            node.RemoveChild(child3);
            Assert.AreEqual(2, node.ChildrenCount);

            node.RemoveChild(child2);
            Assert.AreEqual(1, node.ChildrenCount);

            node.RemoveChild(child1);
            Assert.AreEqual(0, node.ChildrenCount);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetKeyValue_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with an empty node. */
            node.GetKeyValue(2);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetKeyValue_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            /* Testing with a non-empty node, and non-existing index. */
            node.GetKeyValue(2);
        }

        [TestMethod]
        public void GetKeyValue_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            Assert.AreEqual(3, node.KeyCount);

            var keyVal1 = node.GetKeyValue(2);
            Assert.AreEqual(100, keyVal1.Key);
            Assert.AreEqual("C", keyVal1.Value, ignoreCase: false);

            var keyVal2 = node.GetKeyValue(1);
            Assert.AreEqual(50, keyVal2.Key);
            Assert.AreEqual("B", keyVal2.Value, ignoreCase: false);

            var keyVal3 = node.GetKeyValue(0);
            Assert.AreEqual(10, keyVal3.Key);
            Assert.AreEqual("A", keyVal3.Value, ignoreCase: false);

            Assert.AreEqual(3, node.KeyCount);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetKey_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetKey(3);
        }

        [TestMethod]
        public void GetKey_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            Assert.AreEqual(3, node.KeyCount);

            var key1 = node.GetKey(2);
            Assert.AreEqual(100, key1);

            var key2 = node.GetKey(1);
            Assert.AreEqual(50, key2);

            var key3 = node.GetKey(0);
            Assert.AreEqual(10, key3);

            Assert.AreEqual(3, node.KeyCount);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetKeyIndex()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetKeyIndex(2);
        }

        [TestMethod]
        public void GetKeyIndex_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            Assert.AreEqual(3, node.KeyCount);

            var index1 = node.GetKeyIndex(50);
            Assert.AreEqual(1, index1);

            var index2 = node.GetKeyIndex(100);
            Assert.AreEqual(2, index2);

            var index3 = node.GetKeyIndex(10);
            Assert.AreEqual(0, index3);

            Assert.AreEqual(3, node.KeyCount);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetChild_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetChild(2);
        }

        [TestMethod]
        public void GetChild_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var child2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(60, "B"));
            var child3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(150, "C"));
            node.InsertChild(child1);
            node.InsertChild(child2);
            node.InsertChild(child3);

            var c1 = node.GetChild(0);
            Assert.AreEqual(child1, c1);
            var c2 = node.GetChild(1);
            Assert.AreEqual(child2, c2);
            var c3 = node.GetChild(2);
            Assert.AreEqual(child3, c3);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetChildIndex_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child = new BTreeNode<int, string>(5);
            node.GetChildIndex(child);
        }

        [TestMethod]
        public void GetChildIndex_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var child2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(60, "B"));
            var child3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(150, "C"));
            node.InsertChild(child1);
            node.InsertChild(child2);
            node.InsertChild(child3);

            Assert.AreEqual(0, node.GetChildIndex(child1));
            Assert.AreEqual(1, node.GetChildIndex(child2));
            Assert.AreEqual(2, node.GetChildIndex(child3));
        }
    }
}
