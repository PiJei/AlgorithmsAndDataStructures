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
            node1.InsertKey(100, "C");
            node1.InsertKey(10, "A");
            node1.InsertKey(50, "B");

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
            node1.InsertKey(100, "C");
            node1.InsertKey(10, "A");
            node1.InsertKey(50, "B");

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
            node1.InsertKey(10, "A");
            Assert.AreEqual(1, node1.CompareTo(node2));

            /* Testing comparison of a 2 non-empty nodes. */
            node2.InsertKey(50, "B2");
            Assert.AreEqual(-1, node1.CompareTo(node2));

            node2.InsertKey(10, "A2");
            Assert.AreEqual(0, node1.CompareTo(node2)); /* Notice that in a B-Tree node we do not expect two children to have the same min key. Thus this comparison of these two nodes should be true to prevent inserting oen of them in the tree.*/
        }

        [TestMethod]
        public void BTreeNode_InsertKey_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKey(50, "B");
            node1.InsertKey(100, "C");
            node1.InsertKey(10, "A");

            Assert.AreEqual(0, node1.KeyValues.IndexOfKey(10));
            Assert.AreEqual(1, node1.KeyValues.IndexOfKey(50));
            Assert.AreEqual(2, node1.KeyValues.IndexOfKey(100));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BTreeNode_InsertKey_Duplicate_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKey(10, "A");
            node1.InsertKey(10, "B");
        }

        [TestMethod]
        public void BTreeNode_InsertChild_Test()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKey(10, "A");
            node1.InsertKey(50, "B");
            node1.InsertKey(100, "C");

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKey(5, "D");
            child1.InsertKey(9, "E");


            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKey(55, "F");
            child2.InsertKey(70, "G");

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

            node1.InsertKey(10, "A");
            node1.InsertKey(50, "B");
            node1.InsertKey(100, "C");

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKey(5, "D");
            child1.InsertKey(9, "E");


            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKey(55, "F");
            child2.InsertKey(70, "G");

            node1.InsertChild(child1);
            node1.InsertChild(child1);
        }

        [TestMethod]
        public void BTreeNode_Search_Test()
        {
            // TODO
        }

        public static bool HasBTreeNodeProperties<T1, T2>(BTreeNode<T1, T2> node) where T1 : IComparable<T1>
        {
            /* Number of children should always be one bigger than the number of keys. */
            Assert.AreEqual(node.KeyValues.Count + 1, node.Children.Count);

            /* Number of children of any non-leaf node should be at most MaxBranchingDegree */
            if (!node.IsLeaf())
            {
                Assert.IsTrue(node.Children.Count <= node.MaxBranchingDegree);
            }
            Assert.IsTrue(node.KeyValues.Count <= node.MaxKeys);

            /* Every non-root node's key count should be at least MinKeys.*/
            if (!node.IsRoot())
            {
                Assert.IsTrue(node.KeyValues.Count >= node.MinKeys);
            }

            /* All the keys in a node should be in ascending order.*/
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
                Assert.IsTrue(maxKey.CompareTo(node.Parent.KeyValues.Keys[indexAtParentChildren]) < 0);
            }

            return true;
        }
    }
}
