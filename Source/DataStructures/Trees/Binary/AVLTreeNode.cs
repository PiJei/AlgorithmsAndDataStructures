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
using AlgorithmsAndDataStructures.DataStructures.Trees.Binary.API;

namespace AlgorithmsAndDataStructures.DataStructures.Trees.Binary
{
    /// <summary>
    /// Implements an AVL tree node. 
    /// </summary>
    /// <typeparam name="TKey">Type of the key stored in the node. </typeparam>
    /// <typeparam name="TValue">Type of the value stored in the node. </typeparam>
    public class AVLTreeNode<TKey, TValue> :
        BinaryTreeNode<AVLTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <value>A reference to the left child of the current node. </value>
        public override AVLTreeNode<TKey, TValue> LeftChild { get; set; }

        /// <value>A reference to the right child of the current node. </value>
        public override AVLTreeNode<TKey, TValue> RightChild { get; set; }

        /// <value>A reference to the parent of the current node. </value>
        public override AVLTreeNode<TKey, TValue> Parent { get; set; }

        /// <summary>
        /// Parameter-less constructor. 
        /// </summary>
        public AVLTreeNode()
        {
        }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="key">The key to be stored in the tree. </param>
        /// <param name="value">The value to be stored in the tree. </param>
        public AVLTreeNode(TKey key, TValue value) : base(key, value)
        {
        }
    }
}
