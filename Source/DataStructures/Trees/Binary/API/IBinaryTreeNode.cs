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

namespace CSFundamentals.DataStructures.Trees.Binary.API
{
    /// <summary>
    /// Specifies an interface for nodes in any tree structure. 
    /// </summary>
    /// <typeparam name="TNode">Is the type of the tree node. </typeparam>
    /// <typeparam name="TKey">Is the type of the keys in the tree nodes. </typeparam>
    /// <typeparam name="TValue">Is the type of the values in the tree nodes. </typeparam>
    public interface IBinaryTreeNode<TNode, TKey, TValue> :
        IComparable<TNode>
        where TKey : IComparable<TKey>
    {
        // TODO: Used by red black trees move to red black trees
        /// <summary>
        /// If set means the node contains no key-values, left or right children.
        /// </summary>
        bool IsNill { get; set; }

        /// <summary>
        /// Is the key in a tree node. 
        /// </summary>
        TKey Key { get; set; }

        /// <summary>
        /// Is the value (information) stored in a tree node. 
        /// </summary> 
        /// <remarks>
        /// This can be converted to a list of values alternatively, to handle duplicate keys. 
        /// </remarks>
        TValue Value { get; set; }

        /// <summary>
        /// Is the left child of the node. 
        /// </summary>
        TNode LeftChild { get; set; }

        /// <summary>
        /// Is the right child of the node. 
        /// </summary>
        TNode RightChild { get; set; }

        /// <summary>
        /// Is the parent of the node.
        /// </summary>
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

        List<TNode> GetChildren();
    }
}
