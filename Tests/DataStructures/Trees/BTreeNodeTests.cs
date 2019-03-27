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
using System.Linq;
using CSFundamentals.DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class BTreeNodeTests
    {

        [TestMethod]
        public void BTreeNode_Constructor_Test()
        {
            /* Testing with an odd number for MaxBranchingDegree. Aka values for 2-3 B-Tree */
            var node1 = new BTreeNode<int, string>(3);
            Assert.AreEqual(2, node1.MinBranchingDegree);
            Assert.AreEqual(3, node1.MaxBranchingDegree);
            Assert.AreEqual(1, node1.MinKeys);
            Assert.AreEqual(2, node1.MaxKeys);

            /* Testing with an even number for MaxBranchingDegree. Aka values for 3-4 B-Tree */
            var node2 = new BTreeNode<int, string>(4);
            Assert.AreEqual(2, node2.MinBranchingDegree);
            Assert.AreEqual(4, node2.MaxBranchingDegree);
            Assert.AreEqual(1, node2.MinKeys);
            Assert.AreEqual(3, node2.MaxKeys);
        }

        [TestMethod]
        public void BTreeNode_IsLeaf_Test()
        {
            var node1 = new BTreeNode<int, string>(3);
            Assert.IsTrue(node1.IsLeaf());

            var node2 = new BTreeNode<int, string>(3);
            node1.InsertChild(node2);
            Assert.IsFalse(node1.IsLeaf());
            Assert.IsTrue(node2.IsLeaf());
        }

        [TestMethod]
        public void BTreeNode_IsRoot_Test()
        {
            var node1 = new BTreeNode<int, string>(3);
            Assert.IsTrue(node1.IsRoot());

            var node2 = new BTreeNode<int, string>(3);
            node1.InsertChild(node2);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node2.IsRoot());
        }

        [TestMethod]
        public void BTreeNode_GetMinKey_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            /* Testing with 3 keys. */
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            Assert.AreEqual(10, node1.GetMinKey().Key);
            Assert.AreEqual("A", node1.GetMinKey().Value, ignoreCase: false);
        }

        [TestMethod]
        public void BTreeNode_GetMaxKey_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            /* Testing with 3 keys. */
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            Assert.AreEqual(100, node1.GetMaxKey().Key);
            Assert.AreEqual("C", node1.GetMaxKey().Value, ignoreCase: false);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_GetMaxKey_Test_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            KeyValuePair<int, string> maxKeyValue = node.GetMaxKey();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_GetMinKey_Test_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            KeyValuePair<int, string> minKeyValue = node.GetMinKey();
        }

        [TestMethod]
        public void BTreeNode_Compare_Test()
        {
            /* Testing comparison to a null other node.*/
            var node1 = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node1.CompareTo(null));

            /* Testing comparison of 2 empty nodes. */
            var node2 = new BTreeNode<int, string>(3);
            Assert.AreEqual(0, node1.CompareTo(node2));

            /* Testing comparison of a not-empty node to an empty-node */
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node1.CompareTo(node2));

            /* Testing comparison of a 2 non-empty nodes. */
            node2.InsertKeyValue(new KeyValuePair<int, string>(50, "B2"));
            Assert.AreEqual(-1, node1.CompareTo(node2));

            node2.InsertKeyValue(new KeyValuePair<int, string>(10, "A2"));
            Assert.AreEqual(0, node1.CompareTo(node2)); /* Notice that in a B-Tree node we do not expect two children to have the same min key. Thus this comparison of these two nodes should be true to prevent inserting oen of them in the tree.*/
        }

        [TestMethod]
        public void BTreeNode_InsertKey_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            Assert.AreEqual(0, node1.GetKeyIndex(10));
            Assert.AreEqual(1, node1.GetKeyIndex(50));
            Assert.AreEqual(2, node1.GetKeyIndex(100));
        }

        [TestMethod]
        public void BTreeNode_InsertKey_Duplicate_Test()
        {
            var node = new BTreeNode<int, string>(3);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyCount);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "B"));
            Assert.AreEqual(1, node.KeyCount);
        }

        [TestMethod]
        public void BTreeNode_InsertChild_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKeyValue(new KeyValuePair<int, string>(5, "D"));
            child1.InsertKeyValue(new KeyValuePair<int, string>(9, "E"));


            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKeyValue(new KeyValuePair<int, string>(55, "F"));
            child2.InsertKeyValue(new KeyValuePair<int, string>(70, "G"));

            node1.InsertChild(child2);
            node1.InsertChild(child1);

            Assert.IsTrue(ReferenceEquals(node1, child1.Parent));
            Assert.IsTrue(ReferenceEquals(node1, child2.Parent));

            Assert.AreEqual(0, node1.GetChildIndex(child1));
            Assert.AreEqual(1, node1.GetChildIndex(child2));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BTreeNode_InsertChild_Duplicate_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKeyValue(new KeyValuePair<int, string>(5, "D"));
            child1.InsertKeyValue(new KeyValuePair<int, string>(9, "E"));


            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKeyValue(new KeyValuePair<int, string>(55, "F"));
            child2.InsertKeyValue(new KeyValuePair<int, string>(70, "G"));

            node1.InsertChild(child1);
            node1.InsertChild(child1);
        }

        [TestMethod]
        public void BTreeNode_Split_Test_NodeWithNoChildren()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.IsNull(node.Split());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            Assert.IsNull(node.Split());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            Assert.IsNull(node.Split());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> newNode = node.Split();
            Assert.IsTrue(HasBTreeNodeProperties(node));
            Assert.IsTrue(HasBTreeNodeProperties(newNode));
            Assert.AreEqual(2, node.KeyCount);
            Assert.AreEqual(1, newNode.KeyCount);
        }

        [TestMethod]
        public void BTreeNode_Split_Test_NodeWithChildren()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(200, "C"));

            BTreeNode<int, string> child1 = new BTreeNode<int, string>(3);
            child1.InsertKeyValue(new KeyValuePair<int, string>(10, "D"));
            node.InsertChild(child1);

            BTreeNode<int, string> child2 = new BTreeNode<int, string>(3);
            child2.InsertKeyValue(new KeyValuePair<int, string>(30, "E"));
            node.InsertChild(child2);

            BTreeNode<int, string> child3 = new BTreeNode<int, string>(3);
            child3.InsertKeyValue(new KeyValuePair<int, string>(100, "F"));
            node.InsertChild(child3);

            BTreeNode<int, string> child4 = new BTreeNode<int, string>(3);
            child4.InsertKeyValue(new KeyValuePair<int, string>(300, "G"));
            node.InsertChild(child4);

            BTreeNode<int, string> newNode = node.Split();
            /* At this point we do not expect this node to be valid, because the key in the middle has not yet moved up, that step is part of split method in the tree itself and not in the node.*/
            // HasBTreeNodeProperties(node); 
            Assert.IsTrue(HasBTreeNodeProperties(newNode));
        }

        [TestMethod]
        public void BTreeNode_Search_Test()
        {
            // TODO
        }

        [TestMethod]
        public void BTreeNode_IsOverFlown_Test()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            Assert.IsFalse(node.IsOverFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyCount);
            Assert.IsFalse(node.IsOverFlown());

            /* Testing with duplicate keys with the same value */
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            Assert.AreEqual(1, node.KeyCount);
            Assert.IsFalse(node.IsOverFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "B"));

            Assert.AreEqual(1, node.KeyCount);
            Assert.IsFalse(node.IsOverFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "C"));
            Assert.AreEqual(2, node.KeyCount);
            Assert.IsFalse(node.IsOverFlown());

            node.InsertKeyValue(new KeyValuePair<int, string>(30, "C"));
            Assert.AreEqual(3, node.KeyCount);
            Assert.IsTrue(node.IsOverFlown());
        }

        [TestMethod]
        public void BTreeNode_IsUnderFlown_Test()
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
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_KeyValueToMoveUp_Test_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            /* Testing when  the node has no key-values. This method is expected only on a node that has at least MinKeys+1 key-values. (In this case at least 2 keys). */
            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_KeyValueToMoveUp_Test_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            /* Testing when the node has MinKeys key-values. This method is expected only on a node that has at least MinKeys+1 key-values. (In this case at least 2 keys). */
            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
        }

        [TestMethod]
        public void BTreeNode_KeyValueToMoveUp_Test_Success_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));

            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
            Assert.AreEqual(100, keyValue.Key);
            Assert.AreEqual("B", keyValue.Value, ignoreCase: false);
        }

        [TestMethod]
        public void BTreeNode_KeyValueToMoveUp_Test_Success_2()
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
        public void BTreeNode_IsFull_Test()
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
        public void BTreeNode_GetIndexAtParentChildren_Test_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            int index = node.GetIndexAtParentChildren();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_GetIndexAtParentChildren_Test_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            node.Parent = new BTreeNode<int, string>(5);
            int index = node.GetIndexAtParentChildren();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_GetIndexAtParentChildren_Test_Fail_3()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { new BTreeNode<int, string>(5, new KeyValuePair<int, string>(40, "C")) });
            int index = node.GetIndexAtParentChildren();
        }

        [TestMethod]
        public void BTreeNode_GetIndexAtParentChildren_Test_Success()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            int index = node.GetIndexAtParentChildren();
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void BTreeNode_HasLeftSibling_Test_False()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            Assert.IsFalse(node.HasLeftSibling());
        }

        [TestMethod]
        public void BTreeNode_HasLeftSibling_Test_2()
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
        public void BTreeNode_HasRightSibling_Test_False()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            Assert.IsFalse(node.HasRightSibling());
        }

        [TestMethod]
        public void BTreeNode_HasRightSibling_Test_2()
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
        [ExpectedException(typeof(ArgumentException))]
        public void BTreeNode_GetLeftSiblingIndexAtParentChildren_Test_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            int leftSiblingIndex = node.GetLeftSiblingIndexAtParentChildren();
        }

        [TestMethod]
        public void BTreeNode_GetLeftSiblingIndexAtParentChildren_Test_2()
        {
            BTreeNode<int, string> node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            BTreeNode<int, string> node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.AreEqual(1, node2.GetLeftSiblingIndexAtParentChildren());
            Assert.AreEqual(0, node3.GetLeftSiblingIndexAtParentChildren());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BTreeNode_GetRightSiblingIndexAtParentChildren_Test_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.Parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node });
            int index = node.GetRightSiblingIndexAtParentChildren();
        }

        [TestMethod]
        public void BTreeNode_GetRightSiblingIndexAtParentChildren_Test_2()
        {
            BTreeNode<int, string> node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            BTreeNode<int, string> node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.AreEqual(1, node1.GetRightSiblingIndexAtParentChildren());
            Assert.AreEqual(2, node3.GetRightSiblingIndexAtParentChildren());
        }

        [TestMethod]
        public void BTreeNode_GetLeftSibling_Test()
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
        public void BTreeNode_GetRightSibling_Test()
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
        public void BTreeNode_IsMinFull_Test()
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
        public void BTreeNode_IsMin1Full_Test()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            Assert.IsFalse(node.IsMinFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.IsFalse(node.IsMin1Full());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            Assert.IsFalse(node.IsMin1Full());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            Assert.IsTrue(node.IsMin1Full());

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "D"));
            Assert.IsFalse(node.IsMin1Full());

            node.InsertKeyValue(new KeyValuePair<int, string>(150, "E"));
            Assert.IsFalse(node.IsMin1Full());
        }

        [TestMethod]
        public void BTreeNode_IsEmpty_Test()
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
        public void BTreeNode_RemoveKey_ByKey_Test_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            /* Testing with an empty node.*/
            node.RemoveKey(10);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_RemoveKey_ByKey_Test_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            /* Testing with a non-existing key.*/
            node.RemoveKey(10);
        }

        [TestMethod]
        public void BTreeNode_RemoveKey_ByKey_Test_Success()
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
        public void BTreeNode_RemoveKey_ByIndex_Test_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            /* Testing with a non-existing key.*/
            node.RemoveKeyByIndex(2);
        }

        [TestMethod]
        public void BTreeNode_RemoveKey_ByIndex_Test_Success()
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
        public void BTreeNode_RemoveChild_ByIndex_Test_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with no children. */
            node.RemoveChildByIndex(2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void BTreeNode_RemoveChild_ByIndex_Test_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            /* Testing with a non-existing child. */
            node.RemoveChildByIndex(2);
        }

        [TestMethod]
        public void BTreeNode_RemoveChild_ByIndex_Test_Success()
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
        public void BTreeNode_RemoveChild_ByKey_Test_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with no children. */
            node.RemoveChild(new BTreeNode<int, string>(5));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTreeNode_RemoveChild_ByKey_Test_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            /* Testing with a non-existing child. */
            node.RemoveChild(new BTreeNode<int, string>(5));
        }

        [TestMethod]
        public void BTreeNode_RemoveChild_ByKey_Test_Success()
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
        public void BTreeNode_GetKeyValue_Test_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with an empty node. */
            node.GetKeyValue(2);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void BTreeNode_GetKeyValue_Test_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            /* Testing with a non-empty node, and non-existing index. */
            node.GetKeyValue(2);
        }

        [TestMethod]
        public void BTreeNode_GetKeyValue_Test_Success()
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
        public void BTreeNode_GetKey_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetKey(3);
        }

        [TestMethod]
        public void BTreeNode_GetKey_Success()
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
        public void BTreeNode_GetKeyIndex_Test()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetKeyIndex(2);
        }

        [TestMethod]
        public void BTreeNode_GetKeyIndex_Success()
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
        public void BTreeNode_GetChild_Fail()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetChild(2);
        }

        [TestMethod]
        public void BTreeNode_GetChild_Success()
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
        public void BTreeNode_GetChildIndex_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child = new BTreeNode<int, string>(5);
            node.GetChildIndex(child);

        }

        [TestMethod]
        public void BTreeNode_GetChildIndex_Success()
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

        public static bool HasBTreeNodeProperties<T1, T2>(BTreeNode<T1, T2> node) where T1 : IComparable<T1>
        {
            Assert.IsTrue(node.KeyCount != 0); /* Every valid node (root and non-root) in the tree is expected to have at least one key.*/

            Assert.IsFalse(node.IsOverFlown());

            /* Number of children of any non-leaf node should be at most MaxBranchingDegree */
            if (!node.IsLeaf())
            {
                Assert.IsTrue(node.ChildrenCount <= node.MaxBranchingDegree);

                /* Number of children should always be one bigger than the number of keys. */
                Assert.AreEqual(node.KeyCount + 1, node.ChildrenCount);
            }

            if (!node.IsLeaf())
            {
                Assert.IsTrue(node.ChildrenCount >= node.MinBranchingDegree);
            }

            Assert.IsTrue(node.KeyCount <= node.MaxKeys);

            /* Every non-root node's key count should be at least MinKeys.*/
            if (!node.IsRoot())
            {
                Assert.IsTrue(node.KeyCount >= node.MinKeys);
                Assert.IsFalse(node.IsUnderFlown());
            }

            /* All the keys in a node should be sorted in ascending order.*/
            for (int i = 0; i < node.KeyCount - 1; i++)
            {
                Assert.IsTrue(node.GetKey(i).CompareTo(node.GetKey(i + 1)) <= 0);
            }

            /* Check the key range ordering of the node against its children. */
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                BTreeNode<T1, T2> childNode = node.GetChild(i);
                KeyValuePair<T1, T2> childMinKey = childNode.GetMinKey();
                KeyValuePair<T1, T2> childMaxKey = childNode.GetMaxKey();

                if (i > 0)
                    Assert.IsTrue(childMinKey.Key.CompareTo(node.GetKey(i - 1)) > 0);
                if (i < node.KeyCount)
                    Assert.IsTrue(childMaxKey.Key.CompareTo(node.GetKey(i)) < 0);
            }

            /* Check the key range ordering of the node against its parent. */
            if (node.Parent != null)
            {
                KeyValuePair<T1, T2> minKey = node.GetMinKey();
                KeyValuePair<T1, T2> maxKey = node.GetMaxKey();
                int indexAtParentChildren = node.GetIndexAtParentChildren();

                if (indexAtParentChildren > 0)
                    Assert.IsTrue(minKey.Key.CompareTo(node.Parent.GetKey(indexAtParentChildren - 1)) > 0);
                if (indexAtParentChildren < node.Parent.KeyCount)
                    Assert.IsTrue(maxKey.Key.CompareTo(node.Parent.GetKey(indexAtParentChildren)) < 0);
            }

            return true;
        }
    }
}
