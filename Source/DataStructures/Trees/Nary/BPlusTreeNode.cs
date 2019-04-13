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
using System.Linq;
using CSFundamentals.DataStructures.Trees.Nary.API;

namespace CSFundamentals.DataStructures.Trees.Nary
{
    public class BPlusTreeNode<TKey, TValue> :
        BTreeNodeBase<BPlusTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Only used by leaf nodes, and points to the leaf to its right (note that the right leaf may or may not be a sibling of the current leaf)
        /// </summary>
        public BPlusTreeNode<TKey, TValue> NextLeaf { get; set; } = null;

        /// <summary>
        /// Only used by leaf nodes, and points to the leaf to its left (note that the left leaf may or may not be a sibling of the current leaf)
        /// </summary>
        public BPlusTreeNode<TKey, TValue> PreviousLeaf { get; set; } = null;

        public BPlusTreeNode()
        {
        }

        /// <summary>
        /// Creates a node with no keys. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        public BPlusTreeNode(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        /// <summary>
        /// Creates a node with 1 key. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValue">Is a key-value pair to be inserted in the tree. </param>
        public BPlusTreeNode(int maxBranchingDegree, KeyValuePair<TKey, TValue> keyValue) : base(maxBranchingDegree, keyValue)
        {
        }

        /// <summary>
        /// Creates a node with a set of keys and children.
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValues">Is a set of key-value pairs to be inserted in the new node. </param>
        /// <param name="children">Is a set of children of the node. Expectancy is that the count of children is one bigger than the count of key-value pairs in the node. </param>
        public BPlusTreeNode(int maxBranchingDegree, List<KeyValuePair<TKey, TValue>> keyValues, List<BPlusTreeNode<TKey, TValue>> children) : base(maxBranchingDegree, keyValues, children)
        {
        }

        public void InsertKey(TKey key)
        {
            /* Since KeyValues is a sorted list, the new key value pair will be inserted at its correct position. */
            if (!_keyValues.ContainsKey(key)) /* SortedList does not allow for duplicates, yet checking this as otherwise it will throw an exception.*/
            {
                _keyValues.Add(key, default(TValue));
            }
        }

        public override int GetIndexAtParentChildren()
        {
            return _parent != null ? _parent.GetChildIndex(this) : throw new ArgumentException($"Failed to get index of the node at its parent's children array. Parent is null.");
        }

        // TODO: How could this method be moved to base class and redundant implementations dropped from b-tree variation
        /// <summary>
        /// Inserts a child in <see cref="_children"/> array.
        /// </summary>
        /// <param name="child">the new child to be inserted in <see cref="_children"/> array. </param>
        public override void InsertChild(BPlusTreeNode<TKey, TValue> child)
        {
            /* Since Children is a sorted list, Child will be inserted at its correct position based on the Compare() method, to preserve the ordering. */
            _children.Add(child, true);
            child.SetParent(this);
        }


        // TODO: add test
        public bool HasGrandChild()
        {
            return _children.Any() && _children.Any(child => child.Key.ChildrenCount > 0);
        }
    }
}
