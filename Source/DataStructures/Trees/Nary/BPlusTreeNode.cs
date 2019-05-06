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
using System.Linq;
using CSFundamentals.DataStructures.Trees.Nary.API;

namespace CSFundamentals.DataStructures.Trees.Nary
{
    /// <summary>
    /// Implements a B+ Tree node. 
    /// </summary>
    /// <typeparam name="TKey">Type of the keys in the tree. </typeparam>
    /// <typeparam name="TValue">Type of the values in the tree. </typeparam>
    public class BPlusTreeNode<TKey, TValue> :
        BTreeNodeBase<BPlusTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <value>
        /// Only used by leaf nodes, and points to the leaf to its right (note that the right leaf may or may not be a sibling of the current leaf)
        /// </value>
        public BPlusTreeNode<TKey, TValue> NextLeaf { get; set; } = null;

        /// <value>
        /// Only used by leaf nodes, and points to the leaf to its left (note that the left leaf may or may not be a sibling of the current leaf)
        /// </value>
        public BPlusTreeNode<TKey, TValue> PreviousLeaf { get; set; } = null;

        /// <summary>
        /// Parameter-less constructor.
        /// </summary>
        public BPlusTreeNode()
        {
        }

        /// <summary>
        /// Creates a node with no keys. 
        /// </summary>
        /// <param name="maxBranchingDegree">The maximum number of children the node can have. </param>
        public BPlusTreeNode(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        /// <summary>
        /// Creates a node with 1 key. 
        /// </summary>
        /// <param name="maxBranchingDegree">The maximum number of children the node can have. </param>
        /// <param name="keyValue">A key-value pair to be inserted in the tree. </param>
        public BPlusTreeNode(int maxBranchingDegree, KeyValuePair<TKey, TValue> keyValue) : base(maxBranchingDegree, keyValue)
        {
        }

        /// <summary>
        /// Creates a node with a set of keys and children.
        /// </summary>
        /// <param name="maxBranchingDegree">The maximum number of children the node can have. </param>
        /// <param name="keyValues">A set of key-value pairs to be inserted in the new node. </param>
        /// <param name="children">A set of children of the node. Expectancy is that the count of children is one bigger than the count of key-value pairs in the node. </param>
        public BPlusTreeNode(int maxBranchingDegree, List<KeyValuePair<TKey, TValue>> keyValues, List<BPlusTreeNode<TKey, TValue>> children) : base(maxBranchingDegree, keyValues, children)
        {
        }

        /// <summary>
        /// Inserts the given key in _keyValues array. 
        /// </summary>
        /// <param name="key">A key to be inserted in the _keyValues array. </param>
        public void InsertKey(TKey key)
        {
            /* Since KeyValues is a sorted list, the new key value pair will be inserted at its correct position. */
            if (!_keyValues.ContainsKey(key)) /* SortedList does not allow for duplicates, yet checking this as otherwise it will throw an exception.*/
            {
                _keyValues.Add(key, default(TValue));
            }
        }

        /// <summary>
        /// Gets the index of the current node in its parent's _children array. 
        /// </summary>
        /// <exception cref="ArgumentException">Throws if parent is null. </exception>
        /// <returns>index of the current node in its parent's _children array. </returns>
        public override int GetIndexAtParentChildren()
        {
            return _parent != null ? _parent.GetChildIndex(this) : throw new ArgumentException($"Failed to get index of the node at its parent's children array. Parent is null.");
        }

        // TODO: How could this method be moved to base class and redundant implementations dropped from b-tree variation
        /// <summary>
        /// Inserts a child in _children array.
        /// </summary>
        /// <param name="child">the new child to be inserted in _children array. </param>
        public override void InsertChild(BPlusTreeNode<TKey, TValue> child)
        {
            /* Since Children is a sorted list, Child will be inserted at its correct position based on the Compare() method, to preserve the ordering. */
            _children.Add(child, true);
            child.SetParent(this);
        }

        // TODO: add test
        /// <summary>
        /// Checks whether the current node has any grand children. 
        /// </summary>
        /// <returns>True if the current node has any grand child, and false otherwise. </returns>
        public bool HasGrandChild()
        {
            return _children.Any() && _children.Any(child => child.Key.ChildrenCount > 0);
        }
    }
}
