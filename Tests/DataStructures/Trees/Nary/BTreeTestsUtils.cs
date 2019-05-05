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
using CSFundamentals.DataStructures.Trees.Nary;
using CSFundamentals.DataStructures.Trees.Nary.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO: Compute levels and after each insert confirm it
namespace CSFundamentalsTests.DataStructures.Trees.Nary
{
    /// <summary>
    /// Provides a collection of helper methods used by B-Tree tests. 
    /// </summary>
    public static class BTreeTestsUtils
    {
        /// <summary>
        /// TODO: How to make this to use the DFS I have in the algorithms? 
        /// </summary>
        public static void DFS<TNode, TKey, TValue>(TNode node, List<TNode> nodes) where TNode : IBTreeNode<TNode, TKey, TValue>, IComparable<TNode> where TKey : IComparable<TKey>
        {
            if (node != null)
            {
                nodes.Add(node);
                for (int i = 0; i < node.ChildrenCount; i++)
                {
                    DFS<TNode, TKey, TValue>(node.GetChild(i), nodes);
                }
            }
        }

        /// <summary>
        /// Checks whether the tree has B-Tree properties. 
        /// </summary>
        /// <typeparam name="TNode">Type of the tree nodes stored in the tree. </typeparam>
        /// <typeparam name="TKey">Type of the keys stored in the tree. </typeparam>
        /// <typeparam name="TValue">Type of the values stored in the tree. </typeparam>
        /// <param name="tree">A B-Tree</param>
        /// <param name="expectedTotalKeyCount">The expected number of keys (duplicate and distinct) in the tree. </param>
        /// <param name="expectedDistinctKeyCount">The expected number of distinct keys in the tree. </param>
        /// <param name="expectedNodeCount">The expected number of tree nodes. </param>
        /// <param name="HasNodeProperties">The method used for checking properties. </param>
        /// <returns>True if the tree has the expected properties. </returns>
        public static bool HasBTreeProperties<TNode, TKey, TValue>(BTreeBase<TNode, TKey, TValue> tree, int expectedTotalKeyCount, int expectedDistinctKeyCount, int expectedNodeCount, Func<TNode, bool> HasNodeProperties) where TNode : IBTreeNode<TNode, TKey, TValue>, IComparable<TNode> where TKey : IComparable<TKey>
        {
            var nodes = new List<TNode>();
            DFS<TNode, TKey, TValue>(tree.Root, nodes);
            Assert.AreEqual(expectedNodeCount, nodes.Count);

            int keyCount = 0;

            /* Checking whether all the nodes are proper BTree nodes. */
            foreach (TNode node in nodes)
            {
                Assert.IsTrue(HasNodeProperties(node));
                keyCount += node.KeyCount;
            }

            /* Check that key count matches the expected key count. */
            Assert.AreEqual(expectedTotalKeyCount, keyCount);

            /* Get the sorted key list and make sure it is sorted. */

            if (tree.Root != null)
            {
                List<KeyValuePair<TKey, TValue>> sortedKeys = tree.GetSortedKeyValues(tree.Root);

                Assert.AreEqual(expectedDistinctKeyCount, sortedKeys.Count);
                for (int i = 0; i < sortedKeys.Count - 1; i++)
                {
                    Assert.IsTrue(sortedKeys[i].Key.CompareTo(sortedKeys[i + 1].Key) < 0);
                }
            }

            /* TODO Check all the leave nodes are at the same level, or one level apart? */

            return true;
        }
        /// <summary>
        /// Checks whether the node has BTree node properties. 
        /// </summary>
        /// <typeparam name="TNode">Type of tree node. </typeparam>
        /// <typeparam name="TKey">Type of the key stored in the node. </typeparam>
        /// <typeparam name="TValue">Type of the value stored in the node. </typeparam>
        /// <param name="node">A B-Tree node. </param>
        /// <returns>True if the node has expected properties, and false otherwise. </returns>
        public static bool HasBTreeNodeProperties<TNode, TKey, TValue>(TNode node) where TNode : IBTreeNode<TNode, TKey, TValue>, IComparable<TNode> where TKey : IComparable<TKey>
        {
            /* Any valid node (root and non-root) in the tree is expected to have at least one key.*/
            Assert.IsFalse(node.IsEmpty());

            /* Any node should have at most MaxKeys. */
            Assert.IsFalse(node.IsOverFlown());

            /* Any non-root node should have at least MinKeys.*/
            if (!node.IsRoot())
            {
                Assert.IsFalse(node.IsUnderFlown());
            }

            if (!node.IsLeaf())
            {
                /* Any non-leaf node should have most MaxBranchingDegree and at least MinBranching children. */
                Assert.IsTrue(node.ChildrenCount <= node.MaxBranchingDegree && node.MinBranchingDegree <= node.ChildrenCount);

                /* Any non-leaf node's children count should be exactly one more than its key count. */
                Assert.AreEqual(node.KeyCount + 1, node.ChildrenCount);
            }

            /* All the keys in a node should be sorted in ascending order.*/
            for (int i = 0; i < node.KeyCount - 1; i++)
            {
                Assert.IsTrue(node.GetKey(i).CompareTo(node.GetKey(i + 1)) <= 0);
            }

            /* Check the key range ordering of the node against its children. */
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                TNode childNode = node.GetChild(i);
                KeyValuePair<TKey, TValue> childMinKey = childNode.GetMinKey();
                KeyValuePair<TKey, TValue> childMaxKey = childNode.GetMaxKey();

                if (i > 0)
                {
                    Assert.IsTrue(childMinKey.Key.CompareTo(node.GetKey(i - 1)) > 0);
                }

                if (i < node.KeyCount)
                {
                    Assert.IsTrue(childMaxKey.Key.CompareTo(node.GetKey(i)) < 0);
                }
            }

