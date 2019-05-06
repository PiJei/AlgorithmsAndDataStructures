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

namespace CSFundamentals.DataStructures.Trees.Binary.API
{
    /// <summary>
    /// Specifies an interface for nodes in any tree structure. 
    /// </summary>
    /// <typeparam name="TNode">The type of the tree node. </typeparam>
    /// <typeparam name="TKey">The type of the keys in the tree nodes. </typeparam>
    /// <typeparam name="TValue">The type of the values in the tree nodes. </typeparam>
    public interface IBinaryTreeNode<TNode, TKey, TValue> :
        IComparable<TNode>
        where TKey : IComparable<TKey>
    {
        // TODO: Used by red black trees move to red black trees
        /// <value>If set means the node contains no key-values, no left and no right children. </value>
        bool IsNill { get; set; }

        /// <value>Key in this tree node. </value>
        TKey Key { get; set; }

        /// <value>Value (information) stored in this tree node (This can be converted to a list to store multiple values per key). </value> 
        TValue Value { get; set; }

        /// <value>Left child of this node. </value>
        TNode LeftChild { get; set; }

        /// <value>Right child of the node. </value>
        TNode RightChild { get; set; }

        /// <value> Parent of this node.</value>
        TNode Parent { get; set; }

        /// <summary>
        /// Check whether the current node is left child of its parent.
        /// </summary>
        /// <returns>True in case the current node is the left child of its parent, and false otherwise.</returns>
        bool IsLeftChild();

        /// <summary>
        /// Check whether the current node is right child of its parent.
        /// </summary>
        /// <returns>True in case the current node is the right child of its parent, and false otherwise. </returns>
        bool IsRightChild();

        /// <summary>
        /// Returns a list of the current node's children. 
        /// </summary>
        /// <returns></returns>
        List<TNode> GetChildren();
    }
}
