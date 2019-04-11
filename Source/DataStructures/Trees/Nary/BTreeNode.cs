﻿/* 
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
using CSFundamentals.DataStructures.Trees.Nary.API;

// TODO: somehow should not allow comparisons to nodes with other degrees, ... how can degree be considered, ...?

namespace CSFundamentals.DataStructures.Trees.Nary
{
    /// <summary>
    /// Implements a B-Tree node. A B-tree node is an ordered sequence of K keys, and K+1 children.
    /// </summary>
    /// <typeparam name="TKey">Is the type of the keys in the tree. </typeparam>
    /// <typeparam name="TValue">Is the type of the values in the tree. </typeparam>
    public class BTreeNode<TKey, TValue> :
        BTreeNodeBase<BTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Creates a node with no keys. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        public BTreeNode(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        /// <summary>
        /// Creates a node with 1 key. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValue">Is a key-value pair to be inserted in the tree. </param>
        public BTreeNode(int maxBranchingDegree, KeyValuePair<TKey, TValue> keyValue) : this(maxBranchingDegree)
        {
            InsertKeyValue(keyValue);
        }

        /// <summary>
        /// Creates a node with a set of keys and children.
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValues">Is a set of key-value pairs to be inserted in the new node. </param>
        /// <param name="children">Is a set of children of the node. Expectancy is that the count of children is one bigger than the count of key-value pairs in the node. </param>
        public BTreeNode(int maxBranchingDegree, List<KeyValuePair<TKey, TValue>> keyValues, List<BTreeNode<TKey, TValue>> children) : this(maxBranchingDegree)
        {
            foreach (var keyVal in keyValues)
            {
                InsertKeyValue(keyVal);
            }
            foreach (BTreeNode<TKey, TValue> child in children)
            {
                InsertChild(child);
            }
        }

        /// <summary>
        /// Gets the index of the current node in its parent's <see cref="_children"/> list.
        /// </summary>
        /// <returns>Index at parent's <see cref="_children"/> list.</returns>
        public override int GetIndexAtParentChildren()
        {
            return _parent != null ? _parent.GetChildIndex(this) : throw new ArgumentException($"Failed to get index of the node at its parent's children array. Parent is null.");
        }

        /// <summary>
        /// Inserts a child in <see cref="_children"/> array.
        /// </summary>
        /// <param name="child">the new child to be inserted in <see cref="_children"/> array. </param>
        public override void InsertChild(BTreeNode<TKey,TValue> child)
        {
            /* Since Children is a sorted list, Child will be inserted at its correct position based on the Compare() method, to preserve the ordering. */
            _children.Add(child, true);
            child.SetParent(this);
        }


        /// <summary>
        /// Splits this node to 2 nodes if it is overflown, such that each node has at least MinKeys keys.
        /// </summary>
        /// <returns>The new node. </returns>
        public BTreeNode<TKey, TValue> Split()
        {
            if (IsOverFlown())
            {
                /* A valid BtreeNode should at least have MinKey keys.*/
                List<KeyValuePair<TKey, TValue>> newNodeKeys = _keyValues.TakeLast(MinKeys).ToList();

                /* A valid non-leaf BTree node with MinKeys should have MinChildren children. */
                Dictionary<BTreeNode<TKey, TValue>, bool> newNodeChildren = _children
                    .TakeLast(MinBranchingDegree)
                    .ToDictionary(keyVal => keyVal.Key, keyVal => keyVal.Value);

                /* Remove the last MinKeys from this node.*/
                foreach (KeyValuePair<TKey, TValue> keyVal in newNodeKeys)
                {
                    _keyValues.Remove(keyVal.Key);
                }

                /* Remove last MinBranchingFactor children from this node. */
                foreach (KeyValuePair<BTreeNode<TKey, TValue>, bool> child in newNodeChildren)
                {
                    _children.Remove(child.Key);
                }

                return new BTreeNode<TKey, TValue>(MaxBranchingDegree, newNodeKeys, newNodeChildren.Keys.ToList());
            }

            return null;
        }

        /// <summary>
        /// When a node is being split into two nodes, gets the key that shall be moved to the parent of this node.
        /// This operation is expected to only be called upon a node that is full. Yet to prevent issues, first checks for the key count. 
        /// </summary>
        /// <returns>The key at the middle of the key-value pairs that shall be moved to the parent. </returns>
        public KeyValuePair<TKey, TValue> KeyValueToMoveUp()
        {
            if (IsMinOneFull())
            {
                return _keyValues.ElementAt(MinKeys); /* since the indexes tart at 0, this means that the node has MinKeys+1 keys. */
            }

            throw new ArgumentException($"Failed to get a key to move up to parent. The node has less or more than {MinKeys + 1} keys.");
        }

        /// <summary>
        /// Inserts the given key-value pair in <see cref="_keyValues"/> array. 
        /// </summary>
        /// <param name="keyVal">the new key-value pair to be inserted in <see cref="_keyValues"/> array. </param>
        public void InsertKeyValue(KeyValuePair<TKey, TValue> keyVal)
        {
            /* Since KeyValues is a sorted list, the new key value pair will be inserted at its correct position. */
            if (!_keyValues.ContainsKey(keyVal.Key)) /* SortedList does not allow for duplicates, yet checking this as otherwise it will throw an exception.*/
            {
                _keyValues.Add(keyVal.Key, keyVal.Value);
            }
        }
    }
}