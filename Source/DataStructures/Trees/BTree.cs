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
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using CSFundamentals.Styling;

[assembly: InternalsVisibleTo("CSFundamentals")]
// TODO: Test, complexity
// ToDo: insert in a sorted list is o(n) thus how can these ops delete, insert etc be o(Log(n)) alone! this is not possible!
// it is like my sorted doubly linked list, insert is o(n), check if I have correctly written it, .. 

// TODO: Should protect the field from external manipulations, ... 
// TODO: FindMin(), FindMax() methods, ... given a root, on the subtree started on the given root, ... 
// TODO: SHall be easily be able to compute the maximum number of keys and key-values that such a tree can hold, ... 
// and should check at each state to make sure that the number of elements in the tree are smaller than this, ..
// TODO:for search  could we use binary search implementation from search part of this lib?
// search seems to be logK in logN....uses binary search within each node.... could we call the search in the node here?  
//TODO:  test with other degrees of trees, maybe created different test classes, 2-3 btree, 3-4 btree and so on

namespace CSFundamentals.DataStructures.Trees
{
    public class BTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Is the root of the tree. 
        /// </summary>
        public BTreeNode<TKey, TValue> Root = null;

        /// <summary>
        /// Is the maximum number of children for an internal or root node in this B-Tree. 
        /// </summary>
        public int MaxBranchingDegree { get; private set; }

        public BTree(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
        }

        /// <summary>
        /// Given the set of key values, builds a b-tree by inserting all the key-value pairs. 
        /// </summary>
        /// <param name="keyValues">Is the list of key values to be inserted in the tree. </param>
        /// <returns>Root of the tree. </returns>
        public BTreeNode<TKey, TValue> Build(Dictionary<TKey, TValue> keyValues)
        {
            foreach (KeyValuePair<TKey, TValue> keyValue in keyValues)
            {
                Insert(keyValue);
            }
            return Root;
        }

        /// <summary>
        /// Inserts a new key-value pair in the tree and returns root of the tree. 
        /// </summary>
        /// <param name="keyValue">Is the key-value pair to be inserted in the tree. </param>
        /// <returns>Root of the tree. </returns>
        public BTreeNode<TKey, TValue> Insert(KeyValuePair<TKey, TValue> keyValue)
        {
            /* Find the leaf node that should contain the new key-value pair. The leaf is found such that the order property of the B-Tree is preserved. */
            BTreeNode<TKey, TValue> leaf = FindLeafToInsertKey(Root, keyValue.Key);

            if (leaf == null) /* Means this is the first element of the tree, and we should create root. */
            {
                Root = new BTreeNode<TKey, TValue>(MaxBranchingDegree, keyValue);
                return Root;
            }
            else
            {
                leaf.InsertKeyValue(keyValue);

                /* As the leaf has a new value now, it might be overFlown. Split_Reapir detects this case and fixes it. */
                Split_Repair(leaf);
            }

            return Root;
        }

