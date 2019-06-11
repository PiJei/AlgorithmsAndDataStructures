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
using System.Diagnostics.Contracts;
using AlgorithmsAndDataStructures.DataStructures.Trees.Nary.API;
using AlgorithmsAndDataStructures.Decoration;

// TODO: update summaries: they are copies of the B-Tree and have issues, 
// TODO: capacity
namespace AlgorithmsAndDataStructures.DataStructures.Trees.Nary
{
    /// <summary>
    /// Implements a B+ Tree. 
    /// </summary>
    /// <typeparam name="TKey">Type of the keys stored in the tree. </typeparam>
    /// <typeparam name="TValue">Type of the values stored in the tree. </typeparam>
    [DataStructure("B+ Tree")]
    public class BPlusTree<TKey, TValue> :
        BTreeBase<BPlusTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="maxBranchingDegree">Maximum branching degree of the tree or the maximum number of children a node can have. </param>
        public BPlusTree(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        // TODO: which parts are repeated code, and how can it be shared, ... 
        /// <summary>
        /// Deletes the given key from the given node 
        /// </summary>
        /// <param name="node">The node to delete the key from. </param>
        /// <param name="key">The key to be deleted from the node. </param>
        /// <returns>True in case of success, and false otherwise. </returns>
        public override bool Delete(BPlusTreeNode<TKey, TValue> node, TKey key)
        {
            /* In B+ Tree deletes always happen in leaf nodes, because internal nodes do  not store values. */
            Contract.Assert(node.IsLeaf());

            /* Get information about the node that might be needed later, but impossible to retrieve after the key is removed from the node. */
            BPlusTreeNode<TKey, TValue> leftSibling = node.IsRoot() ? null : node.HasLeftSibling() ? node.GetLeftSibling() : null;
            BPlusTreeNode<TKey, TValue> rightSibling = node.IsRoot() ? null : node.HasRightSibling() ? node.GetRightSibling() : null;
            int separatorWithLeftSiblingIndex = leftSibling == null ? -1 : leftSibling.GetIndexAtParentChildren();
            int separatorWithRighthSiblingIndex = rightSibling == null ? -1 : node.GetIndexAtParentChildren();

            /* Remove key from leaf node.*/
            node.RemoveKey(key);

            if (node.IsEmpty() && node.IsRoot())
            {
                Root = null;
                return true;
            }

            if (node.IsUnderFlown())
            {
                ReBalance(node, leftSibling, rightSibling, separatorWithLeftSiblingIndex, separatorWithRighthSiblingIndex);
            }
            return true;
        }

        /// <summary>
        /// Re-balances the tree to restore back its properties. This method is called when node is underFlown, and thus must be fixed. 
        /// </summary>
        /// <param name="node">An underFlown node. </param>
        /// <param name="leftSibling">The left sibling of the underFlown node. </param>
        /// <param name="rightSibling">The right sibling of the underFlown node. </param>
        /// <param name="separatorWithLeftSiblingIndex">The index of the key in parent that separates node from its left sibling. </param>
        /// <param name="separatorWithRightSiblingIndex">The index of the key in parent that separates node from its right sibling. </param>
        [TimeComplexity(Case.Best, "O(1)", When = "There is no need to re-balance, or re-balance does not propagate to upper layers.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        public void ReBalance(BPlusTreeNode<TKey, TValue> node, BPlusTreeNode<TKey, TValue> leftSibling, BPlusTreeNode<TKey, TValue> rightSibling, int separatorWithLeftSiblingIndex, int separatorWithRightSiblingIndex)
        {
            if (node.IsUnderFlown() && !node.IsRoot()) /* B-TRee allows UnderFlown roots*/
            {
                var parent = node.GetParent();
                var parentLeftSibling = parent == null || parent.IsRoot() ? null : parent.HasLeftSibling() ? parent.GetLeftSibling() : null;
                var parentRightSibling = parent == null || parent.IsRoot() ? null : parent.HasRightSibling() ? parent.GetRightSibling() : null;
                int parentSeparatorWithLeftSiblingIndex = parentLeftSibling == null ? -1 : parentLeftSibling.GetIndexAtParentChildren();
                int parentSeparatorWithRightSiblingIndex = parentRightSibling == null ? -1 : parent.GetIndexAtParentChildren();

                if (leftSibling != null && leftSibling.IsMinOneFull())
                {
                    if (!node.IsLeaf())
                    {
                        RotateRight(node, leftSibling, separatorWithLeftSiblingIndex);
                    }
                    else
                    {
                        RotateRightAtLeafLevel(node, leftSibling, separatorWithLeftSiblingIndex);
                    }

                    return;
                }
                else if (rightSibling != null && rightSibling.IsMinOneFull())
                {
                    if (!node.IsLeaf())
                    {
                        RotateLeft(node, rightSibling, separatorWithRightSiblingIndex);
                    }
                    else
                    {
                        RotateLeftAtLeafLevel(node, rightSibling, separatorWithRightSiblingIndex);
                    }

                    return;
                }
                else if (rightSibling != null && rightSibling.IsMinFull()) /* Meaning rotation wont work, as borrowing key from the siblings via parent will leave the sibling UnderFlown.*/
                {
                    if (!node.IsLeaf())
                    {
                        node = Join(rightSibling, node);
                    }
                    else
                    {
                        node = JoinAtLeafLevel(rightSibling, node);
                    }
                }
                else if (leftSibling != null && leftSibling.IsMinFull())
                {
                    if (!node.IsLeaf())
                    {
                        node = Join(node, leftSibling);
                    }
                    else
                    {
                        node = JoinAtLeafLevel(node, leftSibling);
                    }
                }
                else if (rightSibling == null && leftSibling == null && parent.IsRoot() && node.IsEmpty())
                {
                    // Means this is the last real key-value of the tree, set the root to null. 
                    Root = null;
                    return;
                }

                if (node == null)
                {
                    return;
                }

                ReBalance(node, parentLeftSibling, parentRightSibling, parentSeparatorWithLeftSiblingIndex, parentSeparatorWithRightSiblingIndex);
            }
        }

        /// <summary>
        /// Rotates a key from the left sibling of the node via their parent to the node.
        /// The cost of this operation is at inserting keys and children, in right position (to preserve order), Which at worst is O(K), Where K is the maximum number of keys in a node, and thus is constant. 
        /// </summary>
        /// <param name="node">The receiver of a new key. </param>
        /// <param name="leftSibling">Node that lends a key to the process. This key moves to parent, and a key from parent moves to node.</param>
        /// <param name="separatorIndex">Separator index of <paramref name="node"/> and <paramref name="leftSibling"/> nodes in their parent _keyValues array.</param>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(K)")] // Constant time as is independent of n: number of keys in tree. 
        [TimeComplexity(Case.Average, "O(K)")] // Constant time as is independent of n: number of keys in tree. 
        internal void RotateRightAtLeafLevel(BPlusTreeNode<TKey, TValue> node, BPlusTreeNode<TKey, TValue> leftSibling, int separatorIndex)
        {
            /* 1- Move the last (maximum) key from the left sibling to the underFlown node. */
            node.InsertKeyValue(leftSibling.GetMaxKey());

            /* 2- Remove the last (maximum) key from the left sibling. */
            leftSibling.RemoveKey(leftSibling.GetMaxKey().Key);

            /* 3- Replace separator key in the parent with the current last key of the left sibling. */
            node.GetParent().RemoveKeyByIndex(separatorIndex);
            node.GetParent().InsertKey(leftSibling.GetMaxKey().Key);

            /* Check validity. At this point both the node and its left sibling must be MinFull (have exactly MinKeys keys). */
            Contract.Assert(leftSibling.IsMinFull());
            Contract.Assert(node.IsMinFull());
        }

        /// <summary>
        /// Rotates a key from the right sibling of the node via their parent to the node. 
        /// The cost of this operation is at inserting keys and children, in right position (to preserve order), Which at worst is O(K), Where K is the maximum number of keys in a node, and thus is constant. 
        /// </summary>
        /// <param name="node">Is the receiver of a new key. </param>
        /// <param name="rightSibling">The node that lends a key to the process. This key moves to parent, and a key from parent moves to node. </param>
        /// <param name="separatorIndex">The separator index of <paramref name="node"/> and <paramref name="rightSibling"/> nodes in their parent _keyValues array.</param>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(K)")] // Constant time as is independent of n: number of keys in tree. 
        [TimeComplexity(Case.Average, "O(K)")] // Constant time as is independent of n: number of keys in tree. 
        internal void RotateLeftAtLeafLevel(BPlusTreeNode<TKey, TValue> node, BPlusTreeNode<TKey, TValue> rightSibling, int separatorIndex)
        {
            /* 1- Move the first (minimum) key from the right sibling to the underFlown node. */
            node.InsertKeyValue(rightSibling.GetMinKey());

            /* 2- Remove the first (minimum) key from the right sibling. */
            rightSibling.RemoveKey(rightSibling.GetMinKey().Key);

            /* 3- Replace separator key in the parent with the current maximum key of the node.*/
            node.GetParent().RemoveKeyByIndex(separatorIndex);
            node.GetParent().InsertKey(node.GetMaxKey().Key);

            /* Check Validity. At this point both the node and its right sibling must be MinFull (have exactly MinKeys keys). */
            Contract.Assert(rightSibling.IsMinFull());
            Contract.Assert(node.IsMinFull());
        }

        /// <summary>
        /// Merges node with its left sibling, such that node can be dropped. Also borrows a key from parent. 
        /// </summary>
        /// <param name="node">The node that will be dissolved at the end of operation. </param>
        /// <param name="leftSibling">The node that will contain keys of the node, its current keys, and a key from parent. </param>
        /// <returns>Parent of the nodes. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(K)")] // Constant time as is independent of n: number of keys in tree. 
        [TimeComplexity(Case.Average, "O(K)")] // Constant time as is independent of n: number of keys in tree. 
        internal BPlusTreeNode<TKey, TValue> JoinAtLeafLevel(BPlusTreeNode<TKey, TValue> node, BPlusTreeNode<TKey, TValue> leftSibling)
        {
            var parent = node.GetParent();

            int nodeAndLeftSiblingSeparatorKeyAtParentIndex = leftSibling.GetIndexAtParentChildren();

            // 1- Disconnect parent from node. 
            parent.RemoveChildByIndex(nodeAndLeftSiblingSeparatorKeyAtParentIndex + 1);

            // 2- Join node with leftSibling: Move all the keys of node to its left sibling.
            for (int i = 0; i < node.KeyCount; i++)
            {
                leftSibling.InsertKeyValue(node.GetKeyValue(i));
            }

            // 3- Update the next pointer of the left sibling. 
            leftSibling.NextLeaf = node.NextLeaf;

            /* Clear node. */
            node.Clear();

            // 4- Remove separator key in the parent if needed
            parent.RemoveKeyByIndex(nodeAndLeftSiblingSeparatorKeyAtParentIndex);

            if (parent == Root && parent.ChildrenCount == 1)
            {
                parent.InsertKey(leftSibling.GetMaxKey().Key);
            }

            // Since parent has lent a key to its children, it might be UnderFlown now, thus return the parent for additional checks.
            return leftSibling.GetParent();

        }

        /// <summary>
        /// Inserts the given key-value pair in the given leaf node. 
        /// </summary>
        /// <param name="leaf">A leaf node in the tree. </param>
        /// <param name="keyValue">A key-value pair to be inserted in the tree. </param>
        /// <returns>Root of the tree. </returns>
        public override BPlusTreeNode<TKey, TValue> InsertInLeaf(BPlusTreeNode<TKey, TValue> leaf, KeyValuePair<TKey, TValue> keyValue)
        {
            /* Means this is the first element of the tree, and we should create root. */
            if (leaf == null && Root == null)
            {
                /* 1- Create a leaf node (aka. record) that can contain value besides key.*/
                var leafContainingValue = new BPlusTreeNode<TKey, TValue>(MaxBranchingDegree, keyValue);

                /* 2- Create an internal node (here root) that will contain only a copy of the key, and the record as its child. */
                Root = new BPlusTreeNode<TKey, TValue>(
                    MaxBranchingDegree,
                    new List<KeyValuePair<TKey, TValue>>
                    {
                        new KeyValuePair<TKey, TValue>(keyValue.Key, default(TValue))
                    },
                    new List<BPlusTreeNode<TKey, TValue>>
                    {
                        leafContainingValue
                    });
            }
            else if (leaf == null && Root != null) /* This means we are inserting in a root child. */
            {
                leaf = new BPlusTreeNode<TKey, TValue>(MaxBranchingDegree, keyValue);
                Root.InsertChild(leaf);
                int indexAtParent = Root.GetChildIndex(leaf);
                if (indexAtParent > 0)
                {
                    var leftSibling = Root.GetChild(indexAtParent - 1);
                    leftSibling.NextLeaf = leaf;
                    leaf.PreviousLeaf = leftSibling;
                }
            }
            else
            {
                leaf.InsertKeyValue(keyValue);
                Split_Repair(leaf);
            }

            return Root;
        }

        internal void Split_Repair(BPlusTreeNode<TKey, TValue> node)
        {
            while (node.IsOverFlown())
            {
                BPlusTreeNode<TKey, TValue> sibling = node.Split();
                KeyValuePair<TKey, TValue> keyValueToMoveToParent = node.KeyValueToMoveUp();

                if (!node.IsLeaf())
                {
                    node.RemoveKey(keyValueToMoveToParent.Key);
                }
                else // Adjust next and previous links for the leaf nodes.
                {
                    sibling.NextLeaf = node.NextLeaf;
                    sibling.PreviousLeaf = node;
                    node.NextLeaf = sibling;
                }

                var parent = node.GetParent();

                if (parent == null) /* Meaning the overflown node is the root. */
                {
                    /* Create a new root for the tree. */
                    Root = new BPlusTreeNode<TKey, TValue>(MaxBranchingDegree);
                    Root.InsertKey(keyValueToMoveToParent.Key); /* Notice dropping value, as internal nodes in B+Tree do not store values.*/

                    /* Update children of the new node. */
                    /* Notice that InsertChild() method adjusts node's parent internally. */
                    Root.InsertChild(node);
                    Root.InsertChild(sibling);
                    break;
                }
                else
                {
                    parent.InsertKey(keyValueToMoveToParent.Key);
                    parent.InsertChild(sibling);

                    /* Update node, and repeat while loop with the parent node that might itself be overflown now after inserting a new key.*/
                    node = parent;
                }
            }
        }

        /// <summary>
        /// Traverses the doubly linked list at the level of leaves and returns the list of all the key-values in leaves in a sorted order (sorted by key)
        /// </summary>
        /// <returns></returns>
        public override List<KeyValuePair<TKey, TValue>> GetSortedKeyValues(BPlusTreeNode<TKey, TValue> node)
        {
            var keyValues = new List<KeyValuePair<TKey, TValue>>();

            BPlusTreeNode<TKey, TValue> minLeaf = GetMinNode(node);
            while (minLeaf != null)
            {
                keyValues.AddRange(minLeaf.GetKeyValues());
                minLeaf = minLeaf.NextLeaf;
            }
            return keyValues;
        }

        /// <summary>
        /// Starting from the given root, recursively traverses tree top-down to find the proper leaf node, at which <paramref name="key"/> can be inserted. 
        /// </summary>
        /// <exception cref="ArgumentException">Throws if <paramref name="key"/> already exists in the tree. </exception>
        /// <param name="root">The top-most node at which search for the leaf starts.</param>
        /// <param name="key">The key for which a container leaf is being searched. </param>
        /// <returns>Leaf node to insert the key. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "There is no node in the tree or only one node.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")] // todo
        [TimeComplexity(Case.Average, "O(Log(n))")] // todo 
        public override BPlusTreeNode<TKey, TValue> FindLeafToInsertKey(BPlusTreeNode<TKey, TValue> root, TKey key)
        {
            if (root == null || root.IsLeaf())
            {
                return root;
            }
            for (int i = 0; i < root.KeyCount; i++)
            {
                if (key.CompareTo(root.GetKey(i)) < 0)
                {
                    return FindLeafToInsertKey(root.GetChild(i), key);
                }
                else if (key.CompareTo(root.GetKey(i)) == 0) /* means a node with such key already exists.*/
                {
                    throw new ArgumentException("A node with this key exists in the tree. Duplicate keys are not allowed.");
                }
                else if (i == root.KeyCount - 1 && key.CompareTo(root.GetKey(i)) > 0) /*Last key is treated differently because it also has a child to its right.*/
                {
                    if (root.IsRoot() && root.ChildrenCount <= root.KeyCount)
                    {
                        //return FindLeafToInsertKey(root.GetChild(i), key);
                        //return null;
                        return FindLeafToInsertKey(null, key);
                    }
                    return FindLeafToInsertKey(root.GetChild(i + 1), key);
                }
            }
            return null;
        }


        /// <summary>
        ///  Searchers the given key in leaf nodes of the (sub)tree rooted at node <paramref name="root"/>.
        /// </summary>
        /// <exception cref="KeyNotFoundException">Throws if <paramref name="key"/> does not exist in the tree. </exception>
        /// <param name="root">The root of the (sub) tree at which search starts. </param>
        /// <param name="key">The key to search for.</param>
        /// <returns>The leaf node containing the key if it exists. Otherwise throws an exception. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Key is the first item of the first node to visit.")]
        [TimeComplexity(Case.Worst, "O(LogD Log(n)Base(D))")] // Each search with in a node uses binary-search which is Log(K) cost, and since it is constant is not included in this value. 
        [TimeComplexity(Case.Average, "O(Log(d) Log(n)Base(d))")]
        public override BPlusTreeNode<TKey, TValue> Search(BPlusTreeNode<TKey, TValue> root, TKey key)
        {
            if (root == null)
            {
                throw new KeyNotFoundException($"{key.ToString()} is not found in the tree.");
            }

            /* Perform a binary search in the leaf node to find the key, or throw an exception if it is not found. */
            if (root.IsLeaf())
            {
                int startIndex = 0;
                int endIndex = root.KeyCount - 1;
                while (startIndex <= endIndex)
                {
                    int middleIndex = (startIndex + endIndex) / 2;
                    if (root.GetKey(middleIndex).CompareTo(key) == 0)
                    {
                        return root;
                    }
                    else if (root.GetKey(middleIndex).CompareTo(key) > 0) /* search left-half of the root.*/
                    {
                        endIndex = middleIndex - 1;
                    }
                    else if (root.GetKey(middleIndex).CompareTo(key) < 0) /* search right-half of the root. */
                    {
                        startIndex = middleIndex + 1;
                    }
                }

                /* Means the leaf does not contain the key*/
                if (startIndex > endIndex)
                {
                    throw new KeyNotFoundException($"{key.ToString()} is not found in the tree.");
                }
            }

            /* Root is an internal node. Choose the right child to traverse down to find a container leaf. */
            for (int i = 0; i < root.KeyCount; i++)
            {
                if (key.CompareTo(root.GetKey(i)) <= 0)
                {
                    return Search(root.GetChild(i), key);
                }
                else if (i == root.KeyCount - 1 && i <= root.ChildrenCount - 1)
                {
                    return Search(root.GetChild(i + 1), key);
                }
            }

            throw new KeyNotFoundException($"{key.ToString()} is not found in the tree.");
        }
    }
}
