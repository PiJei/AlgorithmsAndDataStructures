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
using System.Linq;
using System.Runtime.CompilerServices;
using CSFundamentals.Styling;

[assembly: InternalsVisibleTo("CSFundamentals")]

namespace CSFundamentals.DataStructures.Trees
{
    public class BTree<T1, T2> where T1 : IComparable<T1>
    {
        // TODO: Should protect the field from external manipulations, ... 
        // TODO: FindMin(), FindMax() methods, ... given a root, on the subtree started on the given root, ... 
        // TODO: SHall be easily be able to compute the maximum number of keys and key-values that such a tree can hold, ... 
        // and should check at each state to make sure that the number of elements in the tree are smaller than this, ..
        // TODO: Test the in-order traversal as well, ... 
        /// <summary>
        /// Is the root of the tree. 
        /// </summary>
        public BTreeNode<T1, T2> Root = null;

        /// <summary>
        /// Is the maximum number of children for an internal or root node in this B-Tree. 
        /// </summary>
        public int MaxBranchingDegree { get; private set; }

        public BTree(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
        }

        /// <summary>
        /// Given the set of key values, builds a b-tree
        /// </summary>
        /// <param name="keyValues">Is the list of key values to be inserted in the tree. </param>
        /// <returns>Root of the tree. </returns>
        public BTreeNode<T1, T2> Build(Dictionary<T1, T2> keyValues)
        {
            foreach (KeyValuePair<T1, T2> keyValue in keyValues)
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

        public BTreeNode<T1, T2> Insert(KeyValuePair<T1, T2> keyValue)
        {
            BTreeNode<T1, T2> leaf = FindLeafToInsertKey(Root, keyValue.Key);
            if (leaf == null) /* Means this is the first element of the tree, and we should create root. */
            {
                Root = new BTreeNode<T1, T2>(MaxBranchingDegree, keyValue);
                return Root;
            }
            else
            {
                leaf.InsertKey(keyValue);
                Split_Repair(leaf);
            }

            return Root;
        }


        public bool Delete(T1 key)
        {
            try
            {
                BTreeNode<T1, T2> node = Search(Root, key);
                return Delete(node, key);
            }
            catch (KeyNotFoundException) /* This means that the key does not exist in the tree.*/
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes <paramref name="key"> from <paramref name="node">, assuming that key exists in node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        internal bool Delete(BTreeNode<T1, T2> node, T1 key)
        {
            if (node.IsLeaf()) /* Deleting a key from a leaf node. */
            {
                /* Remove the key. */
                node.RemoveKey(key);

                if (node.IsEmpty() && node.IsRoot())
                {
                    Root = null;
                    return true;
                }

                /* If node is underFlown restructure the tree. */
                if (node.IsUnderFlown() && !node.IsRoot()) /* B-TRee allows UnderFlown roots/*/
                {
                    BTreeNode<T1, T2> leftSibling = node.GetLeftSibling();
                    BTreeNode<T1, T2> rightSibling = node.GetRightSibling();

                    if (leftSibling != null && leftSibling.IsMin1Full())
                    {
                        RotateRight(node, leftSibling);
                    }
                    else if (rightSibling != null && rightSibling.IsMin1Full())
                    {
                        RotateLeft(node, rightSibling);
                    }
                    else if (leftSibling != null && rightSibling != null &&
                        leftSibling.IsMinFull() && rightSibling.IsMinFull()) /* Meaning rotation wont work, as borrowing key from the siblings via parent will leave the sibling UnderFlown.*/
                    {
                        Join(node, leftSibling);
                    }
                }

            }
            else /* Deleting a key from a non-leaf node. */
            {
                // get the max key from the left side of the key
                BTreeNode<T1, T2> leftChildOfKey = node.GetChild(node.GetKeyIndex(key));
                KeyValuePair<T1, T2> replacementKey = leftChildOfKey.GetMaxKey();
                node.RemoveKey(key); // TODO Make this deleteKey similar to insert key, we dont want to expose keyvalues, ... 
                node.InsertKey(replacementKey);
                Delete(leftChildOfKey, replacementKey.Key);


                // check if the left side is underflown, .. then repeat the same thing you would do for the parent below, ... 
                // this underflown maybe leaf, may not be leaf, .. for the maynot be part, I dont yet have a solution, ... 
            }

            return true; // TODO: On what cases can return false? ... 
        }

        // TODO: Test, complexity, summary, ... 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="rightSibling"></param>
        internal void RotateLeft(BTreeNode<T1, T2> node, BTreeNode<T1, T2> rightSibling)
        {
            int nodeAndRightSiblingSeparatorKeyAtParentIndex = node.GetIndexAtParentChildren();

            /* 1- Move the separator key in the parent to the underFlown node. */
            node.InsertKey(node.Parent.GetKeyValue(nodeAndRightSiblingSeparatorKeyAtParentIndex));
            node.Parent.RemoveKey(nodeAndRightSiblingSeparatorKeyAtParentIndex);

            /* 2- Replace separator key in the parent with the first key of the right sibling.*/
            node.Parent.InsertKey(rightSibling.GetMinKey());
            rightSibling.RemoveKey(rightSibling.GetMinKey().Key);

            /* Check Validity. At this point both the node and its right sibling must be MinFull (have exactly MinKeys keys). */
            Contract.Assert(rightSibling.IsMinFull());
            Contract.Assert(node.IsMinFull());
        }

        /// <summary>
        /// Rotates a key from <paramref name="leftSibling"/> to the common parent of <paramref name="node"/> & <paramref name="leftSibling"/>, and moves the separator key from the common parent to <paramref name="node"/>
        /// </summary>
        /// <param name="node">Is an UnderFlown leaf node. </param>
        /// <param name="leftSibling">Is left sibling of <paramref name="node"/></param>
        internal void RotateRight(BTreeNode<T1, T2> node, BTreeNode<T1, T2> leftSibling)
        {
            int nodeAndLeftSiblingSeparatorKeyAtParentIndex = leftSibling.GetIndexAtParentChildren();

            /* 1- Move the separator key in the parent to the underFlown node. */
            node.InsertKey(node.Parent.GetKeyValue(nodeAndLeftSiblingSeparatorKeyAtParentIndex));
            node.Parent.RemoveKey(nodeAndLeftSiblingSeparatorKeyAtParentIndex);

            /* 2- Replace separator key in the parent with the last key of the left sibling. */
            node.Parent.InsertKey(leftSibling.GetMaxKey());
            leftSibling.RemoveKey(leftSibling.GetMaxKey().Key);

            /* Check validity. At this point both the node and its left sibling must be MinFull (have exactly MinKeys keys). */
            Contract.Assert(leftSibling.IsMinFull());
            Contract.Assert(node.IsMinFull());
        }


        // Todo: insert in a sorted list is o(n) thus how can these ops delete, insert etc be o(logn) alone! this is not possible!
        // it si like my sorted doubly linked list, insert is o(n), check if I have correctly written it, .. 
        internal void Join(BTreeNode<T1, T2> node, BTreeNode<T1, T2> leftSibling)
        {
            // 1- Move separator key to the left node
            int nodeAndLeftSiblingSeparatorKeyAtParentIndex = leftSibling.GetIndexAtParentChildren();
            leftSibling.InsertKey(node.Parent.GetKeyValue(nodeAndLeftSiblingSeparatorKeyAtParentIndex));
            node.Parent.RemoveKey(nodeAndLeftSiblingSeparatorKeyAtParentIndex);

            // 2- Join node with leftSibling: Move all the keys at node to left node
            for (int i = 0; i < node.KeyCount; i++)
            {
                leftSibling.InsertKey(node.GetKeyValue(i));
            }
            node.Clear();
            node.Parent.RemoveChild(nodeAndLeftSiblingSeparatorKeyAtParentIndex + 1);

            if (node.Parent.IsEmpty()) /* Can happen if parent is root*/
            {
                leftSibling.Parent = null;
                Root = leftSibling;
            }

            else if (node.Parent.IsUnderFlown()) /* Note that root is allowed to be underflown. */
            {
                // TODO: Re-structure
                // could this be considered as deleting a key from parent and call on the parent instead?
            }
        }

        /// <summary>
        /// If the given node/leaf is overflown, splits it and propagates the split to upper levels if needed.
        /// </summary>
        /// <param name="node">The node to be split</param>
        [TimeComplexity(Case.Best, "O(1)", When = "Split does not propagate to upper levels.")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n)))")]
        internal void Split_Repair(BTreeNode<T1, T2> node)
        {
            while (node.IsOverFlown())
            {
                BTreeNode<T1, T2> sibling = node.Split();
                KeyValuePair<T1, T2> keyToMoveToParent = node.KeyToMoveUp();
                node.RemoveKey(keyToMoveToParent.Key);

                if (node.Parent == null) /* Meaning the overflown node is the root. */
                {
                    Root = new BTreeNode<T1, T2>(MaxBranchingDegree, keyToMoveToParent); /* Creating a new root for the tree. */
                    Root.InsertChild(node); /* Notice that this method adjusts node's parent internally. */
                    Root.InsertChild(sibling);
                    break;
                }
                else
                {
                    node.Parent.InsertKey(keyToMoveToParent);
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
        internal BTreeNode<T1, T2> FindLeafToInsertKey(BTreeNode<T1, T2> root, T1 key)
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

        // TODO: could we use binary search implementation from search part of this lib?
        /// <summary>
        ///  search seems to be logK in logN....uses binary search within each node.... could we call the search in the node here?  
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public BTreeNode<T1, T2> Search(BTreeNode<T1, T2> root, T1 key)
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

        // todo: test  for all methods here, .

        // todo: complexity
        /// <summary>
        /// Traverses tree in-order and generates list of keys sorted.
        /// </summary>
        /// <param name="node">The tree node at which traverse starts.</param>
        /// <param name="sortedKeys">List of the key-values sorted by their keys.</param>
        public void InOrderTraversal(BTreeNode<T1, T2> node, List<KeyValuePair<T1, T2>> sortedKeys)
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
