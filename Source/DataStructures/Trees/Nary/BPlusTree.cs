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
using CSFundamentals.DataStructures.Trees.Nary.API;
using CSFundamentals.Decoration;

namespace CSFundamentals.DataStructures.Trees.Nary
{
    [DataStructure("B+ Tree")]
    public class BPlusTree<TKey, TValue> :
        BTreeBase<BPlusTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public BPlusTree(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        public override bool Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public override BPlusTreeNode<TKey, TValue> InsertInLeaf(BPlusTreeNode<TKey, TValue> leaf, KeyValuePair<TKey, TValue> keyValue)
        {
            /* Means this is the first element of the tree, and we should create root. */
            if (leaf == null)
            {
                /* 1- Create a leaf node (aka. record) that can contain value besides key.*/
                BPlusTreeNode<TKey, TValue> leafContainingValue = new BPlusTreeNode<TKey, TValue>(MaxBranchingDegree, keyValue);

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
            List<KeyValuePair<TKey, TValue>> keyValues = new List<KeyValuePair<TKey, TValue>>();

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
        /// <param name="root">Is the top-most node at which search for the leaf starts.</param>
        /// <param name="key">Is the key for which a container leaf is being searched. </param>
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
                        return FindLeafToInsertKey(root.GetChild(i), key);
                    }
                    return FindLeafToInsertKey(root.GetChild(i + 1), key);
                }
            }
            return null;
        }
    }
}