            /* Check the key range ordering of the node against its parent. */
            var parent = node.GetParent();
            if (parent != null)
            {
                KeyValuePair<TKey, TValue> minKey = node.GetMinKey();
                KeyValuePair<TKey, TValue> maxKey = node.GetMaxKey();
                int indexAtParentChildren = node.GetIndexAtParentChildren();

                if (indexAtParentChildren > 0)
                {
                    Assert.IsTrue(minKey.Key.CompareTo(parent.GetKey(indexAtParentChildren - 1)) > 0);
                }

                if (indexAtParentChildren < parent.KeyCount)
                {
                    Assert.IsTrue(maxKey.Key.CompareTo(parent.GetKey(indexAtParentChildren)) < 0);
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether the node has proper B+ Tree node properties. 
        /// </summary>
        /// <typeparam name="TKey">Type of the key stored in the node. </typeparam>
        /// <typeparam name="TValue">Type of the value stored in the node. </typeparam>
        /// <param name="node">A B+ Tree node. </param>
        /// <returns>True if the node has expected properties, and false otherwise. </returns>
        public static bool HasBPlusTreeNodeProperties<TKey, TValue>(BPlusTreeNode<TKey, TValue> node) where TKey : IComparable<TKey>
        {
            /* Any valid node (root and non-root) in the tree is expected to have at least one key.*/
            Assert.IsFalse(node.IsEmpty());

            /* Any node should have at most MaxKeys. */
            Assert.IsFalse(node.IsOverFlown());

            /* Any non-root node should have at least MinKeys.*/
            if (!node.IsRoot())
            {
                Assert.IsFalse(node.IsUnderFlown());
            }

            if (!node.IsLeaf())
            {
                if (!node.IsRoot() || (node.IsRoot() && node.HasGrandChild()))
                {
                    /* Any non-leaf node should have most MaxBranchingDegree and at least MinBranching children. */
                    Assert.IsTrue(node.ChildrenCount <= node.MaxBranchingDegree && node.MinBranchingDegree <= node.ChildrenCount);

                    /* Any non-leaf node's children count should be exactly one more than its key count. */
                    Assert.AreEqual(node.KeyCount + 1, node.ChildrenCount);
                }
            }

            /* All the keys in a node should be sorted in ascending order.*/
            for (int i = 0; i < node.KeyCount - 1; i++)
            {
                Assert.IsTrue(node.GetKey(i).CompareTo(node.GetKey(i + 1)) <= 0);
            }

            /* Check the key range ordering of the node against its children. */
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                BPlusTreeNode<TKey, TValue> childNode = node.GetChild(i);
                KeyValuePair<TKey, TValue> childMinKey = childNode.GetMinKey();
                KeyValuePair<TKey, TValue> childMaxKey = childNode.GetMaxKey();

                if (i > 0)
                {
                    Assert.IsTrue(childMinKey.Key.CompareTo(node.GetKey(i - 1)) >= 0);
                }

                if (i < node.KeyCount)
                {
                    Assert.IsTrue(childMaxKey.Key.CompareTo(node.GetKey(i)) <= 0);
                }
            }

            /* Check the key range ordering of the node against its parent. */
            var parent = node.GetParent();
            if (parent != null)
            {
                KeyValuePair<TKey, TValue> minKey = node.GetMinKey();
                KeyValuePair<TKey, TValue> maxKey = node.GetMaxKey();
                int indexAtParentChildren = node.GetIndexAtParentChildren();

                if (indexAtParentChildren > 0)
                {
                    Assert.IsTrue(minKey.Key.CompareTo(parent.GetKey(indexAtParentChildren - 1)) >= 0);
                }

                if (indexAtParentChildren < parent.KeyCount)
                {
                    Assert.IsTrue(maxKey.Key.CompareTo(parent.GetKey(indexAtParentChildren)) <= 0);
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether tree has B Tree properties. 
        /// </summary>
        /// <param name="tree">A BTree node. </param>
        /// <param name="expectedTotalKeyCount">The expected number of keys (duplicate and distinct) in the tree. </param>
        /// <param name="expectedDistinctKeyCount">The expected number of distinct keys in the tree. </param>
        /// <param name="expectedNodeCount">The expected number of nodes in the tree. </param>
        public static void HasBTreeProperties(BTree<int, string> tree, int expectedTotalKeyCount, int expectedDistinctKeyCount, int expectedNodeCount)
        {
            Assert.IsTrue(HasBTreeProperties(tree, expectedTotalKeyCount, expectedDistinctKeyCount, expectedNodeCount, HasBTreeNodeProperties<BTreeNode<int, string>, int, string>));
        }

        /// <summary>
        /// Checks whether the tree has B+ Tree properties. 
        /// </summary>
        /// <param name="tree">A B + tree. </param>
        /// <param name="expectedTotalKeyCount">The expected number of keys (duplicate and distinct) in the tree. </param>
        /// <param name="expectedDistinctKeyCount">The expected number of distinct keys in the tree. </param>
        /// <param name="expectedNodeCount">The expected number of nodes in the tree. </param>
        public static void HasBPlusTreeProperties(BPlusTree<int, string> tree, int expectedTotalKeyCount, int expectedDistinctKeyCount, int expectedNodeCount)
        {
            Assert.IsTrue(HasBTreeProperties(tree, expectedTotalKeyCount, expectedDistinctKeyCount, expectedNodeCount, HasBPlusTreeNodeProperties));

            /* Check that all the non-leaf nodes have no value in their key value array*/
            var nodes = new List<BPlusTreeNode<int, string>>();
            DFS<BPlusTreeNode<int, string>, int, string>(tree.Root, nodes);
            foreach (var node in nodes)
            {
                if (!node.IsLeaf())
                {
                    foreach (KeyValuePair<int, string> keyVal in node.GetKeyValues())
                    {
                        Assert.AreEqual(default(string), keyVal.Value);
                    }
                }
            }
        }
    }
}
