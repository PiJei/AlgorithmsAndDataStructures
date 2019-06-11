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
using AlgorithmsAndDataStructures.DataStructures.Trees.Nary.API;

// TODO: somehow should not allow comparisons to nodes with other degrees, ... how can degree be considered, ...?

namespace AlgorithmsAndDataStructures.DataStructures.Trees.Nary
{
    /// <summary>
    /// Implements a B-Tree node. A B-tree node is an ordered sequence of K keys, and K+1 children.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the tree. </typeparam>
    /// <typeparam name="TValue">The type of the values in the tree. </typeparam>
    public class BTreeNode<TKey, TValue> :
        BTreeNodeBase<BTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Parameter-less constructor. 
        /// </summary>
        public BTreeNode()
        {
        }

        /// <summary>
        /// Creates a node with no keys. 
        /// </summary>
        /// <param name="maxBranchingDegree">The maximum number of children the node can have. </param>
        public BTreeNode(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        /// <summary>
        /// Creates a node with 1 key. 
        /// </summary>
        /// <param name="maxBranchingDegree">The maximum number of children the node can have. </param>
        /// <param name="keyValue">A key-value pair to be inserted in the tree. </param>
        public BTreeNode(int maxBranchingDegree, KeyValuePair<TKey, TValue> keyValue) : base(maxBranchingDegree, keyValue)
        {
        }

        /// <summary>
        /// Creates a node with a set of keys and children.
        /// </summary>
        /// <param name="maxBranchingDegree">The maximum number of children the node can have. </param>
        /// <param name="keyValues">A set of key-value pairs to be inserted in the new node. </param>
        /// <param name="children">A set of children of the node. Expectancy is that the count of children is one bigger than the count of key-value pairs in the node. </param>
        public BTreeNode(int maxBranchingDegree, List<KeyValuePair<TKey, TValue>> keyValues, List<BTreeNode<TKey, TValue>> children) : base(maxBranchingDegree, keyValues, children)
        {
        }

        // TODO: Rather than having this replace this with a call on parent node! meaning you wont need this! and can move up
        /// <summary>
        /// Gets the index of the current node in its parent's _children list.
        /// </summary>
        /// <exception cref="ArgumentException">Throws if parent is null. </exception>
        /// <returns>Index at parent's _children list.</returns>
        public override int GetIndexAtParentChildren()
        {
            return _parent != null ? _parent.GetChildIndex(this) : throw new ArgumentException($"Failed to get index of the node at its parent's children array. Parent is null.");
        }

        /// <summary>
        /// Inserts a child in _children array.
        /// </summary>
        /// <param name="child">the new child to be inserted in _children array. </param>
        public override void InsertChild(BTreeNode<TKey, TValue> child)
        {
            /* Since Children is a sorted list, Child will be inserted at its correct position based on the Compare() method, to preserve the ordering. */
            _children.Add(child, true);
            child.SetParent(this);
        }
    }
}
