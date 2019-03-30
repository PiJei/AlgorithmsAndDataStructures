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

namespace CSFundamentalsTests.DataStructures.Trees
{
    /// <summary>
    /// Tests BTreeNode implementation by a 2-3 BTree Node.
    /// </summary>
    [TestClass]
    public class _2_3_BTreeNodeTests
    {
        [TestMethod]
        public void Constructor()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(2, node.MinBranchingDegree);
            Assert.AreEqual(3, node.MaxBranchingDegree);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);
        }

        [TestMethod]
        public void IsLeaf()
        {
            var node1 = new BTreeNode<int, string>(3);
            Assert.IsTrue(node1.IsLeaf());

            var node2 = new BTreeNode<int, string>(3);
            node1.InsertChild(node2);
            Assert.IsFalse(node1.IsLeaf());
            Assert.IsTrue(node2.IsLeaf());
        }

        [TestMethod]
        public void IsRoot()
        {
            var node1 = new BTreeNode<int, string>(3);
            Assert.IsTrue(node1.IsRoot());

            var node2 = new BTreeNode<int, string>(3);
            node1.InsertChild(node2);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node2.IsRoot());
        }

        [TestMethod]
        public void GetMinKey()
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
        public void GetMaxKey()
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
        public void Compare()
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
        public void InsertKey()
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
        public void InsertKey_Duplicate()
        {
            var node = new BTreeNode<int, string>(3);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyCount);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "B"));
            Assert.AreEqual(1, node.KeyCount);
        }

        [TestMethod]
        public void InsertChild()
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
        public void InsertChild_Duplicate()
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
        public void Split_NodeWithNoChildren()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.IsNull(node.Split());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            Assert.IsNull(node.Split());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            Assert.IsNull(node.Split());

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> newNode = node.Split();
            Assert.IsTrue(BTreeTestsUtils.HasBTreeNodeProperties(node));
            Assert.IsTrue(BTreeTestsUtils.HasBTreeNodeProperties(newNode));
            Assert.AreEqual(2, node.KeyCount);
            Assert.AreEqual(1, newNode.KeyCount);
        }

        [TestMethod]
        public void Split_NodeWithChildren()
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
            Assert.IsTrue(BTreeTestsUtils.HasBTreeNodeProperties(newNode));
        }

        [TestMethod]
        public void Search()
        {
            // TODO
        }

        [TestMethod]
        public void IsOverFlown()
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
        [ExpectedException(typeof(KeyNotFoundException))]
        public void KeyValueToMoveUp_Fail_1()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            /* Testing when  the node has no key-values. This method is expected only on a node that has at least MinKeys+1 key-values. (In this case at least 2 keys). */
            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void KeyValueToMoveUp_Fail_2()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            /* Testing when the node has MinKeys key-values. This method is expected only on a node that has at least MinKeys+1 key-values. (In this case at least 2 keys). */
            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
        }

        [TestMethod]
        public void KeyValueToMoveUp_Success_1()
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
    }
}