        /// <summary>
        /// Deletes the given key from the tree if it exists. 
        /// </summary>
        /// <param name="key">The key to be deleted from the tree. </param>
        /// <returns>True in case of success, and false otherwise. </returns>
        public bool Delete(TKey key)
        {
            try
            {
                /* First find the container node of the key, and then delete it.*/
                BTreeNode<TKey, TValue> node = Search(Root, key);
                return Delete(node, key);
            }
            catch (KeyNotFoundException) /* This means that the key does not exist in the tree, and thus the operation is not successful.*/
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes <paramref name="key"> from <paramref name="node">, assuming that key exists in the node.
        /// </summary>
        /// <param name="node">A node in tree that contains the given key <paramref name="key"/>. </param>
        /// <param name="key">The key that should be deleted from tree node <paramref name="node"/>.</param>
        internal bool Delete(BTreeNode<TKey, TValue> node, TKey key)
        {
            /* Get information about the node that might be needed later, but impossible to retrieve after the key is removed from the node. */
            BTreeNode<TKey, TValue> leftSibling = node.IsRoot() ? null : node.HasLeftSibling() ? node.GetLeftSibling() : null;
            BTreeNode<TKey, TValue> rightSibling = node.IsRoot() ? null : node.HasRightSibling() ? node.GetRightSibling() : null;
            int separatorWithLeftSiblingIndex = leftSibling == null ? -1 : leftSibling.GetIndexAtParentChildren();
            int separatorWithRighthSiblingIndex = rightSibling == null ? -1 : node.GetIndexAtParentChildren();

            /* If node is an internal node, find the predecessor key of the key in its left subtree and replace the key with it. Predecessor key belongs to a leaf node, thus the operation boils down to deleting the replacement key from this leaf node. */
            if (!node.IsLeaf())
            {
                int keyIndexAtNode = node.GetKeyIndex(key);
                var predecessorNode = node.GetPredecessorNode(keyIndexAtNode);
                node.RemoveKey(key);
                node.InsertKeyValue(predecessorNode.GetMaxKey());
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
        /// Rotates a key from the right sibling of the node via their parent to the node. 
        /// </summary>
        /// <param name="node">Is the receiver of a new key. </param>
        /// <param name="rightSibling">The node that lends a key to the process. This key moves to parent, and a key from parent moves to node. </param>
        internal BTreeNode<TKey, TValue> RotateLeft(BTreeNode<TKey, TValue> node, BTreeNode<TKey, TValue> rightSibling, int separatorIndex)
        {
            /* 1- Move the separator key in the parent to the underFlown node. */
            node.InsertKeyValue(node.Parent.GetKeyValue(separatorIndex));
            node.Parent.RemoveKeyByIndex(separatorIndex);

            /* 2- Replace separator key in the parent with the first key of the right sibling.*/
            node.Parent.InsertKeyValue(rightSibling.GetMinKey());

            /* 3- Remove the first (minimum) key from the right sibling, and move its child to node. */
            rightSibling.RemoveKey(rightSibling.GetMinKey().Key);
            if (rightSibling.ChildrenCount >= 1)
            {
                node.InsertChild(rightSibling.GetChild(0));
                rightSibling.RemoveChildByIndex(0);
            }

            /* Check Validity. At this point both the node and its right sibling must be MinFull (have exactly MinKeys keys). */
            Contract.Assert(rightSibling.IsMinFull());
            Contract.Assert(node.IsMinFull());

            return node.Parent;
        }

        /// <summary>
        /// Rotates a key from the left sibling of the node via their parent to the node.
        /// </summary>
        /// <param name="node">Is the receiver of a new key. </param>
        /// <param name="leftSibling">The node that lends a key to the process. This key moves to parent, and a key from parent moves to node.</param>
        internal BTreeNode<TKey, TValue> RotateRight(BTreeNode<TKey, TValue> node, BTreeNode<TKey, TValue> leftSibling, int separatorIndex)
        {
            /* 1- Move the separator key in the parent to the underFlown node. */
            node.InsertKeyValue(node.Parent.GetKeyValue(separatorIndex));
            node.Parent.RemoveKeyByIndex(separatorIndex);

            /* 2- Replace separator key in the parent with the last key of the left sibling. */
            node.Parent.InsertKeyValue(leftSibling.GetMaxKey());

            /* 3- Remove the last (maximum) key from the left sibling, and move its child to node. */
            leftSibling.RemoveKey(leftSibling.GetMaxKey().Key);
            if (leftSibling.ChildrenCount >= 1)
            {
                node.InsertChild(leftSibling.GetChild(leftSibling.ChildrenCount - 1));
                leftSibling.RemoveChildByIndex(leftSibling.ChildrenCount - 1);
            }

            /* Check validity. At this point both the node and its left sibling must be MinFull (have exactly MinKeys keys). */
            Contract.Assert(leftSibling.IsMinFull());
            Contract.Assert(node.IsMinFull());

            return node.Parent;
        }

        /// <summary>
        /// Merges node with its left sibling, such that node can be dropped. Also borrows a key from parent. 
        /// </summary>
        /// <param name="node">The node that will be dissolved at the end of operation. </param>
        /// <param name="leftSibling">The node that will contain keys of the node, its current keys, and a key from parent. </param>
        /// <returns>Parent of the nodes. </returns>
        internal BTreeNode<TKey, TValue> Join(BTreeNode<TKey, TValue> node, BTreeNode<TKey, TValue> leftSibling)
        {
            // 1- Move separator key to the left node
            int nodeAndLeftSiblingSeparatorKeyAtParentIndex = leftSibling.GetIndexAtParentChildren();
            leftSibling.InsertKeyValue(node.Parent.GetKeyValue(nodeAndLeftSiblingSeparatorKeyAtParentIndex));
            
            // 2- Remove separator key in the parent, and disconnect parent from node. 
            node.Parent.RemoveKeyByIndex(nodeAndLeftSiblingSeparatorKeyAtParentIndex);
            node.Parent.RemoveChildByIndex(nodeAndLeftSiblingSeparatorKeyAtParentIndex + 1);

            // 3- Join node with leftSibling: Move all the keys and children of node to its left sibling.
            for (int i = 0; i < node.KeyCount; i++)
            {
                leftSibling.InsertKeyValue(node.GetKeyValue(i));
            }
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                leftSibling.InsertChild(node.GetChild(i));
            }

            /* Clear node. */
            node.Clear();

            if (node.Parent.IsEmpty() && node.Parent.IsRoot()) /* Can happen if parent is root*/
            {
                leftSibling.Parent = null;
                Root = leftSibling;
            }

            // Since parent has lent a key to its children, it might be UnderFlown now, thus return the parent for additional checks.
            return leftSibling.Parent;
        }

        /// <summary>
        /// Re-balances the tree to restore back its properties. This method is called when node is underFlown, and thus must be fixed. 
        /// </summary>
        /// <param name="node">Specifies an underFlown node. </param>
        /// <param name="leftSibling">Is the left sibling of the underFlown node. </param>
        /// <param name="rightSibling">Is the right sibling of the underFlown node. </param>
        /// <param name="separatorWithLeftSiblingIndex">Is the index of the key in parent that separates node from its left sibling. </param>
        /// <param name="separatorWithRightSiblingIndex">Is the index of the key in parent that separates node from its right sibling. </param>
        public void ReBalance(BTreeNode<TKey, TValue> node, BTreeNode<TKey, TValue> leftSibling, BTreeNode<TKey, TValue> rightSibling, int separatorWithLeftSiblingIndex, int separatorWithRightSiblingIndex)
        {
            if (node.IsUnderFlown() && !node.IsRoot()) /* B-TRee allows UnderFlown roots*/
            {
                var parent = node.Parent;
                var parentLeftSibling = parent == null || parent.IsRoot() ? null : parent.HasLeftSibling() ? parent.GetLeftSibling() : null;
                var parentRightSibling = parent == null || parent.IsRoot() ? null : parent.HasRightSibling() ? parent.GetRightSibling() : null;
                int parentSeparatorWithLeftSiblingIndex = parentLeftSibling == null ? -1 : parentLeftSibling.GetIndexAtParentChildren();
                int parentSeparatorWithRightSiblingIndex = parentRightSibling == null ? -1 : parent.GetIndexAtParentChildren();

                if (leftSibling != null && leftSibling.IsMin1Full())
                {
                    node = RotateRight(node, leftSibling, separatorWithLeftSiblingIndex);
                    return;
                }
                else if (rightSibling != null && rightSibling.IsMin1Full())
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
                    return;

                ReBalance(node, parentLeftSibling, parentRightSibling, parentSeparatorWithLeftSiblingIndex, parentSeparatorWithRightSiblingIndex);
            }
        }

        /// <summary>
        /// If the given node/leaf is overflown, splits it and propagates the split to upper levels if needed.
        /// </summary>
        /// <param name="node">The node to be split</param>
        [TimeComplexity(Case.Best, "O(1)", When = "Split does not propagate to upper levels.")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n)))")]
        internal void Split_Repair(BTreeNode<TKey, TValue> node)
        {
            while (node.IsOverFlown())
            {
                BTreeNode<TKey, TValue> sibling = node.Split();
                KeyValuePair<TKey, TValue> keyToMoveToParent = node.KeyValueToMoveUp();
                node.RemoveKey(keyToMoveToParent.Key);

                if (node.Parent == null) /* Meaning the overflown node is the root. */
                {
                    Root = new BTreeNode<TKey, TValue>(MaxBranchingDegree, keyToMoveToParent); /* Creating a new root for the tree. */
                    Root.InsertChild(node); /* Notice that this method adjusts node's parent internally. */
                    Root.InsertChild(sibling);
                    break;
                }
                else
                {
                    node.Parent.InsertKeyValue(keyToMoveToParent);
                    node.Parent.InsertChild(sibling);
                    node = node.Parent; /* Repeat while loop with the parent node that might itself be overflown now after inserting a new key.*/
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
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        internal BTreeNode<TKey, TValue> FindLeafToInsertKey(BTreeNode<TKey, TValue> root, TKey key)
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
                else if (key.CompareTo(root.GetKey(i)) == 0) /* means a node which such key already exists.*/
                {
                    throw new ArgumentException("A node with this key exists in the tree. Duplicate keys are not allowed.");
                }
                else if (i == root.KeyCount - 1 && key.CompareTo(root.GetKey(i)) > 0)
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
        public BTreeNode<TKey, TValue> Search(BTreeNode<TKey, TValue> root, TKey key)
        {
            if (root != null)
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
                if (startIndex < root.ChildrenCount)
                {
                    return Search(root.GetChild(startIndex), key);
                }
            }
            throw new KeyNotFoundException($"{key.ToString()} is not found in the tree.");
        }

        /// <summary>
        /// Traverses tree in-order and generates list of keys sorted.
        /// </summary>
        /// <param name="node">The tree node at which traverse starts.</param>
        /// <param name="sortedKeys">List of the key-values sorted by their keys.</param>
        public void InOrderTraversal(BTreeNode<TKey, TValue> node, List<KeyValuePair<TKey, TValue>> sortedKeys)
        {
            if (node != null)
            {
                for (int i = 0; i < node.KeyCount; i++)
                {
                    if (!node.IsLeaf()) /* Leaf nodes do not have children */
                        InOrderTraversal(node.GetChild(i), sortedKeys);

                    sortedKeys.Add(node.GetKeyValue(i)); /* Visit the key. */

                    if (!node.IsLeaf() && i == node.KeyCount - 1) /* If is not leaf, and last key */
                        InOrderTraversal(node.GetChild(i + 1), sortedKeys);
                }
            }
        }
    }
}
