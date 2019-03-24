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
            /* Testing with an empty list of keys. */
            var node1 = new BTreeNode<int, string>(3);
            Assert.IsFalse(node1.GetMinKey(out _));

            /* Testing with 3 keys. */
            node1.InsertKey(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKey(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKey(new KeyValuePair<int, string>(50, "B"));

            Assert.IsTrue(node1.GetMinKey(out int minKey));
            Assert.AreEqual(10, minKey);
        }

        [TestMethod]
        public void BTreeNode_GetMaxKey_Test()
        {
            /* Testing with an empty list of keys. */
            var node1 = new BTreeNode<int, string>(3);
            Assert.IsFalse(node1.GetMaxKey(out _));

            /* Testing with 3 keys. */
            node1.InsertKey(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKey(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKey(new KeyValuePair<int, string>(50, "B"));

            Assert.IsTrue(node1.GetMaxKey(out int maxKey));
            Assert.AreEqual(100, maxKey);
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
            node1.InsertKey(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node1.CompareTo(node2));

            /* Testing comparison of a 2 non-empty nodes. */
            node2.InsertKey(new KeyValuePair<int, string>(50, "B2"));
            Assert.AreEqual(-1, node1.CompareTo(node2));

            node2.InsertKey(new KeyValuePair<int, string>(10, "A2"));
            Assert.AreEqual(0, node1.CompareTo(node2)); /* Notice that in a B-Tree node we do not expect two children to have the same min key. Thus this comparison of these two nodes should be true to prevent inserting oen of them in the tree.*/
        }

        [TestMethod]
        public void BTreeNode_InsertKey_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKey(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKey(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKey(new KeyValuePair<int, string>(10, "A"));

            Assert.AreEqual(0, node1.KeyValues.IndexOfKey(10));
            Assert.AreEqual(1, node1.KeyValues.IndexOfKey(50));
            Assert.AreEqual(2, node1.KeyValues.IndexOfKey(100));
        }

        [TestMethod]
        public void BTreeNode_InsertKey_Duplicate_Test()
        {
            var node = new BTreeNode<int, string>(3);

            node.InsertKey(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyValues.Count);
            node.InsertKey(new KeyValuePair<int, string>(10, "B"));
            Assert.AreEqual(1, node.KeyValues.Count);
        }

        [TestMethod]
        public void BTreeNode_InsertChild_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKey(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKey(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKey(new KeyValuePair<int, string>(100, "C"));

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKey(new KeyValuePair<int, string>(5, "D"));
            child1.InsertKey(new KeyValuePair<int, string>(9, "E"));


            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKey(new KeyValuePair<int, string>(55, "F"));
            child2.InsertKey(new KeyValuePair<int, string>(70, "G"));

            node1.InsertChild(child2);
            node1.InsertChild(child1);

            Assert.IsTrue(ReferenceEquals(node1, child1.Parent));
            Assert.IsTrue(ReferenceEquals(node1, child2.Parent));

            Assert.AreEqual(0, node1.Children.IndexOfKey(child1));
            Assert.AreEqual(1, node1.Children.IndexOfKey(child2));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BTreeNode_InsertChild_Duplicate_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKey(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKey(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKey(new KeyValuePair<int, string>(100, "C"));

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKey(new KeyValuePair<int, string>(5, "D"));
            child1.InsertKey(new KeyValuePair<int, string>(9, "E"));


            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKey(new KeyValuePair<int, string>(55, "F"));
            child2.InsertKey(new KeyValuePair<int, string>(70, "G"));

            node1.InsertChild(child1);
            node1.InsertChild(child1);
        }

        [TestMethod]
        public void BTreeNode_Split_Test_NodeWithNoChildren()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);
            Assert.IsNull(node.Split());

            node.InsertKey(new KeyValuePair<int, string>(100, "C"));
            Assert.IsNull(node.Split());

            node.InsertKey(new KeyValuePair<int, string>(50, "B"));
            Assert.IsNull(node.Split());

            node.InsertKey(new KeyValuePair<int, string>(10, "A"));
            BTreeNode<int, string> newNode = node.Split();
            Assert.IsTrue(HasBTreeNodeProperties(node));
            Assert.IsTrue(HasBTreeNodeProperties(newNode));
            Assert.IsTrue(node.KeyValues.Count == 2);
            Assert.IsTrue(newNode.KeyValues.Count == 1);
        }

        [TestMethod]
        public void BTreeNode_Split_Test_NodeWithChildren()
        {
            BTreeNode<int, string> node = new BTreeNode<int, string>(3);

            node.InsertKey(new KeyValuePair<int, string>(20, "A"));
            node.InsertKey(new KeyValuePair<int, string>(50, "B"));
            node.InsertKey(new KeyValuePair<int, string>(200, "C"));

            BTreeNode<int, string> child1 = new BTreeNode<int, string>(3);
            child1.InsertKey(new KeyValuePair<int, string>(10, "D"));
            node.InsertChild(child1);

            BTreeNode<int, string> child2 = new BTreeNode<int, string>(3);
            child2.InsertKey(new KeyValuePair<int, string>(30, "E"));
            node.InsertChild(child2);

            BTreeNode<int, string> child3 = new BTreeNode<int, string>(3);
            child3.InsertKey(new KeyValuePair<int, string>(100, "F"));
            node.InsertChild(child3);

            BTreeNode<int, string> child4 = new BTreeNode<int, string>(3);
            child4.InsertKey(new KeyValuePair<int, string>(300, "G"));
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
            Assert.IsFalse(node.IsOverFlown());

            node.InsertKey(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyValues.Count);
            Assert.IsFalse(node.IsOverFlown());

            /* Testing with duplicate keys with the same value */
            node.InsertKey(new KeyValuePair<int, string>(10, "A"));

            Assert.AreEqual(1, node.KeyValues.Count);
            Assert.IsFalse(node.IsOverFlown());

            node.InsertKey(new KeyValuePair<int, string>(10, "B"));

            Assert.AreEqual(1, node.KeyValues.Count);
            Assert.IsFalse(node.IsOverFlown());

            node.InsertKey(new KeyValuePair<int, string>(20, "C"));
            Assert.AreEqual(2, node.KeyValues.Count);
            Assert.IsFalse(node.IsOverFlown());

            node.InsertKey(new KeyValuePair<int, string>(30, "C"));
            Assert.AreEqual(3, node.KeyValues.Count);
            Assert.IsTrue(node.IsOverFlown());
        }

        public static bool HasBTreeNodeProperties<T1, T2>(BTreeNode<T1, T2> node) where T1 : IComparable<T1>
        {
            /* Number of children of any non-leaf node should be at most MaxBranchingDegree */
            if (!node.IsLeaf())
            {
                Assert.IsTrue(node.Children.Count <= node.MaxBranchingDegree);

                /* Number of children should always be one bigger than the number of keys. */
                Assert.AreEqual(node.KeyValues.Count + 1, node.Children.Count);
            }

            if (!node.IsLeaf())
            {
                Assert.IsTrue(node.Children.Count >= node.MinBranchingDegree);
            }

            Assert.IsTrue(node.KeyValues.Count <= node.MaxKeys);

            /* Every non-root node's key count should be at least MinKeys.*/
            if (!node.IsRoot())
            {
                Assert.IsTrue(node.KeyValues.Count >= node.MinKeys);
            }

            /* All the keys in a node should be sorted in ascending order.*/
            for (int i = 0; i < node.KeyValues.Count - 1; i++)
            {
                Assert.IsTrue(node.KeyValues.Keys[i].CompareTo(node.KeyValues.Keys[i + 1]) <= 0);
            }

            /* Check the key range ordering of the node against its children. */
            for (int i = 0; i < node.Children.Count; i++)
            {
                BTreeNode<T1, T2> childNode = node.Children.ElementAt(i).Key;
                bool childHasMinKey = childNode.GetMinKey(out T1 childMinKey);
                bool childHasMaxKey = childNode.GetMaxKey(out T1 childMaxKey);
                Assert.IsTrue(childHasMinKey);
                Assert.IsTrue(childHasMaxKey);
                if (i > 0)
                    Assert.IsTrue(childMinKey.CompareTo(node.KeyValues.Keys[i - 1]) > 0);
                if (i < node.KeyValues.Count)
                    Assert.IsTrue(childMaxKey.CompareTo(node.KeyValues.Keys[i]) < 0);
            }

            /* Check the key range ordering of the node against its parent. */
            if (node.Parent != null)
            {
                bool hasMinKey = node.GetMinKey(out T1 minKey);
                bool hasMaxKey = node.GetMaxKey(out T1 maxKey);
                Assert.IsTrue(hasMinKey);
                Assert.IsTrue(hasMaxKey);
                int indexAtParentChildren = node.Parent.Children.IndexOfKey(node);

                if (indexAtParentChildren > 0)
                    Assert.IsTrue(minKey.CompareTo(node.Parent.KeyValues.Keys[indexAtParentChildren - 1]) > 0);
                if (indexAtParentChildren < node.Parent.KeyValues.Count)
                    Assert.IsTrue(maxKey.CompareTo(node.Parent.KeyValues.Keys[indexAtParentChildren]) < 0);
            }

            return true;
        }
    }
}
