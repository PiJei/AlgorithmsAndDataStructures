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

// TODO: Notations in complexities are not uniform. 
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSFundamentals.DataStructures.Trees.Nary.API;
using CSFundamentals.Decoration;

[assembly: InternalsVisibleTo("CSFundamentals")]

// TODO: Should protect  fields from external manipulations, ... 
// TODO: for search  could we use binary search implementation from search part of this lib?
// TODO:  test with other (than 2-3) degrees of trees

namespace CSFundamentals.DataStructures.Trees.Nary
{
    [DataStructure("BTree")]
    public class BTree<TKey, TValue> :
        BTreeBase<BTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public BTree(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        // TODO: In time complexities subscripts and superscripts do not look good.
        /// <summary>
        /// Inserts a new key-value pair in the tree and returns root of the tree. 
        /// </summary>
        /// <param name="keyValue">Is the key-value pair to be inserted in the tree. </param>
        /// <returns>Root of the tree. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Fist key in the tree is inserted.")]
        [TimeComplexity(Case.Worst, "O(D Log(n)(base:D)")] // where D is max branching factor of the tree. 
        [TimeComplexity(Case.Average, "O(d Log(n)(base d))")] // where d is min branching factor of the tree.  
        public override BTreeNode<TKey, TValue> InsertInLeaf(BTreeNode<TKey, TValue> leafNode, KeyValuePair<TKey, TValue> keyValue)
        {
            /* Means this is the first element of the tree, and we should create root. */
            if (leafNode == null)
            {
                Root = new BTreeNode<TKey, TValue>(MaxBranchingDegree, keyValue);
                return Root;
            }
            else
            {
                leafNode.InsertKeyValue(keyValue);

                /* As the leaf has a new value now, it might be overFlown. Split_Reapir detects this case and fixes it. */
                Split_Repair(leafNode);
            }

            return Root;
        }

        /// <summary>
        /// Deletes <paramref name="key"> from <paramref name="node">, assuming that key exists in the node.
        /// </summary>
        /// <param name="node">A node in tree that contains the given key <paramref name="key"/>. </param>
        /// <param name="key">The key that should be deleted from tree node <paramref name="node"/>.</param>
        public override bool Delete(BTreeNode<TKey, TValue> node, TKey key)
        {
            /* Get information about the node that might be needed later, but impossible to retrieve after the key is removed from the node. */
            BTreeNode<TKey, TValue> leftSibling = node.IsRoot() ? null : node.HasLeftSibling() ? node.GetLeftSibling() : null;
            BTreeNode<TKey, TValue> rightSibling = node.IsRoot() ? null : node.HasRightSibling() ? node.GetRightSibling() : null;
            int separatorWithLeftSiblingIndex = leftSibling == null ? -1 : leftSibling.GetIndexAtParentChildren();
            int separatorWithRighthSiblingIndex = rightSibling == null ? -1 : node.GetIndexAtParentChildren();

            /* If node is an internal node, find the predecessor key of the key in its left subtree and replace the key with it. Predecessor key belongs to a leaf node, thus the operation boils down to deleting the replacement key from this leaf node. */
            if (!node.IsLeaf())
            {
                /* Find the immediate predecessor of key in its left subtree. */
                int keyIndexAtNode = node.GetKeyIndex(key);
                BTreeNode<TKey, TValue> predecessorNode = GetMaxNode(node.GetChild(keyIndexAtNode));

                /* Remove key and replace it with its predecessor*/
                node.RemoveKey(key);
                node.InsertKeyValue(predecessorNode.GetMaxKey());

                /* Delete the replacement key from predecessor node (must be a leaf). */
                return Delete(predecessorNode, predecessorNode.GetMaxKey().Key);
            }
            else /* If node is leaf, remove the key from it, and then re balance if the node is under flown. */
            {
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
        }

        /// <summary>
        /// Re-balances the tree to restore back its properties. This method is called when node is underFlown, and thus must be fixed. 
        /// </summary>
        /// <param name="node">Specifies an underFlown node. </param>
        /// <param name="leftSibling">Is the left sibling of the underFlown node. </param>
        /// <param name="rightSibling">Is the right sibling of the underFlown node. </param>
        /// <param name="separatorWithLeftSiblingIndex">Is the index of the key in parent that separates node from its left sibling. </param>
        /// <param name="separatorWithRightSiblingIndex">Is the index of the key in parent that separates node from its right sibling. </param>
        [TimeComplexity(Case.Best, "O(1)", When = "There is no need to re-balance, or re-balance does not propagate to upper layers.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        public void ReBalance(BTreeNode<TKey, TValue> node, BTreeNode<TKey, TValue> leftSibling, BTreeNode<TKey, TValue> rightSibling, int separatorWithLeftSiblingIndex, int separatorWithRightSiblingIndex)
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
                    node = RotateRight(node, leftSibling, separatorWithLeftSiblingIndex);
                    return;
                }
                else if (rightSibling != null && rightSibling.IsMinOneFull())
                {
                    node = RotateLeft(node, rightSibling, separatorWithRightSiblingIndex);
                    return;
                }
                else if (rightSibling != null && rightSibling.IsMinFull()) /* Meaning rotation wont work, as borrowing key from the siblings via parent will leave the sibling UnderFlown.*/
                {
                    node = Join(rightSibling, node);
                }
                else if (leftSibling != null && leftSibling.IsMinFull())
                {
                    node = Join(node, leftSibling);
                }

                if (node == null)
                {
                    return;
                }

                ReBalance(node, parentLeftSibling, parentRightSibling, parentSeparatorWithLeftSiblingIndex, parentSeparatorWithRightSiblingIndex);
            }
        }

        /// <summary>
        /// If the given node/leaf is overflown, splits it and propagates the split to upper levels if needed.
        /// </summary>
        /// <param name="node">The node to be split</param>
        [TimeComplexity(Case.Best, "O(1)", When = "Split does not propagate to upper levels.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")] // todo
        [TimeComplexity(Case.Average, "O(Log(n)))")] // todo
        internal void Split_Repair(BTreeNode<TKey, TValue> node)
        {
            while (node.IsOverFlown())
            {
                BTreeNode<TKey, TValue> sibling = node.Split();
                KeyValuePair<TKey, TValue> keyToMoveToParent = node.KeyValueToMoveUp();
                node.RemoveKey(keyToMoveToParent.Key);

                if (node.GetParent() == null) /* Meaning the overflown node is the root. */
                {
                    Root = new BTreeNode<TKey, TValue>(MaxBranchingDegree, keyToMoveToParent); /* Creating a new root for the tree. */
                    Root.InsertChild(node); /* Notice that this method adjusts node's parent internally. */
                    Root.InsertChild(sibling);
                    break;
                }
                else
                {
                    node.GetParent().InsertKeyValue(keyToMoveToParent);
                    node.GetParent().InsertChild(sibling);
                    node = node.GetParent(); /* Repeat while loop with the parent node that might itself be overflown now after inserting a new key.*/
                }
            }
        }

        public override List<KeyValuePair<TKey, TValue>> GetSortedKeyValues(BTreeNode<TKey, TValue> node)
        {
            var sortedKeyValues = new List<KeyValuePair<TKey, TValue>>();
            InOrderTraversal(node, sortedKeyValues);
            return sortedKeyValues;
        }

        //TODO: What is complexity?
        /// <summary>
        /// Traverses tree in-order and generates list of keys sorted.
        /// </summary>
        /// <param name="node">The tree node at which traverse starts.</param>
        /// <param name="sortedKeyValues">List of the key-values sorted by their keys.</param>
        public void InOrderTraversal(BTreeNode<TKey, TValue> node, List<KeyValuePair<TKey, TValue>> sortedKeyValues)
        {
            if (node != null)
            {
                for (int i = 0; i < node.KeyCount; i++)
                {
                    if (!node.IsLeaf()) /* Leaf nodes do not have children */
                    {
                        InOrderTraversal(node.GetChild(i), sortedKeyValues);
                    }

                    sortedKeyValues.Add(node.GetKeyValue(i)); /* Visit the key. */

                    if (!node.IsLeaf() && i == node.KeyCount - 1) /* If is not leaf, and last key */
                    {
                        InOrderTraversal(node.GetChild(i + 1), sortedKeyValues);
                    }
                }
            }
        }

        /// <summary>
        /// Starting from the given root, recursively traverses tree top-down to find the proper leaf node, at which <paramref name="key"/> can be inserted. 
        /// </summary>
        /// <param name="root">Is the top-most node at which search for the leaf starts.</param>
        /// <param name="key">Is the key for which a container leaf is being searched. </param>
        /// <returns>Leaf node to insert the key. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "There is no node in the tree or only one node.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")] // todo
        [TimeComplexity(Case.Average, "O(Log(n))")] // todo 
        public override BTreeNode<TKey, TValue> FindLeafToInsertKey(BTreeNode<TKey, TValue> root, TKey key)
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
                    return FindLeafToInsertKey(root.GetChild(i + 1), key);
                }
            }
            return null;
        }

        /// <summary>
        ///  Searchers the given key in (sub)tree rooted at node <paramref name="root">.
        /// </summary>
        /// <param name="root">The root of the (sub) tree at which search starts. </param>
        /// <param name="key">Is the key to search for.</param>
        /// <returns>The node containing the key if it exists. Otherwise throws an exception. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Key is the first item of the first node to visit.")]
        [TimeComplexity(Case.Worst, "O(LogD Log(n)Base(D))")] // Each search with in a node uses binary-search which is Log(K) cost, and since it is constant is not included in this value. 
        [TimeComplexity(Case.Average, "O(Log(d) Log(n)Base(d))")]
        public override BTreeNode<TKey, TValue> Search(BTreeNode<TKey, TValue> root, TKey key)
        {
            if (root == null)
            {
                throw new KeyNotFoundException($"{key.ToString()} is not found in the tree.");
            }

            /* Perform a binary search within the node */
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

            /* If key is not found in the node, continue search in the child that is likely to contain the key. */
            if (startIndex < root.ChildrenCount)
            {
                return Search(root.GetChild(startIndex), key);
            }

            throw new KeyNotFoundException($"{key.ToString()} is not found in the tree.");
        }

        /// <summary>
        /// Given number of levels in the tree, computes the maximum number of keys the tree can hold. 
        /// </summary>
        /// <param name="levelCount">Is the number of levels in the tree. </param>
        /// <returns>Maximum number of keys a tree with <paramref name="levelCount"> levels can hold. </returns>
        public int GetMaxCapacity(int levelCount)
        {
            int maxKeys = 0;
            for (int l = 0; l < levelCount; l++)
            {
                maxKeys += (MaxBranchingDegree - 1) * (int)Math.Pow(MaxBranchingDegree, l);
            }
            return maxKeys;
        }
    }
}
