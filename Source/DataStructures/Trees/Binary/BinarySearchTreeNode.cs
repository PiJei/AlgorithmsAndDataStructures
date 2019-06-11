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
    /// Implements a binary search tree node. 
    /// </summary>
    /// <typeparam name="TKey">Type of the key stored in the tree. </typeparam>
    /// <typeparam name="TValue">Type of the value stored in the tree. </typeparam>
    public class BinarySearchTreeNode<TKey, TValue> : BinaryTreeNode<BinarySearchTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Parameter-less constructor. 
        /// </summary>
        public BinarySearchTreeNode()
        {
        }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="key">Type of the key stored in the tree. </param>
        /// <param name="value">Type of the value stored in the tree. </param>
        public BinarySearchTreeNode(TKey key, TValue value) : base(key, value)
        {
        }

        /// <summary>
        /// Is a reference to the left child of the current node. 
        /// </summary>
        public override BinarySearchTreeNode<TKey, TValue> LeftChild { get; set; }

        /// <summary>
        /// Is a reference to the right child of the current node. 
        /// </summary>
        public override BinarySearchTreeNode<TKey, TValue> RightChild { get; set; }

        /// <summary>
        /// Is a reference to the parent of the current node. 
        /// </summary>
        public override BinarySearchTreeNode<TKey, TValue> Parent { get; set; }
    }
}
