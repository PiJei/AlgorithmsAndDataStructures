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
using CSFundamentals.DataStructures.Trees.Nary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// TOD0: Compute levels and after each insert confirm it
namespace CSFundamentalsTests.DataStructures.Trees.Nary
{
    public static class BTreeTestsUtils
    {
        public static bool HasBTreeProperties<TKey, TValue>(BTree<TKey, TValue> tree, int expectedKeyCount, int expectedNodeCount) where TKey : IComparable<TKey>
        {
            List<BTreeNode<TKey, TValue>> nodes = new List<BTreeNode<TKey, TValue>>();
            DFS(tree.Root, nodes);
            Assert.AreEqual(expectedNodeCount, nodes.Count);

            int keyCount = 0;

            /* Checking whether all the nodes are proper BTree nodes. */
            foreach (BTreeNode<TKey, TValue> node in nodes)
            {
                Assert.IsTrue(HasBTreeNodeProperties(node));
                keyCount += node.KeyCount;
            }

            /* Check that key count of all the nodes matches the expected key count. */
            Assert.AreEqual(expectedKeyCount, keyCount);

            /* Get the sorted key list and make sure it is sorted. */
            List<KeyValuePair<TKey, TValue>> sortedKeys = new List<KeyValuePair<TKey, TValue>>();
            tree.InOrderTraversal(tree.Root, sortedKeys);
            Assert.AreEqual(expectedKeyCount, sortedKeys.Count);
            for (int i = 0; i < sortedKeys.Count - 1; i++)
            {
                Assert.IsTrue(sortedKeys[i].Key.CompareTo(sortedKeys[i + 1].Key) < 0);
            }

            /* TODO Check all the leave nodes are at the same level, or one level apart? */

            return true;
        }

        /// <summary>
        /// TODO: How to make this to use the dfs I have in the algorithms? 
        /// </summary>
        public static void DFS<T1, T2>(BTreeNode<T1, T2> node, List<BTreeNode<T1, T2>> nodes) where T1 : IComparable<T1>
        {
            if (node != null)
            {
                nodes.Add(node);
                for (int i = 0; i < node.ChildrenCount; i++)
                {
                    DFS(node.GetChild(i), nodes);
                }
            }
        }

        public static bool HasBTreeNodeProperties<TKey, TValue>(BTreeNode<TKey, TValue> node) where TKey : IComparable<TKey>
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
                BTreeNode<TKey, TValue> childNode = node.GetChild(i);
                KeyValuePair<TKey, TValue> childMinKey = childNode.GetMinKey();
                KeyValuePair<TKey, TValue> childMaxKey = childNode.GetMaxKey();

                if (i > 0)
                    Assert.IsTrue(childMinKey.Key.CompareTo(node.GetKey(i - 1)) > 0);
                if (i < node.KeyCount)
                    Assert.IsTrue(childMaxKey.Key.CompareTo(node.GetKey(i)) < 0);
            }

            /* Check the key range ordering of the node against its parent. */
            if (node.Parent != null)
            {
                KeyValuePair<TKey, TValue> minKey = node.GetMinKey();
                KeyValuePair<TKey, TValue> maxKey = node.GetMaxKey();
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
